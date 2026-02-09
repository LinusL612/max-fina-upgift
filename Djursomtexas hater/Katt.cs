using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djursomtexas_hater
{
    public class Katt : Djuor
    {
        public string ansikte = "";
        public bool klor;
        public override string GetInfo() // overridear GetInfo metoden från Djuor klassen för att lägga till information om att det är en Katt
        {
            return "(Katt)" + "  " + base.GetInfo() +
                 ansikte + "  " +
                 klor;
        }
    }
}
