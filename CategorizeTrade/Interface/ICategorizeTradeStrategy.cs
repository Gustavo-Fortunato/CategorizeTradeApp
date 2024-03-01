namespace CategorizeTrade.Interface
{
    public interface ICategorizeTradeStrategy
    {
        string GetCategory(ITrade trade);
    }
}
