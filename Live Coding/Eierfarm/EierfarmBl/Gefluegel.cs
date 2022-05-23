using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfarmBl
{
    public abstract class Gefluegel : IEileger
    {
        public string? Name { get; set; }
        public Guid Id { get; init; } = Guid.NewGuid();
        public double Gewicht { get; set; }
        public List<Ei> Eier { get; set; } = new List<Ei>();

        public abstract void EiLegen();
        public abstract void Fressen();
    }
}
