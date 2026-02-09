using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Djursomtexas_hater
{
    public class Djuor 
    { 
        public string namn = "";
        public int ålder;
        public string längd = "";
        public string färg = "";
        public string ras = "";
        public bool rumsren;
        public int pris;

        public virtual string GetInfo() // gör en override bar string som innehåller hur djuret ska innehålla 
        {
            return
                 namn + "  " +
                 ålder + "år" + "  " +
                 längd + "  " +
                 färg + "  " +
                 ras + "  " +
                 rumsren + "  " +
                 pris+"kr";
        }        
    }
}

