using CategorizeTrade.Interface;

namespace CategorizeTrade.Strategy
{
    public class MediumRiskStrategy : ICategorizeTradeStrategy
    {
        public string GetCategory(ITrade trade)
        {
            return (trade.Value >= 1000000 && trade.ClientSector == "Public") ? "MEDIUMRISK" : null;
        }
    }
}
