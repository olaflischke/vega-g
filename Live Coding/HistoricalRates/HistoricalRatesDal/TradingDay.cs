using System.Globalization;
using System.Xml.Linq;

namespace HistoricalRatesDal
{
    public class TradingDay
    {
        public TradingDay(XElement tradingDayNode)
        {
            this.Date = DateOnly.Parse(tradingDayNode.Attribute("time").Value);

            CultureInfo ci=new CultureInfo("en-US");
            NumberFormatInfo nfi1 = ci.NumberFormat;

            NumberFormatInfo nfi = new() { NumberDecimalSeparator = "." };

            this.ExchangeRates = tradingDayNode.Elements()
                                            .Select(el => new ExchangeRate()
                                            {
                                                Symbol = el.Attribute("currency").Value,
                                                EuroValue = Convert.ToDouble(el.Attribute("rate").Value, ci) //NumberFormatInfo.InvariantInfo)
                                            })
                                            .ToList();
        }

        public DateOnly Date { get; set; }
        public List<ExchangeRate> ExchangeRates { get; set; }
    }
}