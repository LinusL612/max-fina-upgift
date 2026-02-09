using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djursomtexas_hater
{
    public class vogel : Djuor
    {
        public override string GetInfo() // overridear GetInfo metoden från Djuor klassen för att lägga till information om att det är en fågel>
        {
            return " (Fågel) " + base.GetInfo();
        }
    }
}
