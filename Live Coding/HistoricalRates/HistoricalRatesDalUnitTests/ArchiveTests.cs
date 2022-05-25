using HistoricalRatesDal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace HistoricalRatesDalUnitTests
{
    [TestClass]
    public class ArchiveTests
    {
        string url;

        public ArchiveTests()
        {
            url = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml";
            //url = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist.xml";
        }

        [TestMethod]
        public void IsArchiveInitialising()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Archive archive = new(url);

            stopwatch.Stop();

            Console.WriteLine($"USD vom {archive.TradingDays?.FirstOrDefault()?.Date:dd.MM.yy}: {archive.TradingDays?.FirstOrDefault()?.ExchangeRates.First(er => er.Symbol == "USD").EuroValue:#,##0.0000} (nach {stopwatch.ElapsedMilliseconds}ms)");

            stopwatch.Reset();
            //stopwatch.Start();

            Assert.AreEqual(CountAttribute("time"), archive.TradingDays.Count());
        }

        [TestMethod]
        public void IsArchiveSavingToDb()
        {
            Archive archive = new(url);
            archive.SaveToDb();
        }

        private int CountAttribute(string attributeName)
        {
            // TODO: Echte Zählung implementieren
            return 62;
        }
    }
}