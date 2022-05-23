using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfarmBl
{
    public class Huhn : Gefluegel
    {
        public override void EiLegen()
        {
            if (this.Gewicht > 1500)
            {
                Ei ei = new(this); // Konstruktoraufruf ohne Typ (Target typed new)
                this.Gewicht -= ei.Gewicht;
                this.Eier.Add(ei);
            }
        }

        public override void Fressen()
        {
            if (this.Gewicht < 3000)
            {
                this.Gewicht += 100;
            }
        }
    }
}
