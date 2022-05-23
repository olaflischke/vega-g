// Console in C# 10: Top-Level-Statements ohne Main(string[] args)

//using EierfarmBl;
//using System.Text;

// Demo für Nullable-Types
// .csproj-Datei einthält defaultmäßig     <Nullable>enable</Nullable>
// Abschalten all der Null-Warnings per     <Nullable>disable</Nullable>

Huhn hilde = null;

// Maybe null hier
Console.WriteLine($"Das Huhn heißt {hilde.Name}.");

if (hilde != null)
{
    // keine Warning hier
    Console.WriteLine($"Das Huhn heißt {hilde.Name}.");

    Huhn herta = hilde;

    // keine Warning hier
    Console.WriteLine($"Das Huhn heißt {herta.Name}.");
}

// Maybe null hier
Huhn hanne = hilde;

// Warning hier
Console.WriteLine($"Das Huhn heißt {hanne.Name}.");

hilde = new();

// Keine Warnung
Console.WriteLine($"Das Huhn heißt {hilde.Name}.");

#nullable disable
Huhn heike = null;

// Keine Warnung
Console.WriteLine($"Das Huhn heißt {heike.Name}.");

#nullable enable

// keine Warning
Huhn? henriette = null;

Console.WriteLine($"Das Huhn heißt {henriette?.Name}.");


int? a = null;
//int b = 12 + (a.HasValue ? a.Value : 0);
int b = 12 + a ?? 0;

Huhn huhn = null;

// Statt...
if (huhn == null)
{
    huhn = new();
}

// ...Null-coalescing assignent
huhn ??= new();

List<int> numbers = null;
(numbers ??= new List<int>()).Add(5);
numbers.Add(a ?? 0); // a bleibt unverändert
numbers.Add(a ??= 0); // a = 0


string hallo = "Hallo";
string welt = "Welt";

Console.WriteLine(hallo + " " + welt); // böse, weil "Strings are immutable"!
Console.WriteLine($"{hallo} {welt}");

char[] halloChars = new char[5] { 'h', 'a', 'l', 'l', 'o' };

StringBuilder stringBuilder = new StringBuilder(hallo);
stringBuilder.Append(" ");
stringBuilder.Append(welt);

Console.WriteLine(stringBuilder.ToString());

DateOnly heute = DateOnly.FromDateTime(DateTime.Today);
Console.WriteLine($"{heute:dd.MM.yy}");

string datei = "README.md";
string pfad = $@"C:\tmp\vega-g\{datei}"; // C# 7:  Reihenfolge von $ und @ egal!