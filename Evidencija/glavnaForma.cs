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
            ShowWaitForm(); //preloader forma

            pregledEvidencija.Selected += new TabControlEventHandler(pregledEvidencija_Selected);

            CistiLabele();
            
            PrikaziVrsteRada();
            DohvatiDjelatnike();

            DodajRedoveMjesec();
            DodajRedoveTjedan();
            DodajRedoveDan();    
            
            BojajTablicuMjesec();
            BojajTablicuTjedan();
            BojajTablicuDan();    
            
            PuniDomainTjedan();
            PuniDomainGodina();
            DodajButtonEvente();
            BojajDGV(); //bojanje vrsti rada
        }

        private void CistiLabele()
        {
            //dnevni pregled
            var labels = this.tableLayoutPanel2.Controls.OfType<Label>()
                          .Where(c => c.Name.StartsWith("lbl"))
                          .ToList();

            foreach (var label in labels)
            {
                label.Text = "";
                label.BackColor = Color.FromName("Control");
            }

            //mjesecni pregled
            var labels2 = this.tableLayoutPanel3.Controls.OfType<Label>()
                          .Where(c => c.Name.StartsWith("lbl"))
                          .ToList();

            foreach (var label in labels2)
            {
                label.Text = "0";
                label.BackColor = Color.FromName("Control");
            }

            //tjedni pregled
            var labels3 = this.tableLayoutPanel1.Controls.OfType<Label>()
                          .Where(c => c.Name.Contains("A"))
                          .ToList();

            foreach (var label in labels3)
            {
                label.Text = "0";
                label.BackColor = Color.FromName("Control");
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

        private void DodajRedoveMjesec()
        {
            using (var db = new evidencijaEntities())
            {
                var djelatnici = db.djelatnik.ToList();
                foreach (var item in djelatnici)
                {
                    tableLayoutPanel3.Height = tableLayoutPanel3.Height + 60;
                    tableLayoutPanel3.RowCount = tableLayoutPanel3.RowCount + 1;
                    tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                    //generiram kontrole u redu
                    tableLayoutPanel3.Controls.Add(new Button()
                    {
                        Name = item.id.ToString(),
                        Text = item.ime + " " + item.prezime,
                        Size = new System.Drawing.Size(60, 50),
                        Margin = new Padding(0, 0, 0, 0)
                    }, 0, tableLayoutPanel3.RowCount - 1); ;
                    for (int i = 1; i < 32; i++)
                    {
                        if (i < 10)
                        {
                            tableLayoutPanel3.Controls.Add(new Label()
                            {
                                Name = "lbl" + item.id.ToString() + "A0" + i.ToString() + "A",
                                Text = "0",
                                Size = new System.Drawing.Size(32, 41),
                                AutoSize = false,
                                Margin = new Padding(0, 0, 0, 0),
                                TextAlign = ContentAlignment.MiddleCenter,
                                Dock = DockStyle.Fill
                            }, i, tableLayoutPanel3.RowCount - 1);
                        }
                        else if (i >= 10)
                        {
                            tableLayoutPanel3.Controls.Add(new Label()
                            {
                                Name = "lbl" + item.id.ToString() + "A" + i.ToString() + "A",
                                Text = "0",
                                Size = new System.Drawing.Size(32, 41),
                                AutoSize = false,
                                Margin = new Padding(0, 0, 0, 0),
                                TextAlign = ContentAlignment.MiddleCenter,
                                Dock = DockStyle.Fill
                            }, i, tableLayoutPanel3.RowCount - 1);
                        }
                    }
                }
            }
        }

        private void DodajRedoveTjedan()
        {
            using (var db = new evidencijaEntities())
            {
                var djelatnici = db.djelatnik.ToList();
                foreach (var item in djelatnici)
                {
                    tableLayoutPanel1.Height = tableLayoutPanel1.Height + 60;
                    tableLayoutPanel1.RowCount = tableLayoutPanel1.RowCount + 1;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                    //generiram kontrole u redu
                    tableLayoutPanel1.Controls.Add(new Button()
                    {
                        Name = item.id.ToString(),
                        Text = item.ime + " " + item.prezime,
                        Size = new System.Drawing.Size(60, 50),
                        Margin = new Padding(0, 0, 0, 0),
                        Dock = DockStyle.Fill
                    }, 0, tableLayoutPanel1.RowCount - 1); ;
                    for (int i = 1; i < 8; i++)
                    {
                        tableLayoutPanel1.Controls.Add(new Label()
                        {
                            Name = "lbl" + item.id.ToString() + "A" + i.ToString() + "A",
                            Text = "0",
                            Size = new System.Drawing.Size(32, 41),
                            AutoSize = false,
                            Margin = new Padding(0, 0, 0, 0),
                            TextAlign = ContentAlignment.MiddleCenter,
                            Dock = DockStyle.Fill
                        }, i, tableLayoutPanel1.RowCount - 1);
                    }
                }
            }

        }

        private void DodajRedoveDan()
        {
            using (var db = new evidencijaEntities())
            {
                var djelatnici = db.djelatnik.ToList();
                foreach (var item in djelatnici)
                {
                    tableLayoutPanel2.Height = tableLayoutPanel2.Height + 60;
                    tableLayoutPanel2.RowCount = tableLayoutPanel2.RowCount + 1;
                    tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                    //generiram kontrole u redu
                    tableLayoutPanel2.Controls.Add(new Button()
                    {
                        Name = item.id.ToString(),
                        Text = item.ime + " " + item.prezime,
                        Size = new System.Drawing.Size(60, 50),
                        Margin = new Padding(0, 0, 0, 0),
                        Dock = DockStyle.Fill
                    }, 0, tableLayoutPanel2.RowCount - 1); ;
                    for (int i = 1; i < 19; i++)
                    {
                        tableLayoutPanel2.Controls.Add(new Label()
                        {
                            Name = "lbl" + item.id.ToString() + "A" + (i + 5).ToString() + "A",
                            Text = "",
                            Size = new System.Drawing.Size(32, 41),
                            AutoSize = false,
                            Margin = new Padding(0, 0, 0, 0),
                            TextAlign = ContentAlignment.MiddleCenter,
                            Dock = DockStyle.Fill
                        }, i, tableLayoutPanel2.RowCount - 1);
                    }
                }
            }
        }

        private void BojajTablicuMjesec() //Mjesečni pregled
        {
            using (var db = new evidencijaEntities())
            {
                var listaVeza = db.vezaDjelatnikRad.ToList();
                foreach (var item in listaVeza)
                {
                    var labels = this.tableLayoutPanel3.Controls.OfType<Label>()
                          .Where(c => c.Name.StartsWith("lbl" + item.djelatnik.id))
                          .ToList();
                    foreach (var label in labels)
                    {
                        if (label.Name.Contains(item.danUMjesec))
                        {
                            if (item.mjesecUGodini == domMjesec.Text)
                            {
                                label.BackColor = Color.FromName(item.vrstaRada.boja);
                                label.Text = item.brojSati.ToString();
                                toolTip1.SetToolTip(label, item.vrstaRada.naziv + Environment.NewLine + 
                                    item.satPocetka.ToString() + " - " + item.satKraja.ToString());
                            }
                        }
                    }
                }
            }
        }

        private void BojajTablicuTjedan()
        {
            using (var db = new evidencijaEntities())
            {
                var listaVeza = db.vezaDjelatnikRad.ToList(); //dohvaćam sve veze i stavljam ih u listu
                foreach (var item in listaVeza)
                {
                    var labels = this.tableLayoutPanel1.Controls.OfType<Label>()
                          .Where(c => c.Name.StartsWith("lbl" + item.djelatnik.id))
                          .ToList();

                    foreach (var label in labels)
                    {
                        if (label.Name.Contains(item.danUTjednu.ToString()))
                        {
                            if (item.tjedanUGodini.ToString() == domTjedan.Text)
                            {
                                label.BackColor = Color.FromName(item.vrstaRada.boja);
                                label.Text = item.brojSati.ToString();
                                toolTip1.SetToolTip(label, item.vrstaRada.naziv + Environment.NewLine +
                                    item.satPocetka.ToString() + " - " + item.satKraja.ToString());
                            }
                        }
                    }
                }
            }
        }

        private void BojajTablicuDan() // Dnevni pregled
        {
            using (var db = new evidencijaEntities())
            {
                var listaVeza = db.vezaDjelatnikRad.ToList();
                foreach (var item in listaVeza)
                {
                    var labels = this.tableLayoutPanel2.Controls.OfType<Label>()
                          .Where(c => c.Name.StartsWith("lbl" + item.djelatnik.id))
                          .ToList();
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
                                sadrzi = "lbl" + item.djelatnik.id + "A" + i.ToString() + "A";

                                if (label.Name.Contains("A" + item.satPocetka + "A") ||
                                label.Name.Contains(sadrzi))
                                {
                                    label.BackColor = Color.FromName(item.vrstaRada.boja);
                                    toolTip1.SetToolTip(label, item.vrstaRada.naziv);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void PuniDomainTjedan() // Domain s tjednima
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

        private void PuniDomainGodina()
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

        private void DodajButtonEvente() //za svaki generirani button dodajem event kojim se omogućuje unos
        {
            var buttonsMjesec = this.tableLayoutPanel3.Controls.OfType<Button>().ToList();
            foreach (var button in buttonsMjesec)
            {
                button.Click += (s, e) => {
                    using (var db = new evidencijaEntities())
                    {
                        var A = db.djelatnik.ToList();
                        foreach (var item in A)
                        {
                            if (item.id.ToString() == button.Name)
                            {
                                unos noviUnos = new unos(item as djelatnik);
                                noviUnos.Show();
                                this.Hide();
                            }
                        }
                    }
                };
            }

            var buttonsTjedan = this.tableLayoutPanel1.Controls.OfType<Button>().ToList();
            foreach (var button in buttonsTjedan)
            {
                button.Click += (s, e) => {
                    using (var db = new evidencijaEntities())
                    {
                        var A = db.djelatnik.ToList();
                        foreach (var item in A)
                        {
                            if (item.id.ToString() == button.Name)
                            {
                                unos noviUnos = new unos(item as djelatnik);
                                noviUnos.Show();
                                this.Hide();
                            }
                        }
                    }
                };
            }

            var buttonsDan = this.tableLayoutPanel2.Controls.OfType<Button>().ToList();
            foreach (var button in buttonsDan)
            {
                button.Click += (s, e) => {
                    using (var db = new evidencijaEntities())
                    {
                        var A = db.djelatnik.ToList();
                        foreach (var item in A)
                        {
                            if (item.id.ToString() == button.Name)
                            {
                                unos noviUnos = new unos(item as djelatnik);
                                noviUnos.Show();
                                this.Hide();
                            }
                        }
                    }
                };
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

        private void pregledEvidencija_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Name == mjesecniPregled.Name)
            {
                CistiLabele();
                BojajTablicuMjesec();
            }
            else if (e.TabPage.Name == tjedniPregled.Name)
            {
                CistiLabele();
                BojajTablicuTjedan();
            }
            else if (e.TabPage.Name == dnevniPregled.Name)
            {
                CistiLabele();
                BojajTablicuDan();
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

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            CistiLabele();
            BojajTablicuTjedan();
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
            BojajTablicuDan();
        }        

        private void domainUpDown2_SelectedItemChanged(object sender, EventArgs e)
        {
            CistiLabele();
            BojajTablicuMjesec();
        }  

        private void button4_Click(object sender, EventArgs e) //Dodavanje zaposlenika
        {
            zaposlenik noviDjelatnik = new zaposlenik();
            noviDjelatnik.Show();
            this.Hide();
        }

        private preloader _waitForm; //preloader forma
        protected void ShowWaitForm()
        {
            // don't display more than one wait form at a time
            if (_waitForm != null && !_waitForm.IsDisposed)
            {
                return;
            }

            _waitForm = new preloader();
            _waitForm.TopMost = true;
            _waitForm.StartPosition = FormStartPosition.CenterScreen;
            _waitForm.Show();
            _waitForm.Refresh();

            // force the wait window to display for at least 700ms so it doesn't just flash on the screen
            System.Threading.Thread.Sleep(700);
            Application.Idle += OnLoaded;
        }

        private void OnLoaded(object sender, EventArgs e)
        {
            Application.Idle -= OnLoaded;
            _waitForm.Close();
        }
    }    
}

           

