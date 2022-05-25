using System.Globalization;
using System.Xml.Linq;

namespace HistoricalRatesDal
{
    public class TradingDay
    {
        public TradingDay()
        {

        }

        public TradingDay(XElement tradingDayNode)
        {
            this.Date = Convert.ToDateTime(tradingDayNode.Attribute("time").Value); //DateOnly.Parse(tradingDayNode.Attribute("time").Value);

            CultureInfo ci = new CultureInfo("en-US");
            NumberFormatInfo nfi1 = ci.NumberFormat;

            NumberFormatInfo nfi = new() { NumberDecimalSeparator = "." };

            var qOriginal = tradingDayNode.Elements()
                                            // Projektion auf Annonymous Type 'a
                                            //.Select(el => new
                                            //{
                                            //    Symbol = el.Attribute("currency").Value,
                                            //    EuroValue = Convert.ToDouble(el.Attribute("rate").Value, ci)
                                            //});
                                            .Select(el => new ExchangeRate()
                                            {
                                                Symbol = el.Attribute("currency").Value,
                                                EuroValue = Convert.ToDouble(el.Attribute("rate").Value, ci),
                                                TradingDay=this
                                            });

            var qRc = tradingDayNode.Elements()
                                    .Select(el => new ExchangeRatePositionalRecordClass(
                                                                                        el.Attribute("currency").Value,
                                                                                        Convert.ToDouble(el.Attribute("rate").Value, ci)
                                                                                    )
                                            );


            var q = tradingDayNode.Elements().Select(el => new ExchangeRateStructNP()
                                            {
                                                Symbol = el.Attribute("currency").Value,
                                                EuroValue = Convert.ToDouble(el.Attribute("rate").Value, ci)
                                            });

           this.ExchangeRates = qOriginal.ToList();
        }


        public int Id { get; set; }

        public DateTime Date { get; set; }
        public List<ExchangeRate> ExchangeRates { get; set; }
    }
}