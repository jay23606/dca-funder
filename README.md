# dca-funder
Manually adds funds to a 3commas bot's deals using a custom schedule

Simply choose the bot_id and schedule you would like to run:

```csharp
static int botId = 1234567;

//1 usdt for each manual safety order to test with
static List<decimal> manual_SO_amounts = new List<decimal> { 1m, 1m, 1m, 1m };

//add 1 usdt @ 5% drop, 13% drop, 27% drop, 50% drop from CurrentPrice
static List<decimal> manual_SO_drops = new List<decimal> { 1m - .05m, 1m - .13m, 1m - .27m, 1m - .50m };
```

The idea is that you could combine this with an 'express' bot for wider averaging down if said bot results in deals with red bags


Instructions:

Add files to new C# console program and replace key/secret/botId and also add XCommas.Net from Project->Nuget menu
