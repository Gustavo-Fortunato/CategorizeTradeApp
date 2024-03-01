using CategorizeTrade.Interface;

namespace CategorizeTrade.Strategy
{
    public class LowRiskStrategy : ICategorizeTradeStrategy
    {
        public string GetCategory(ITrade trade)
        {
            return (trade.Value < 1000000 && trade.ClientSector == "Public") ? "LOWRISK" : null;
        }
    }
}
