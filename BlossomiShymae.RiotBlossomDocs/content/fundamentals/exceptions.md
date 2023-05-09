# Exceptions in RiotBlossom

RiotBlossom does have custom exceptions it uses, so keep these in mind when using the client! 💚
- `CorruptedMatchException`
- `ExhaustedRetryerException`
- `MissingApiKeyException`
- `TooManyRequestsException`
- `WarningLimiterException`

The `Retryer` when used will also throw standard exceptions that it cannot handle:
- `HttpRequestException` (400-499 except 429)
- `ArgumentNullException`
- `InvalidOperationException`
- `Exception`

## CorruptedMatchException
When crawling a large number of matches, it can happen on occasion to get a *bugged* match. RiotBlossom checks this 
for you upon fetching a match or match timeline. 

For more information, please see Riot Developer Relations [#642](https://github.com/RiotGames/developer-relations/issues/642).

## ExhaustedRetryerException
When all retries are used for a `Retryer`, this exception will be thrown.

## MissingApiKeyException
When attempting to make a call to the Riot APIs without having a Riot API key set. This is designed so the CommunityDragon or 
DataDragon APIs can be used without requiring an API key.

## TooManyRequestsException
When an HTTP **429** response was received in the HTTP request-response cycle for `AlgorithmicLimiter` or `Retryer` 
and `CanThrowOn429` is true.

## WarningLimiterException
When a rate limit was reached for `AlgorithmicLimiter` and `CanThrowOnLimit` is true. Not to be confused with 
the above exception where an actual HTTP **429** response occurs.