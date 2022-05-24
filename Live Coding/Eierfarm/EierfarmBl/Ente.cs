using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfarmBl
{
    public class Ente : Gefluegel
    {
        public Ente():base("Neue Ente")
        {
            this.Gewicht = 1000;
        }

        public override void EiLegen()
        {
            if (this.Gewicht>1500)
            {
                Ei ei = new(this);
                this.Eier.Add(ei);
                this.Gewicht -= ei.Gewicht;
            }
        }

        public override void Fressen()
        {
            if (this.Gewicht<2000)
            {
                this.Gewicht += 100;
            }
        }
    }
}
