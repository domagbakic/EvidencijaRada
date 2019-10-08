using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Evidencija
{
    public partial class glavnaForma : Form
    {        
        public glavnaForma()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pregledEvidencija.Selected += new TabControlEventHandler(pregledEvidencija_Selected);
            CistiLabele();
            PrikaziVrsteRada();
            DohvatiDjelatnike();
            PuniTablicu();
            PuniTablicu2();
            PuniTablicu3();
            PuniDomain();
            PuniDomain2();
            BojajDGV();
        }

        private void pregledEvidencija_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Name == mjesecniPregled.Name)
            {
                CistiLabele();
                PuniTablicu3();
            }
            else if (e.TabPage.Name == tjedniPregled.Name)
            {
                CistiLabele();
                PuniTablicu();
            }
            else if (e.TabPage.Name == dnevniPregled.Name)
            {
                CistiLabele();
                PuniTablicu2();
            }
        }

        private void CistiLabele()
        {
            //dnevni pregled
            var labels = this.tableLayoutPanel2.Controls.OfType<Label>()
                          .Where(c => c.Name.StartsWith("lbl1"))
                          .ToList();

            foreach (var label in labels)
            {
                label.Text = "";
                label.BackColor = Color.FromName("Control");
            }

            //mjesecni pregled
            var labels2 = this.tableLayoutPanel3.Controls.OfType<Label>()
                          .Where(c => c.Name.StartsWith("lblA"))
                          .ToList();

            foreach (var label in labels2)
            {
                label.Text = "0";
                label.BackColor = Color.FromName("Control");
            }

            //tjedni pregled
            var labels3 = this.tableLayoutPanel1.Controls.OfType<Label>()
                          .Where(c => c.Name.StartsWith("lbl1"))
                          .ToList();

            foreach (var label in labels3)
            {
                label.Text = "0";
                label.BackColor = Color.FromName("Control");
            }
        }

        private void BojajDGV()
        {
            string boja = "";
            if (dgvVrstaRada.Rows.Count >= 0)
            {
                foreach (DataGridViewRow row in dgvVrstaRada.Rows)
                {
                    boja = row.Cells[2].Value.ToString();
                    row.Cells[2].Style.BackColor = Color.FromName(boja);
                    row.Cells[2].Value = "";
                }
            }
        }
        
        private void PrikaziVrsteRada()
        {
            BindingList<vrstaRada> listaRada = new BindingList<vrstaRada>();
            using (var db = new evidencijaEntities())
            {
                listaRada = new BindingList<vrstaRada>(db.vrstaRada.ToList());
            }
            vrstaRadaBindingSource.DataSource = listaRada;
        }
        private void DohvatiDjelatnike()
        {
            BindingList<djelatnik> listaDjelatnika = new BindingList<djelatnik>();
            using (var db = new evidencijaEntities())
            {
                listaDjelatnika = new BindingList<djelatnik>(db.djelatnik.ToList());
            }
            djelatnikBindingSource.DataSource = listaDjelatnika;
        }

        private void PuniTablicu()
        {  
            var labels = this.tableLayoutPanel1.Controls.OfType<Label>()
                          .Where(c => c.Name.StartsWith("lbl1"))
                          .ToList();

            using (var db = new evidencijaEntities())
            {
                var A = db.vezaDjelatnikRad.Where(x => x.id_djelatnik == 1).ToList();
                foreach (var item in A)
                {
                    foreach (var label in labels)
                    {
                        if (item.danUTjednu != "nedjelja") // TODO problem ponedjeljak-nedjelja
                        {
                            if (label.Name.Contains(item.danUTjednu))
                            {
                                if (item.tjedanUGodini.ToString() == domTjedan.Text)
                                {
                                    label.BackColor = Color.FromName(item.vrstaRada.boja);
                                    label.Text = item.brojSati.ToString();
                                }
                            }
                        }
                        else
                        {
                            if (label.Name.Contains(item.danUTjednu))
                            {
                                if (item.tjedanUGodini.ToString() == domTjedan.Text)
                                {
                                    label.BackColor = Color.FromName(item.vrstaRada.boja);
                                    label.Text = item.brojSati.ToString();
                                }
                            }
                        }
                    }                    
                }
            }            
        }
        
        public static int GetIso8601WeekOfYear(DateTime time) // Za svaki datum računa broj tjedna u godini
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
                
        public static DateTime FirstDateOfWeekISO8601(int year, int weekOfYear) //računa datum ponedjeljka za svaki broj tjedna
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            // Use first Thursday in January to get first week of the year as
            // it will never be in Week 52/53
            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            // As we're adding days to a date in Week 1,
            // we need to subtract 1 in order to get the right date for week #1
            if (firstWeek == 1)
            {
                weekNum -= 1;
            }

            // Using the first Thursday as starting week ensures that we are starting in the right year
            // then we add number of weeks multiplied with days
            var result = firstThursday.AddDays(weekNum * 7);

            // Subtract 3 days from Thursday to get Monday, which is the first weekday in ISO8601
            return result.AddDays(-3);
        }
        private void PuniDomain() // Domain s tjednima
        {
            DomainUpDown.DomainUpDownItemCollection tjedniUGodini = this.domTjedan.Items;
            DateTime zadnjiDan = new DateTime(2019, 12, 27);
            int brojTjedana = GetIso8601WeekOfYear(zadnjiDan);
            for (int i = 1; i <= brojTjedana; i++)
            {
                tjedniUGodini.Add(i.ToString());                
            }
            domTjedan.SelectedIndex = GetIso8601WeekOfYear(DateTime.Now) - 1;
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            CistiLabele();
            PuniTablicu();
            lblponedjeljak.Text = "Ponedjeljak";
            lblUtorak.Text = "Utorak";
            lblSrijeda.Text = "Srijeda";
            lblCetvrtak.Text = "Četvrtak";
            lblPetak.Text = "Petak";
            lblSubota.Text = "Subota";
            lblNedjelja.Text = "Nedjelja";
            DateTime prviDanTjedna = FirstDateOfWeekISO8601(2019, int.Parse(domTjedan.Text));
            lblDatum.Text = prviDanTjedna.ToString("d.M.yyyy") + " - " + prviDanTjedna.AddDays(6).ToString("d.M.yyyy");
            lblponedjeljak.Text += Environment.NewLine + prviDanTjedna.ToString("d.M.yyyy");
            lblUtorak.Text += Environment.NewLine + prviDanTjedna.AddDays(1).ToString("d.M.yyyy");
            lblSrijeda.Text += Environment.NewLine + prviDanTjedna.AddDays(2).ToString("d.M.yyyy");
            lblCetvrtak.Text += Environment.NewLine + prviDanTjedna.AddDays(3).ToString("d.M.yyyy");
            lblPetak.Text += Environment.NewLine + prviDanTjedna.AddDays(4).ToString("d.M.yyyy");
            lblSubota.Text += Environment.NewLine + prviDanTjedna.AddDays(5).ToString("d.M.yyyy");
            lblNedjelja.Text += Environment.NewLine + prviDanTjedna.AddDays(6).ToString("d.M.yyyy");
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            CistiLabele();
            PuniTablicu2();
        }
       
        private void PuniTablicu2() // Dnevni pregled
        {
            var labels = this.tableLayoutPanel2.Controls.OfType<Label>()
                          .Where(c => c.Name.StartsWith("lbl1"))
                          .ToList();
            List<Label> listaObojanihLabela = new List<Label>();

            using (var db = new evidencijaEntities())
            {
                var A = db.vezaDjelatnikRad.Where(x => x.id_djelatnik == 1).ToList();
                foreach (var item in A)
                {
                    if (item.danUMjesec == monthCalendar1.SelectionRange.Start.ToString("dd"))
                    {
                        foreach (var label in labels)
                        {                            
                            string sadrzi = "";
                            var pocetak = item.satPocetka;
                            var kraj = item.satKraja;
                            var sati = item.brojSati;
                            for (int i = int.Parse(pocetak) + 1; i < int.Parse(kraj); i++)
                            {
                                sadrzi = "lbl1A" + i.ToString() + "A";

                                if (label.Name.Contains("A" + item.satPocetka + "A") ||
                                label.Name.Contains(sadrzi))
                                {
                                    label.BackColor = Color.FromName(item.vrstaRada.boja);
                                }
                            }
                        }
                    }                          
                }
            }
        }

        private void domainUpDown2_SelectedItemChanged(object sender, EventArgs e)
        {            
            CistiLabele();
            PuniTablicu3();
        }

        private void PuniTablicu3() //Mjesečni pregled
        {
            var labels = this.tableLayoutPanel3.Controls.OfType<Label>()
                          .Where(c => c.Name.StartsWith("lbl"))
                          .ToList();

            using (var db = new evidencijaEntities())
            {
                var A = db.vezaDjelatnikRad.Where(x => x.id_djelatnik == 1).ToList();
                foreach (var item in A)
                {
                    foreach (var label in labels)
                    {
                        if (label.Name.Contains(item.danUMjesec))
                        {
                            if (item.mjesecUGodini == domMjesec.Text)
                            {
                                label.BackColor = Color.FromName(item.vrstaRada.boja);
                                label.Text = item.brojSati.ToString();
                            }                            
                        }
                    }
                }
            }
        }

        private void PuniDomain2()
        {
            DomainUpDown.DomainUpDownItemCollection mjeseci = this.domMjesec.Items;
            mjeseci.Add("siječanj");
            mjeseci.Add("veljača");
            mjeseci.Add("ožujak");
            mjeseci.Add("travanj");
            mjeseci.Add("svibanj");
            mjeseci.Add("lipanj");
            mjeseci.Add("srpanj");
            mjeseci.Add("kolovoz");
            mjeseci.Add("rujan");
            mjeseci.Add("listopad");
            mjeseci.Add("studeni");
            mjeseci.Add("prosinac");

            domMjesec.SelectedIndex = int.Parse(DateTime.Now.ToString("MM")) - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            unos noviUnos = new unos(djelatnikBindingSource.Current as djelatnik);
            noviUnos.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            unos noviUnos = new unos(djelatnikBindingSource.Current as djelatnik);
            noviUnos.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            unos noviUnos = new unos(djelatnikBindingSource.Current as djelatnik);
            noviUnos.Show();
            this.Hide();
        }
    }        
}

           

