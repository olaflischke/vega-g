namespace EierfarmBl
{
    public class Ei
    {
        public Ei(IEileger mutter)
        {
            Random random = new Random();
            this.Gewicht = random.Next(45, 81);
            this.Farbe = (EiFarbe)random.Next(3);

            this.Legedatum = DateOnly.FromDateTime(DateTime.Today);
            this.Mutter = mutter;
        }

        public Guid Id { get; init; } = Guid.NewGuid();
        public EiFarbe Farbe { get; set; }
        public double Gewicht { get; init; } // Init-Only: Nur einmal einen Wert zuweisen
        public DateOnly Legedatum { get; set; }

        public IEileger Mutter { get; set; }
    }

    public enum EiFarbe
    {
        Dunkel,
        Hell,
        Gruen
    }
}