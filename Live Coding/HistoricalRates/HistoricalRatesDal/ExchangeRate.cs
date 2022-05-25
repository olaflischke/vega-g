namespace HistoricalRatesDal
{
    public class ExchangeRate
    {
        public string Symbol { get; set; }
        public double EuroValue { get; set; }
        public int Id { get; set; }
        public TradingDay TradingDay { get; set; }
    }
}