using CategorizeTrade.Client;
using CategorizeTrade.Interface;
using CategorizeTrade.Model;
using CategorizeTrade.Strategy;

class Program //Client
{
    static void Main()
    {
        List<ITrade> portfolio = new List<ITrade>
        {
            new Trade { Value = 2000000, ClientSector = "Private" },
            new Trade { Value = 400000, ClientSector = "Public" },
            new Trade { Value = 500000, ClientSector = "Public" },
            new Trade { Value = 3000000, ClientSector = "Public" }
        };

        CategorizeTradeContext lowRiskContext = new CategorizeTradeContext(new LowRiskStrategy());
        CategorizeTradeContext mediumRiskContext = new CategorizeTradeContext(new MediumRiskStrategy());
        CategorizeTradeContext highRiskContext = new CategorizeTradeContext(new HighRiskStrategy());

        List<string> tradeCategories = new List<string>();
        foreach (var trade in portfolio)
        {
            string category = lowRiskContext.GetCategory(trade)
                              ?? mediumRiskContext.GetCategory(trade)
                              ?? highRiskContext.GetCategory(trade);
            tradeCategories.Add(category);
        }

        Console.WriteLine("Trade Categories: {" + string.Join(", ", tradeCategories) + "}");
    }
}