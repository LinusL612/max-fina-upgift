using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Djursomtexas_hater
{
    public class Manager : Form
    {
        bool detaljer = true;
        string filepath = "animals.txt";
        public List<Djuor> Animals { get; set; } = new List<Djuor>(); // skapar en lista av djur som kan användas i hela programmet
        public void AddAnimal(Djuor a)
        {
            Animals.Add(a);
        }

        public void Showdetails(ListBox AnimalList)
        {
                AnimalList.Items.Clear();

            if (!File.Exists(filepath)) return;

            foreach (var line in File.ReadAllLines(filepath)) // läser in varje rad i filen
            {
                var parts = line.Split('|'); // splitrar upp raden i delar

                string type = parts[0];
                string namn = parts[1];
                int.TryParse(parts[2], out int ålder);
                int.TryParse(parts[7], out int pris);
                string längd = parts[3];
                string färg = parts[4];
                string ras = parts[5];
                bool.TryParse(parts[6], out bool rumsren);
                
                switch (type) // kollar vilken typ av djur det är och sätter type variabeln till rätt namn
                {
                    case "K":
                        type = "Katt";
                        break;
                    case "H":
                        type = "Hund";
                        break;
                    case "F":
                        type = "Fågel";
                        break;
                    default:
                        type = "Okänd";
                        break;
                };

                if (detaljer == false) // om detaljer är false så visas enkel information.
                {
                    AnimalList.Items.Add($"{type} | Namn: {namn} | Ålder: {ålder} år | Pris: {pris} kr");
                    Console.WriteLine(namn);
                }

                else // om detaljer är true så visas all information.
                {
                    AnimalList.Items.Add($" {type} | Namn: {namn} | Ålder: {ålder} år | Pris: {pris} kr  Längd: {längd} | Färg: {färg} | Ras: {ras} | Rumsren: {rumsren}");
                    Console.WriteLine(type);
                }
            }
                if (detaljer == true) // ändrar detaljer till falskt om detaljer var true
                {
                    detaljer = false;
                }

                else if (detaljer == false) // ändrar detaljer till true om detaljer var false
            {
                detaljer = true;
                }

        }
        private void Manager_Load(object sender, EventArgs e)
        {

        }
    }
}