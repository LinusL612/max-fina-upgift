using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Djursomtexas_hater
{
    public partial class Adoptionssida : Form
    {
        string AnimalsHistoryFile = "adoptionshistory.txt"; // filen där adoptionshistoriken sparas
        string Animalsfile = "animals.txt"; // filen där djuren sparas
        public ui ui;
        Persondata persondata;

        public Adoptionssida()
        {
            InitializeComponent();
        }


        public void LoadAnimals(ListBox djurlista, string Animalsfile) // laddar in djuren från filen och visar dem i listboxen
        {
            if (!File.Exists(Animalsfile)) return;
            djurlista.Items.Clear();

            foreach (string line in File.ReadAllLines(Animalsfile)) // läser in varje rad i filen
            {
                var part = line.Split('|'); // splitrar upp raden i delar
                string type;

                switch (part[0]) // kollar vilken typ av djur det är och sätter type variabeln till rätt namn
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
                }
                string rumsren = part[6] == "True" ? "Ja" : "Nej"; // kollar om djuret är rumsrent och sätter rumsren variabeln till Ja eller Nej
                string text = $"{type} | Namn: {part[1]} | Ålder: {part[2]} | Längd: {part[3]} cm | Färg: {part[4]} | Ras: {part[5]} | Rumsren: {rumsren} | Pris: {part[7]} kr"; // skapar texten som ska visas i listboxen

                djurlista.Items.Add(text);
            }
        }
        public void SaveAnimalsHistory(string AnimalsHistoryFile,Persondata persondata,string animalInfo)
        {
            // sparar adoptionshistoriken i en fil med personens namn, personnummer och vilket djur de adopterade
            using (var writer = new StreamWriter(AnimalsHistoryFile, true))
            {
                writer.WriteLine($"{persondata.förnamn} {persondata.efternamn} {persondata.personnummer} {"adopterade"} |{animalInfo}");
            }
        }
        public void Djurlista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Adoptionssida_Load_1(object sender, EventArgs e)
        {
            LoadAnimals(Djurlista, Animalsfile);  
        }
        private void AdoptBtn_Click(object sender, EventArgs e) // adopterar den valde djuret och sparar adoptionshistoriken
        {
            if (Djurlista.SelectedItem == null)
            {
                MessageBox.Show("Vänligen välj ett djur att adoptera.");
                return;
            }

            persondata = new Persondata();

            persondata.förnamn = FörnamnBox.Text;
            persondata.efternamn = EfternamnBox.Text;
            persondata.personnummer = PersonnummerBox.Text;

            string animalInfo = Djurlista.SelectedItem.ToString(); // hämtar informationen om det valda djuret från listboxen

            if (string.IsNullOrWhiteSpace(persondata.förnamn) ||
                string.IsNullOrWhiteSpace(persondata.efternamn) ||
                string.IsNullOrWhiteSpace(persondata.personnummer))
            {
                MessageBox.Show("Vänligen fyll i alla dina uppgifter.");
                return;
            }

            SaveAnimalsHistory(AnimalsHistoryFile, persondata, animalInfo);

            MessageBox.Show($"Tack för att du adopterade! Du har adopterat: {animalInfo}");
            int index = Djurlista.SelectedIndex;
            Djurlista.Items.RemoveAt(index);

            ui.DeleteAnimalselected(Djurlista);

            FörnamnBox.Clear();
            EfternamnBox.Clear();
            PersonnummerBox.Clear();
        }

        private void HistoryBtn_Click(object sender, EventArgs e) // öppnar historik fliken och gömmer denna 
        {
            this.Hide();
            Historik adoptionshistorik = new Historik();
            adoptionshistorik.ShowDialog();
            this.Show();
        }
    }
        public class Persondata // skapar en class med information som andra klasser kan använda
        {
           public string förnamn;
           public string efternamn;
           public string personnummer; 
        }
}
