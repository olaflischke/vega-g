namespace EierfarmBl
{
    public interface IEileger
    {
        List<Ei> Eier { get; set; }
        double Gewicht { get; set; }

        // C# 8: Standardimplementierungen in Interfaces
        void EiLegen()
        {
            if (this.Gewicht > 1500)
            {
                Ei ei = new(this);
                this.Eier?.Add(ei);
                this.Gewicht -= ei.Gewicht;
            }
        }
    }
}