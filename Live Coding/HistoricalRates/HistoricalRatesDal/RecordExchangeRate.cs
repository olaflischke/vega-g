using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricalRatesDal
{
    // C# 9:

    // PositionalRecordClass (class-Schlüsselwort optional)
    // Record mit Properties, init-only
    public record ExchangeRatePositionalRecordClass(string Symbol, double EuroValue);

    // Non-positional record class
    // Properties sind R/W
    public record ExchangeRateNonPosRecordClass()
    {
        public string Symbol { get; set; }
        public double EuroValue { get; set; }
    }

    // C# 10:
    // Record struct
    // recStruct1 == recStruct2, wenn alle Werte gleich

    // Positional Record Struct
    // Properties sind init-only => Reference-Type
    // Compiler: Alles von object + Deconstruct-Methode
    public readonly record struct ExchangeRateRs(string Symbol, double EuroValue);

    // Value-Type
    // Compiler: 2 Konstruktoren (parameterlos + parametrisiert mit allen Feld), alles von object + Deconstruct-Methode
    public record struct ExchangeRateRsWriteable(string Symbol, double EuroValue);

    // Value-Type
    // Compiler: 1 Konstruktoren (parameterlos + parametrisiert mit allen Feld), alles von object 
    // Auto-Properties: Default-Werte explizit angeben!
    public record struct ExchangeRateStructNP()
    {
        public string Symbol { get; set; } = String.Empty;
        public double EuroValue { get; set; } = 0;
    }

    public record struct ExchangeRateStructHybrid(string Symbol)
    {
        public double EuroValue { get; set; } = 0.0;
    }

    public record struct ExchangeRateWithToString(string Symbol, double EuroValue)
    {
        public override string ToString()
        {
            return $"ExchangeRate {Symbol}: {EuroValue}";
        }
    }
}
