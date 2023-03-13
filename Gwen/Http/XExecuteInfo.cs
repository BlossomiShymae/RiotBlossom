namespace Gwen.Http
{
	public record XExecuteInfo
	{
		public string RoutingValue { get; init; } = string.Empty;
		public string MethodUri { get; init; } = string.Empty;
	}
}
