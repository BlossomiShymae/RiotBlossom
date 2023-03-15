namespace Gwen.Http
{
	internal class RiotGamesClient
	{
		private readonly HttpClient _httpClient;
		private readonly string _riotApiKey;
		private readonly string _routingValue;
		private readonly XMiddlewares _xMiddlewares;

		public RiotGamesClient(HttpClient httpClient, string riotApiKey, string routingValue, XMiddlewares xMiddlewares)
		{
			_httpClient = httpClient;
			_riotApiKey = riotApiKey;
			_routingValue = routingValue;
			_xMiddlewares = xMiddlewares;
		}

		public async Task<string> GetStringAsync(string uri, string query)
		{
			// Create request message
			var requestUri = new Uri($"https://{_routingValue}.api.riotgames.com{uri}{query}");
			using var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
			requestMessage.Headers.Add("X-Riot-Token", _riotApiKey);

			// Create execute info
			var executeInfo = new XExecuteInfo
			{
				RoutingValue = _routingValue,
				MethodUri = uri
			};

			var data = await ProcessXMiddlewaresAsync(executeInfo, requestMessage);
			return data;
		}

		private async Task<string> ProcessXMiddlewaresAsync(XExecuteInfo xExecuteInfo, HttpRequestMessage requestMessage)
		{
			// Use request middlewares, if any
			string? data = null;
			void hit(string value) => data = value;
			bool isNext = false;
			void next() => isNext = true;
			foreach (var requestMiddleware in _xMiddlewares.XRequests)
			{
				isNext = false;
				await requestMiddleware.Invoke(xExecuteInfo, requestMessage, hit, next);
				if (!isNext)
					break;
			}
			if (data != null)
				return data;

			// Use retry middleware, if any
			var res = await _xMiddlewares.XRetry.Invoke(async () => await _httpClient.SendAsync(requestMessage));

			// Use response middlewares, if any
			foreach (var responseMiddleware in _xMiddlewares.XResponses)
			{
				isNext = false;
				await responseMiddleware.Invoke(xExecuteInfo, res, next);
				if (!isNext)
					break;
			}

			if (!res.IsSuccessStatusCode)
			{
				int statusCode = (int)res.StatusCode;
				res.Dispose();
				throw new InvalidOperationException($"Response is not successful: {statusCode}");
			}

			data = await res.Content.ReadAsStringAsync();
			res.Dispose();
			return data;
		}
	}
}
