# Tutorial: Get started with RiotBlossom

This totes awesome tutorial will show you how to install RiotBlossom and make 
a request to the Riot Games API using .NET Core CLI!

You will learn how to:
- Create a console project
- Setup RiotBlossom
- Fetching data from `summoner-v4`
- Run the app

## Prerequisites

- .NET 6.0 SDK
- Riot Games API Key
- Reading the official Riot Games Developer Documentation and Policies

## Create a console project

Open your preferred shell and enter the following command:

```bash
dotnet new console
```

This command will create source files within the current directory.

## Setup RiotBlossom

We will first need to install RiotBlossom from nuget.org, an online NuGet package 
repository for .NET apps.

```bash
dotnet add package BlossomiShymae.RiotBlossom
```

With the package added, we can now fetch data from `summoner-v4`!

## Fetching data from `summoner-v4`

Open `Program.cs` to modify and save the code to something like this:

```csharp
using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Type;

string key = Environment.GetEnvironmentVariable("RIOT_API_KEY")
    ?? throw new InvalidOperationException("RIOT_API_KEY must be set!");
var client = RiotBlossomCore.CreateClient(key);

var summoner = await client.Riot.Summoner
    .GetByNameAsync(Platform.NorthAmerica, "uwuie time");

Console.WriteLine(summoner);
```

## Run the app

Run the following command:

```bash
dotnet run
```

It should result in something similar to this:

![Run](/img/get-started-run.png)

You did it! :3