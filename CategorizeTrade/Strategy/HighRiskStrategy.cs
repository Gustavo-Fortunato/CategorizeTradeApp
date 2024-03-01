using CategorizeTrade.Interface;

namespace CategorizeTrade.Strategy
{
    public class HighRiskStrategy : ICategorizeTradeStrategy
    {
        public string GetCategory(ITrade trade)
        {
            return (trade.Value >= 1000000 && trade.ClientSector == "Private") ? "HIGHRISK" : null;
        }
    }
}
