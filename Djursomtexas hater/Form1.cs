using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Djursomtexas_hater
{
    public partial class Form1 : Form
    {
        private ui ui;
        private Manager manager;

        public Panel kattPanel;
        public Panel hundPanel;
        public Panel djurPanel;

        public string selectedAnimalType = "";

        public Form1()
        {
            InitializeComponent();
            manager = new Manager();
            ui = new ui(this, manager, AnimalList);
            
            // skapar refrenser så ui can komma ut panelerna
            kattPanel = Kattpanel; 
            hundPanel = Hundpanel;
            djurPanel = Djurpanel;
        }
        public class AnimalData //skapar data för att kunna skicka data mellan klasserna och spara ner det i manager
        {
            public string namn;
            public string ålder;
            public string längd;
            public string färg;
            public string ras;
            public bool rumsren;
            public string ansikte;
            public bool klor;
            public string öron;
            public string svans;
            public int pris;
        }
        public void OpenPanel()
        {
            Djurpanel.Visible = true;       
            Djurpanel.BringToFront();       
        }
        public void Kattvald_CheckedChanged(object sender, EventArgs e)
        {
           if (Kattvald.Checked)
            {
                ui.RadioSelected("K");
                selectedAnimalType = "K";
            }
        }

        public void Hundvald_CheckedChanged(object sender, EventArgs e)
        {
            if (Hundvald.Checked)
            {
                ui.RadioSelected("H");
                selectedAnimalType = "H";
            }
        }

        public void Fågelvald_CheckedChanged(object sender, EventArgs e)
        {
            if (Fågelvald.Checked)
            {
                selectedAnimalType = "F";
                ui.RadioSelected("F");
            }
        }
        public void AnimalList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ui.AnimalList_SelectedIndexChanged(sender, e);
        }

        public void savebtn_Click(object sender, EventArgs e)
        {
            AnimalData data = new AnimalData() //skapar informationen som skickas till manager för att spara ner det i listan
            {
                namn = NamnBox.Text,
                ålder = ÅlderBox.Text,
                längd = StorlekBox.Text,
                färg = FärgBox.Text,
                ras = RasBox.Text,
                rumsren = Rumsrenyes.Checked,
                pris = int.Parse(PrisBox.Text),
                ansikte = AnsiktBox.Text,
                klor = Kloryes.Checked,
                öron = ÖronBox.Text,
                svans = SvanslängdBox.Text
            };
            ui.SaveAnimal(selectedAnimalType, data);
        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            ui.DeleteAnimalselected(AnimalList);
        }

        private void Adoptionbtn_Click(object sender, EventArgs e) //öppnar adoptionssidan
        {
            this.Hide();
            Adoptionssida adoptionssida = new Adoptionssida();
            adoptionssida.ui = ui;
            adoptionssida.ShowDialog();
            this.Show();
        }

        private void HistoryBtn_Click(object sender, EventArgs e) //öppnar adoptionshistoriken
        {
            this.Hide();
            Historik adoptionshistorik = new Historik();
            adoptionshistorik.ShowDialog();
            this.Show();
        }

        public void Sortage_Click(object sender, EventArgs e)
        {
            ui.sortbyage();
        }

        public void Sortname_Click(object sender, EventArgs e)
        {
            ui.sortbyname();
        }
        public void Updateralist() //updaterar animallist
        {
            AnimalList.Items.Clear();

            foreach (var animals in manager.Animals)
            {
                AnimalList.Items.Add(animals.GetInfo());
            }
            AnimalList_SelectedIndexChanged (null, null);
        }

        private void Detaljbtn_Click(object sender, EventArgs e)
        {
            manager.Showdetails(AnimalList);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}