using CategorizeTrade.Interface;

namespace CategorizeTrade.Client
{
    public class CategorizeTradeContext
    {
        private ICategorizeTradeStrategy strategy;

        public CategorizeTradeContext(ICategorizeTradeStrategy strategy)
        {
            this.strategy = strategy;
        }

        public string GetCategory(ITrade trade)
        {
            return strategy.GetCategory(trade) ?? null;
        }
    }
}
