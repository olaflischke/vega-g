namespace ArraysUndCollections
{
    public class IndexerUndRanges
    {
        void ArraySamples()
        {
            string[] leute = { "Klaus", "Werner", "Theo", "Nicole", "Barbara", "Petra" };

            string klaus = leute[0];

            // C# 8:
            string barbara = leute[^2]; // Zählen von hinten - 1-basiert!

            Index indexNicole = ^3; // Index als Typ
            string nicole = leute[indexNicole];

            Index indexSample = Index.FromEnd(3);
            string nicole2 = leute[indexSample];

            Index iKlaus = Index.FromStart(0); // Von vorne gezählt: Weiterhin 0-basiert
            string klaus1 = leute[iKlaus];

            string[] kerle = leute[0..3]; // Range in einem Array, nullbasiert (zweiter Wert: Exklusive Obergrenze!)

            Range range = 3..6; // Range als Typ
            string[] maedls = leute[range];
            string[] ab3 = leute[3..];
            string[] bis4 = leute[..4];

        }
    }
}