using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Djursomtexas_hater
{
    public partial class Historik : Form
    {
        string AnimalsHistoryFile = "adoptionshistory.txt"; // skapar en string som innehåller sökvägen till filen där adoptionshistoriken sparas
        public Historik()
        {
            InitializeComponent();
        }
        public void Loadanimals(ListBox HistoriaList, string AnimalsHistoryFile) 
        {
            if (!System.IO.File.Exists(AnimalsHistoryFile)) return; 
            HistoriaList.Items.Clear();

            foreach (string Text in System.IO.File.ReadAllLines(AnimalsHistoryFile)) //läser varje rad i filen
            {
                HistoriaList.Items.Add(Text); // lägger till varje rad i listboxen
            }

        }
        private void Historik_Load(object sender, EventArgs e) // när Historik formet öppnas så loadar den in adoptionshistoriken i listboxen
        {
            Loadanimals(HistoriaList, AnimalsHistoryFile);
        }
    }
}
