using EierfarmBl;

namespace Tuples
{
    public class Deconstructing
    {
        void TuplesBeispiel()
        {
            var usd = ("USD", 1.0577, new DateOnly(2022, 5, 24));

            string symbol = usd.Item1;

            var bgn = (Symbol: "BGN", EuroValue: 1.95583, Date: new DateOnly(2022, 5, 24));

            string symbol2 = bgn.Symbol;

            Tuple<string, double, DateOnly> tuple = bgn.ToTuple();

            // Deconstructing:
            var (symbolBgn, euroValueBgn, dateBgn) = bgn; // Reihenfolge der Deklaration des Tuple beachten!

            // ..statt:
            string symbolBgn1 = bgn.Symbol;
            double euroBgn1 = bgn.EuroValue;
            DateOnly dateBgn1 = bgn.Date;

            Console.WriteLine($"{symbolBgn} hat am {dateBgn} den Eurokurs von {euroValueBgn}");

            var usd2 = GetDataFromTuple();
        }

        (string, double, DateOnly) GetDataFromTuple()
        {
            string s = "USD";
            double e = 1.0577;
            DateOnly d = new DateOnly(2022, 5, 24);

            return (s, e, d);
        }

        // Möglich auch als async
        //async Task<(string, double, DateOnly)> GetDataFromTupleAsync()
        //{

        //}

        void DeconstructingDictionary()
        {
            Dictionary<string, double> currencies = new Dictionary<string, double>
            {
                ["USD"] = 1.0577,
                ["BGN"] = 1.95583,
                ["DKK"] = 7.4413
            };

            // Deconstructing - Reihenfolge siehe Deklaration des Dictionary
            foreach ((string symbol, double euro) in currencies)
            {
                Console.WriteLine($"{symbol}: {euro}");
            }
        }

        void DeconstructingClass()
        {
            Huhn huhn = new Huhn() { Name = "Hilde", Gewicht = 1600 };

            var (name, gewicht, eier) = huhn; // Deconstructting für Klassen erfordert Deconstruct-Methode in der Klasse
                                                // Hier: Siehe Gefluegel, wg. Vererbung

            
        }
    }
}