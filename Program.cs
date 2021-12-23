using System;
using XCommas.Net;
using XCommas.Net.Objects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dca_funder
{
    class Program
    {
        //update with your 3c api key/secret and exchange info
        static string key = "xxx";
        static string secret = "xxx";
        static string market = "kucoin";
        static int accountId = 0;
        static int botId = 1234567;
        static XCommasApi api;

        //safety order sizes in usdt
        static List<decimal> manual_SO_amounts = new List<decimal> { 24m, 32m, 48m, 64m };

        //add SO @ 6% drop, 12% drop, 24% drop, 48% drop from CurrentPrice
        static List<decimal> manual_SO_drops = new List<decimal> { 1m - .06m, 1m - .12m, 1m - .24m, 1m - .48m };

        static void Main() { MainAsync().GetAwaiter().GetResult(); }
        static async Task MainAsync()
        {
            api = new XCommasApi(key, secret, default, UserMode.Real);
            var accts = await api.GetAccountsAsync();
            foreach (var acct in accts.Data) if (acct.MarketCode == market) { accountId = acct.Id; break; }

            while (true)
            {
                try
                {
                    var deals = await api.GetDealsAsync(limit: 1000, accountId: accountId, botId: botId, dealScope: DealScope.Active);

                    //XCommas is missing the active_manual_safety_orders property unfortunately but we can get it
                    List<DealRoot> drs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DealRoot>>(deals.RawData);

                    int idx = 0;
                    foreach (Deal deal in deals.Data)
                    {
                        //only add the manual safety orders the first go around
                        if ((drs[idx].active_manual_safety_orders + deal.CompletedManualSafetyOrdersCount) < manual_SO_amounts.Count)
                        {
                            for (int i = 0; i < manual_SO_amounts.Count; i++)
                            {
                                var dafp = new DealAddFundsParameters
                                {
                                    Quantity = manual_SO_amounts[i] / (deal.CurrentPrice * manual_SO_drops[i]),
                                    IsMarket = false,
                                    Rate = deal.CurrentPrice * manual_SO_drops[i],
                                    DealId = deal.Id
                                };
                                var res = await api.AddFundsToDealAsync(dafp);
                                if (res.IsSuccess) Console.WriteLine($"Added manual SO to {deal.BotName}/{deal.Pair} for Quantity: {Math.Round(dafp.Quantity, 2)} @ {dafp.Rate} limit price (${Math.Round((decimal)(dafp.Quantity * dafp.Rate), 2)}) at {DateTime.Now.ToShortTimeString()}");
                            }
                            Console.WriteLine("");
                        }
                        idx++;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                    api = new XCommasApi(key, secret, default, UserMode.Real);
                }
                //update every minute
                await Task.Delay(1000 * 60 * 1);
            }
        }
    }
}
