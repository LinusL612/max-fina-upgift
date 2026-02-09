using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using static Djursomtexas_hater.Form1;

namespace Djursomtexas_hater
{
    public class ui
    {
        public Form1 form;
        private Manager manager; 
        private ListBox listbox; 
        private readonly string saveFile = "animals.txt"; //skapar en fil där alla djur kommer sparas i text format
        private int selectedIndex = -1;

        public ui(Form1 form, Manager manager, ListBox listbox) 
        {
            this.form = form;
            this.manager = manager;
            this.listbox = listbox;

            LoadAnimalsFromFile(listbox, saveFile);
        }
        public void SaveAnimalsToFile(string filePath) // sparar djuren till fil
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var animal in manager.Animals) // går igenom alla djur i manager och sparar ner deras data i filen
                {
                    if (animal is Katt k) //om det är katt vald så sparas kattens data i filen
                    {
                        writer.WriteLine($"K|{k.namn}|{k.ålder}|{k.längd}|{k.färg}|{k.ras}|{k.rumsren}|{k.pris}|{k.ansikte}|{k.klor}");
                    }
                    else if (animal is Hund h) // om det är hund vald så sparas hundens data i filen
                    {
                        writer.WriteLine($"H|{h.namn}|{h.ålder}|{h.längd}|{h.färg}|{h.ras}|{h.rumsren}|{h.pris}|{h.öron}|{h.svanslängd}");
                    }
                    else if (animal is vogel v) // om det är fågel vald så sparas fågelns data i filen
                    {
                        writer.WriteLine($"F|{v.namn}|{v.ålder}|{v.längd}|{v.färg}|{v.ras}|{v.rumsren}|{v.pris}");
                    }
                }
            }
        }
        public void LoadAnimalsFromFile(ListBox listbox, string filePath)
        {
            if (!File.Exists(filePath)) return;

            manager.Animals.Clear();
            listbox.Items.Clear();

            foreach (var line in File.ReadAllLines(filePath)) // går igenom varje rad i filen och skapar djur baserat på datan som finns i raden
            {
                var parts = line.Split('|'); // delar upp raden i delar som är separerade med "|"
                if (parts.Length < 8) continue; // om det inte finns tillräckligt med delar så skipas raden

                string type = parts[0];
                string namn = parts[1];
                int.TryParse(parts[2], out int ålder);
                string längd = parts[3];
                string färg = parts[4];
                string ras = parts[5];
                bool.TryParse(parts[6], out bool rumsren);
                int.TryParse(parts[7], out int pris);

                Djuor animal = null;

                switch (type)
                {
                    case "K": // om det är katt skapas en katt baserat på datan i raden
                        string ansikte = parts[8];
                        bool klor = bool.Parse(parts[9]);
                        animal = new Katt
                        {
                            namn = namn,
                            ålder = ålder,
                            längd = längd,
                            färg = färg,
                            ras = ras,
                            rumsren = rumsren,
                            pris = pris,
                            ansikte = ansikte,
                            klor = klor
                        };
                        break;

                    case "H": // om det är hund skapas en hund baserat på datan i raden
                        string öron = parts[8];
                        int.TryParse(parts[9], out int svanslängd);
                        animal = new Hund
                        {
                            namn = namn,
                            ålder = ålder,
                            längd = längd,
                            färg = färg,
                            ras = ras,
                            rumsren = rumsren,
                            pris = pris,
                            öron = öron,
                            svanslängd = svanslängd
                        };
                        break;

                    case "F": // om det är fågel skapas en fågel baserat på datan i raden
                        animal = new vogel
                        {
                            namn = namn,
                            ålder = ålder,
                            längd = längd,
                            färg = färg,
                            ras = ras,
                            rumsren = rumsren,
                            pris = pris
                        };
                        break;
                }

                if (animal != null) // om ett djur skapades så läggs det till i manager och listboxen
                {
                    manager.Animals.Add(animal);
                    listbox.Items.Add(animal.GetInfo());
                }
            }
        }
        public void SaveAnimal(string type, AnimalData data)
        {
            Djuor animal;

            if (selectedIndex != -1) // om ett djur är valt i listboxen så uppdateras det istället för att skapa ett nytt
            {
                animal = manager.Animals[selectedIndex];
                FillBase(animal, data);

                if (animal is Katt k) // om det är en katt så uppdateras kattens specifika data
                {
                    k.ansikte = data.ansikte;
                    k.klor = data.klor;
                }
                else if (animal is Hund h) // om det är en hund så uppdateras hundens specifika data
                {
                    h.öron = data.öron;
                    int.TryParse(data.svans, out h.svanslängd);
                }

                listbox.Items[selectedIndex] = animal.GetInfo();
                SaveAnimalsToFile(saveFile);
                ClearInputs();                                     
                selectedIndex = -1;
                listbox.ClearSelected();
                return;
            }
            switch (type) 
            {
                case "K": // om det är katt skapas en katt baserat på datan som skickas in
                    Katt katt = new Katt();
                    FillBase(katt, data);
                    katt.ansikte = data.ansikte;
                    katt.klor = data.klor;
                    animal = katt;
                    break;
                case "H": // om det är hund skapas en hund baserat på datan som skickas in
                    Hund hund = new Hund();
                    FillBase(hund, data);
                    hund.öron = data.öron;
                    int.TryParse(data.svans, out hund.svanslängd);
                    animal = hund;
                    break;
                case "F": // om det är fågel skapas en fågel baserat på datan som skickas in
                    vogel fågel = new vogel();
                    FillBase(fågel, data);
                    animal = fågel;
                    break;
                default:
                    MessageBox.Show("Välj ett djur först!");
                    return;
            }

            manager.Animals.Add(animal);
            listbox.Items.Add(animal.GetInfo());
            SaveAnimalsToFile(saveFile);
            ClearInputs();
        }
        private void FillBase(Djuor a, AnimalData d) // fyller i den gemensamma datan för alla djur baserat på datan som skickas in
        {
            a.namn = d.namn;
            int.TryParse(d.ålder, out a.ålder);
            a.längd = d.längd;
            a.färg = d.färg;
            a.ras = d.ras;
            a.rumsren = d.rumsren;
            a.pris = d.pris;
        }
        public void RadioSelected(string option) // visar rätt panel baserat på vilket djur som är valt i radioknapparna
        {
            ClearInputs();
            form.djurPanel.Visible = true;

            switch (option)
            {
                case "K":
                    ShowPanel(form.kattPanel);
                    break;
                case "H":
                    ShowPanel(form.hundPanel);
                    break;
                case "F":
                    form.kattPanel.Visible = false;
                    form.hundPanel.Visible = false;
                    break;
            }
        }
        private void ShowPanel(Panel p) // visar den panel som skickas in och gömmer de andra panelerna
        {
            form.kattPanel.Visible = false;
            form.hundPanel.Visible = false;

            p.Visible = true;
            p.BringToFront();
        }

        public void ClearInputs() // rensa alla input fält i formet
        {
            foreach (Control c in form.Controls)
                ClearControl(c);
        }

        private void ClearControl(Control c) // renser alla input fält i den kontrollen och alla dess barnkontroller
        {
            if (c is TextBox tb) tb.Clear();
            if (c is CheckBox cb) cb.Checked = false;

            if (c.HasChildren)
            {
                foreach (Control child in c.Controls)
                    ClearControl(child);
            }
        }
        public void AnimalList_SelectedIndexChanged(object sender, EventArgs e) 
        {  // När ett djur blir valt så skickas dens information in i input fälten
            selectedIndex = listbox.SelectedIndex;
            if (selectedIndex == -1) return;

            Djuor selectedAnimal = manager.Animals[selectedIndex];
            if (selectedAnimal == null) return;

            form.NamnBox.Text = selectedAnimal.namn;
            form.ÅlderBox.Text = selectedAnimal.ålder.ToString();
            form.StorlekBox.Text = selectedAnimal.längd;
            form.FärgBox.Text = selectedAnimal.färg;
            form.RasBox.Text = selectedAnimal.ras;
            form.Rumsrenyes.Checked = selectedAnimal.rumsren;
            form.PrisBox.Text = selectedAnimal.pris.ToString();

            if (selectedAnimal is Katt k) // om det är katt så visas rätt paneler och rätt information specifik till katter
            {
                form.AnsiktBox.Text = k.ansikte;
                form.Kloryes.Checked = k.klor;

                form.selectedAnimalType = "K";
                form.kattPanel.Visible = true;
                form.hundPanel.Visible = false;
            }
            else if (selectedAnimal is Hund h) // om det är hund så visas rätt paneler och rätt information specifik till hundar
            {
                form.ÖronBox.Text = h.öron;
                form.SvanslängdBox.Text = h.svanslängd.ToString();

                form.selectedAnimalType = "H";
                form.kattPanel.Visible = false;
                form.hundPanel.Visible = true;
            }
            else if (selectedAnimal is vogel v) // om det är fågel visas bara standard panelen och information till fågelar. 
            {
                form.selectedAnimalType = "F";
                form.kattPanel.Visible = false;
                form.hundPanel.Visible = false;
            }

            form.djurPanel.Visible = true;
        }

        public void DeleteAnimalselected(ListBox listBox) // tar bort det djur som är valt i listboxen både från manager och listboxen och uppdaterar filen
        {
            if (selectedIndex == -1) return;

            manager.Animals.RemoveAt(selectedIndex);
            listbox.Items.RemoveAt(selectedIndex);
            SaveAnimalsToFile(saveFile);
            selectedIndex = -1;
            ClearInputs(); 
        }

        public void sortbyname() // sorterar djuren i manager efter namn och uppdaterar listboxen
        {
            manager.Animals = manager.Animals
            .OrderBy(a => a.namn)
            .ToList();

            form.Updateralist();
        }   
        public void sortbyage() // sorterar djuren i manager efter ålder och uppdaterar listboxen
        {
            manager.Animals = manager.Animals
            .OrderBy(a => a.ålder)
            .ToList();

            form.Updateralist();
        }
    }
}