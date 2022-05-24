using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysUndCollections
{
    internal class DictionaryInit
    {
        void InitDictiotnaries()
        {
            var orte = new Dictionary<int, string>()
            {
                {44797, "Bochum" },
                {77761, "Schiltach" },
                {4040, "Linz" }
            };

            var orte2 = new Dictionary<int, string>()
            {
                [44797] = "Bochum",
                [77761] = "Schiltach",
                [4040] = "Linz"
            };

            var orte3 = new Dictionary<string, string>()
            {
                ["44797"] = "Bochum",
                ["AT-4040"] = "Linz"
            };

            var leute = new Dictionary<Guid, string>()
            {
                [Guid.NewGuid()] = "Klaus",
                [Guid.NewGuid()] = "Barbara"
            };
        }
    }
}
