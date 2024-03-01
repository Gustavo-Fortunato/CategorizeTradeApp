using CategorizeTrade.Interface;

namespace CategorizeTrade.Model
{
    public class Trade : ITrade
    {
        public double Value { get; set; }
        public string ClientSector { get; set; } = string.Empty;
    }
}
