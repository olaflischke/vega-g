using EierfarmBl;
using System;
using System.Net;

namespace PatternMatching
{
    public class PatternMatchingSamples
    {
        void SwitchPatterns()
        {
            Huhn huhn = new Huhn() { Name = "Hilde" };

            if (huhn.Name == "Hilde")
            {
                huhn.EiLegen();
            }
            else if (huhn.Name == "Herta")
            {
                huhn.Fressen();
            }
            else
            {

            }
            // C# 7: Switch auf eine Property 
            switch (huhn.Name)
            {
                case "Hilde":
                    huhn.EiLegen();
                    break;
                case "Herta":
                    huhn.Fressen();
                    break;
                default:
                    break;
            }

            IEileger tier = new Huhn() { Name = "Hilde" };

            // Unschön
            switch (tier.GetType().Name)
            {
                case nameof(Huhn):
                    tier.EiLegen();
                    break;
                case "Gans":

                    break;

                default:
                    break;
            }

            // Pattern Matching
            switch (tier)
            {
                case Huhn huhn3 when huhn3.Gewicht < 1500: // Pattern Filter
                    huhn3.Fressen();
                    break;

                case Huhn chicken: // C#7/8: chicken als Variable
                    chicken.EiLegen();
                    break;
                case Ente _:

                default:
                    break;
            }

            // Statt...
            Huhn huhn1 = tier as Huhn;
            if (huhn1 != null)
            {
                huhn1.Fressen();
            }
            // ...pattern matching
            if (tier is Huhn huhn2)
            {
                huhn2.Fressen();
            }

            // Switch Expression

            string stall = huhn1.Name switch
            {
                "Hilde" => "Gryffindor",
                "Herta" => "Hufflepuff",
                _ => "Unknown"
            };

            string stall2 = huhn1 switch
            {
                { Name: "Hilde" } => "Gryffindor",
                { Name: "Herta" } => "Hufflepuff",
                _ => "Unknown"
            };

            // Pattern Matching Filter für Switch Expressions
            string stall3 = tier switch
            {
                Huhn huhn4 when huhn4.Gewicht < 1000 => $"{huhn4.Name} wohnt in Gryffindor",
                Huhn huhn5 => $"{huhn5.Name} wohnt in Ravenclaw",
                _ => DiscardSample("Hallo").ToString()
            };


            // Filter auch für Exception Handling
            string url = null;
            try
            {
                // Open url
            }
            catch (Exception ex) when (url == string.Empty)
            {
                throw new NewFeaturesException("Fehler beim Öffnen der URL", ex);
            }
            catch (Exception ex) when (ex is WebException webEx || ex is IndexOutOfRangeException ioEx)
            {

            }
            catch (Exception ex)
            {

            }
        }

        bool DiscardSample(string text)
        {
            return double.TryParse(text, out double _);

        }
    }
}