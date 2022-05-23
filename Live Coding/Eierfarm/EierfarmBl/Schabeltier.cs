using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfarmBl
{
    public abstract class Saeugetier
    {
        public abstract void Saeugen();
        public abstract void Fressen();
    }

    public class Schabeltier : Saeugetier, IEileger
    {
        public List<Ei> Eier { get; set; }

        public double Gewicht { get; set; }


        public override void Fressen()
        {
            throw new NotImplementedException();
        }

        public override void Saeugen()
        {
            throw new NotImplementedException();
        }
    }
}
