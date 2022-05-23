using EierfarmBl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching46
{
    class PatternMatching
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

            switch (huhn.Name)
            {
                case "Hilde":


                default:
                    break;
            }
        }
    }
}
