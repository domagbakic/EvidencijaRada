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

            CistiDGV();
            
            PrikaziVrsteRada();
            DohvatiDjelatnike();

            PuniDomainTjedan();
            PuniDomainGodina();
            
            BojajDGV(); //bojanje vrsti rada

            DodajStupceMjesecDGV();
            DodajRedoveMjesecDGV();
            BojajMjesecDGV();

            DodajStupceTjedanDGV();
            DodajRedoveTjedanDGV();
            BojajTjedanDGV();

            DodajStupceDanDGV();
            DodajRedoveDanDGV();
            BojajDanDGV();
        }

        private void DodajStupceDanDGV()
        {
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.HeaderText = "Djelatnik";
            btnColumn.Name = "djelatnik";
            dgvDan.Columns.Add(btnColumn);
            dgvDan.Columns.Add("6", "06:00");
            dgvDan.Columns.Add("7", "07:00");
            dgvDan.Columns.Add("8", "08:00");
            dgvDan.Columns.Add("9", "09:00");
            dgvDan.Columns.Add("10", "10:00");
            dgvDan.Columns.Add("11", "11:00");
            dgvDan.Columns.Add("12", "12:00");
            dgvDan.Columns.Add("13", "13:00");
            dgvDan.Columns.Add("14", "14:00");
            dgvDan.Columns.Add("15", "15:00");
            dgvDan.Columns.Add("16", "16:00");
            dgvDan.Columns.Add("17", "17:00");
            dgvDan.Columns.Add("18", "18:00");
            dgvDan.Columns.Add("19", "19:00");
            dgvDan.Columns.Add("20", "20:00");
            dgvDan.Columns.Add("21", "21:00");
            dgvDan.Columns.Add("22", "22:00");
            dgvDan.Columns.Add("23", "23:00");

            foreach (DataGridViewColumn column in dgvDan.Columns)
            {
                if (column.Name != "djelatnik")
                {
                    column.Width = 44;
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                else
                {
                    column.Width = 80;
                }
            }
            dgvDan.Width = 876;
        }

        private void DodajRedoveDanDGV()
        {
            using (var db = new evidencijaEntities())
            {
                var listaDjelatnika = db.djelatnik.ToList();
                foreach (var djelatnik in listaDjelatnika)
                {
                    dgvDan.Rows.Add(djelatnik.ime + " " + djelatnik.prezime);
                }
            }
        }

        private void BojajDanDGV()
        {
            using (var db = new evidencijaEntities())
            {
                var listaVeza = db.vezaDjelatnikRad.ToList();
                foreach (var item in listaVeza)
                {
                    var pocetak = item.satPocetka;
                    var kraj = item.satKraja;
                    List<int> radnoVrijeme = new List<int>();
                    for (int i = int.Parse(pocetak); i < int.Parse(kraj); i++)
                    {
                        radnoVrijeme.Add(i);
                    }
                    foreach (DataGridViewColumn column in dgvDan.Columns)
                    {
                        foreach (DataGridViewRow row in dgvDan.Rows)
                        {
                            if (item.danUMjesec == monthCalendar1.SelectionRange.Start.ToString("dd"))
                            {
                                foreach (var sat in radnoVrijeme)
                                {
                                    if (column.Name == sat.ToString() && row.Cells[0].Value.ToString() == item.djelatnik.ime
                                + " " + item.djelatnik.prezime)
                                    {
                                        dgvDan[column.Index, row.Index].Style.BackColor = Color.FromName(item.vrstaRada.boja);                                        
                                        dgvDan[column.Index, row.Index].ToolTipText = item.vrstaRada.naziv;
                                    }
                                }
                            }
                        }
                    }

                }

            }
        }

        private void DodajStupceTjedanDGV()
        {
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.HeaderText = "Djelatnik";
            btnColumn.Name = "djelatnik";
            dgvTjedni.Columns.Add(btnColumn);
            dgvTjedni.Columns.Add("1", "Ponedjeljak");
            dgvTjedni.Columns.Add("2", "Utorak");
            dgvTjedni.Columns.Add("3", "Srijeda");
            dgvTjedni.Columns.Add("4", "Četvrtak");
            dgvTjedni.Columns.Add("5", "Petak");
            dgvTjedni.Columns.Add("6", "Subota");
            dgvTjedni.Columns.Add("7", "Nedjelja");
            
            foreach (DataGridViewColumn column in dgvTjedni.Columns)
            {
                if (column.Name != "djelatnik")
                {
                    column.Width = 80;
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    column.Width = 80;
                }
            }            
            dgvTjedni.Width = 644;
        }

        private void DodajRedoveTjedanDGV()
        {
            using (var db = new evidencijaEntities())
            {
                var listaDjelatnika = db.djelatnik.ToList();
                foreach (var djelatnik in listaDjelatnika)
                {
                    dgvTjedni.Rows.Add(djelatnik.ime + " " + djelatnik.prezime);
                }
            }
        }

        private void BojajTjedanDGV()
        {
            using (var db = new evidencijaEntities())
            {
                var listaVeza = db.vezaDjelatnikRad.ToList();
                foreach (var item in listaVeza)
                {
                    foreach (DataGridViewColumn column in dgvTjedni.Columns)
                    {
                        foreach (DataGridViewRow row in dgvTjedni.Rows)
                        {
                            if (column.Name.Contains(item.danUTjednu.ToString()) && row.Cells[0].Value.ToString() == item.djelatnik.ime
                                + " " + item.djelatnik.prezime)
                            {
                                if (item.tjedanUGodini.ToString() == domTjedan.Text)
                                {
                                    dgvTjedni[column.Index, row.Index].Style.BackColor = Color.FromName(item.vrstaRada.boja);
                                    dgvTjedni[column.Index, row.Index].Value = item.brojSati.ToString();
                                    dgvTjedni[column.Index, row.Index].ToolTipText = item.vrstaRada.naziv + Environment.NewLine +
                                        item.satPocetka + " - " + item.satKraja;
                                }
                            }
                        }
                    }

                }

            }
        }
        private void DodajStupceMjesecDGV()
        {
            dgvMjesecni.Columns.Clear();
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.HeaderText = "Djelatnik";
            btnColumn.Name = "djelatnik";
            dgvMjesecni.Columns.Add(btnColumn);
                        
            for (int i = 1; i < 10; i++)
            {
                dgvMjesecni.Columns.Add("0" + i.ToString(), i.ToString() + ".");
                dgvMjesecni.Columns["0" + i.ToString()].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (domMjesec.Text == "siječanj" || domMjesec.Text == "ožujak" || domMjesec.Text == "svibanj" ||
                domMjesec.Text == "srpanj" || domMjesec.Text == "kolovoz" || domMjesec.Text == "listopad" || 
                domMjesec.Text == "prosinac")
            {
                for (int i = 10; i < 32; i++)
                {
                    dgvMjesecni.Columns.Add(i.ToString(), i.ToString() + ".");
                    dgvMjesecni.Columns[i.ToString()].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            else if(domMjesec.Text == "travanj" || domMjesec.Text == "lipanj" || domMjesec.Text == "rujan" ||
                domMjesec.Text == "studeni")
            {
                for (int i = 10; i < 31; i++)
                {
                    dgvMjesecni.Columns.Add(i.ToString(), i.ToString() + ".");
                    dgvMjesecni.Columns[i.ToString()].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            else if(domMjesec.Text == "veljača")
            {
                for (int i = 10; i < 29; i++)
                {
                    dgvMjesecni.Columns.Add(i.ToString(), i.ToString() + ".");
                    dgvMjesecni.Columns[i.ToString()].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            
            foreach (DataGridViewColumn column in dgvMjesecni.Columns)
            {
                if (column.Name != "djelatnik")
                {
                    column.Width = 30;
                }
                else
                {
                    column.Width = 80;
                }
            }
            dgvMjesecni.Width = 1014;
        }

        private void DodajRedoveMjesecDGV()
        {            
            using (var db = new evidencijaEntities())
            {
                var listaDjelatnika = db.djelatnik.ToList();
                foreach (var djelatnik in listaDjelatnika)
                {
                    dgvMjesecni.Rows.Add(djelatnik.ime + " " + djelatnik.prezime);
                }                
            }
        }

        private void BojajMjesecDGV()
        {
            using (var db = new evidencijaEntities())
            {
                var listaVeza = db.vezaDjelatnikRad.ToList();
                foreach (var item in listaVeza)
                {
                    foreach (DataGridViewColumn column in dgvMjesecni.Columns)
                    {
                        foreach (DataGridViewRow row in dgvMjesecni.Rows)
                        {
                            if (column.Name.Contains(item.danUMjesec) && row.Cells[0].Value.ToString() == item.djelatnik.ime
                                + " " + item.djelatnik.prezime)
                            {
                                if (item.mjesecUGodini == domMjesec.Text)
                                {
                                    dgvMjesecni[column.Index, row.Index].Style.BackColor = Color.FromName(item.vrstaRada.boja);
                                    dgvMjesecni[column.Index, row.Index].Value = item.brojSati.ToString();
                                    dgvMjesecni[column.Index, row.Index].ToolTipText = item.vrstaRada.naziv + Environment.NewLine +
                                        item.satPocetka + " - " + item.satKraja; 
                                }
                            }
                        }
                    }
                    
                }
                
            }
        }

        private void CistiDGV()
        {
            //dnevni pregled
            for (int i = 0; i < dgvDan.Rows.Count; i++)
            {
                for (int j = 1; j < dgvDan.Columns.Count; j++)
                {
                    dgvDan[j, i].Value = "";
                    dgvDan[j, i].Style.BackColor = Color.FromName("Control");
                }
            }

            //mjesecni pregled
            for (int i = 0; i < dgvMjesecni.Rows.Count; i++)
            {
                for (int j = 1; j < dgvMjesecni.Columns.Count; j++)
                {
                    dgvMjesecni[j, i].Value = "";
                    dgvMjesecni[j, i].Style.BackColor = Color.FromName("Control");
                }
            }

            //tjedni pregled
            for (int i = 0; i < dgvTjedni.Rows.Count; i++)
            {
                for (int j = 1; j < dgvTjedni.Columns.Count; j++)
                {
                    dgvTjedni[j, i].Value = "";
                    dgvTjedni[j, i].Style.BackColor = Color.FromName("Control");
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
                DodajStupceMjesecDGV();
                DodajRedoveMjesecDGV();
                CistiDGV();
                BojajMjesecDGV();
            }
            else if (e.TabPage.Name == tjedniPregled.Name)
            {
                CistiDGV();
                BojajTjedanDGV();
            }
            else if (e.TabPage.Name == dnevniPregled.Name)
            {
                CistiDGV();
                BojajDanDGV();
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
            CistiDGV();
            BojajTjedanDGV();
            DateTime prviDanTjedna = FirstDateOfWeekISO8601(2019, int.Parse(domTjedan.Text));
            lblDatum.Text = prviDanTjedna.ToString("d.M.yyyy") + " - " + prviDanTjedna.AddDays(6).ToString("d.M.yyyy");            
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            CistiDGV();
            BojajDanDGV();
        }        

        private void domainUpDown2_SelectedItemChanged(object sender, EventArgs e)
        {
            DodajStupceMjesecDGV();
            DodajRedoveMjesecDGV();
            CistiDGV();
            BojajMjesecDGV();
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

        private void dgvMjesecni_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                using (var db = new evidencijaEntities())
                {
                    var A = db.djelatnik.ToList();
                    foreach (var item in A)
                    {
                        if ((item.ime + " " + item.prezime) == dgvMjesecni.CurrentCell.Value.ToString())
                        {
                            unos noviUnos = new unos(item as djelatnik);
                            noviUnos.Show();
                            this.Hide();
                        }
                    }
                }
            }
        }

        private void dgvTjedni_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                using (var db = new evidencijaEntities())
                {
                    var A = db.djelatnik.ToList();
                    foreach (var item in A)
                    {
                        if ((item.ime + " " + item.prezime) == dgvTjedni.CurrentCell.Value.ToString())
                        {
                            unos noviUnos = new unos(item as djelatnik);
                            noviUnos.Show();
                            this.Hide();
                        }
                    }
                }
            }
        }

        private void dgvDan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                using (var db = new evidencijaEntities())
                {
                    var A = db.djelatnik.ToList();
                    foreach (var item in A)
                    {
                        if ((item.ime + " " + item.prezime) == dgvDan.CurrentCell.Value.ToString())
                        {
                            unos noviUnos = new unos(item as djelatnik);
                            noviUnos.Show();
                            this.Hide();
                        }
                    }
                }
            }
        }

        private void dgvVrstaRada_SelectionChanged(object sender, EventArgs e)
        {
            dgvVrstaRada.ClearSelection();
        }

        private void dgvMjesecni_SelectionChanged(object sender, EventArgs e)
        {
            dgvMjesecni.ClearSelection();
        }

        private void dgvTjedni_SelectionChanged(object sender, EventArgs e)
        {
            dgvTjedni.ClearSelection();
        }

        private void dgvDan_SelectionChanged(object sender, EventArgs e)
        {
            dgvDan.ClearSelection();
        }

        int brojStupca = 0;
        int brojRetka = 0;
        
        private void dodajRedovnih8Sati715ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrziUnos(brojStupca, brojRetka);
        }

        private void BrziUnos(int stupac, int redak)
        {
            djelatnik odabraniDjelatnik = null;
            vrstaRada odabranaVrstaRada = null;
            using (var db = new evidencijaEntities())
            {
                var listaVrstiRada = db.vrstaRada.ToList();
                foreach (var vrsta in listaVrstiRada)
                {
                    if (vrsta.id == 1)
                    {
                        odabranaVrstaRada = vrsta;
                    }
                }
                var A = db.vezaDjelatnikRad.ToList();
                foreach (var item in A)
                {
                    if ((item.djelatnik.ime + " " + item.djelatnik.prezime) == dgvMjesecni[0, redak].Value.ToString())
                    {
                        odabraniDjelatnik = item.djelatnik as djelatnik;                        
                    }
                }
            }
            if (odabraniDjelatnik != null && odabranaVrstaRada != null)
            {
                UnosUBazu(odabraniDjelatnik, odabranaVrstaRada, stupac);
            }            
        }

        private void UnosUBazu(djelatnik odabraniDjelatnik, vrstaRada odabranaVrstaRada, int stupac)
        {
            using (var db = new evidencijaEntities())
            {                
                db.djelatnik.Attach(odabraniDjelatnik as djelatnik);
                db.vrstaRada.Attach(odabranaVrstaRada as vrstaRada);
                vezaDjelatnikRad DR = new vezaDjelatnikRad();
                DR.djelatnik = odabraniDjelatnik as djelatnik;
                DR.vrstaRada = odabranaVrstaRada as vrstaRada;
                int mjesecBroj = OdrediMjesec(domMjesec.Text);                
                DateTime datum = new DateTime(DateTime.Now.Year, mjesecBroj, int.Parse(dgvMjesecni.Columns[stupac].Name), 0, 0, 0);
                DR.pocetak = datum;
                DR.kraj = datum;
                DR.brojSati = 8;
                DR.danUTjednu = (int)datum.DayOfWeek;
                DR.tjedanUGodini = GetIso8601WeekOfYear(datum);
                DR.prviDatumTjedna = FirstDateOfWeekISO8601(int.Parse(datum.ToString("yyyy")),
                    GetIso8601WeekOfYear(datum));
                DR.satPocetka = "07";
                DR.satKraja = "15";
                DR.mjesecUGodini = datum.ToString("MMMM", new CultureInfo("hr-HR"));
                DR.danUMjesec = datum.ToString("dd");
                db.vezaDjelatnikRad.Add(DR);
                db.SaveChanges();
                MessageBox.Show("Potvrda brzog unosa!");
            }
            BojajMjesecDGV();
        }

        private int OdrediMjesec(string mjesec)
        {            
            switch (mjesec)
            {
                case "siječanj":
                    return 1;
                case "veljača":
                    return 2;
                case "ožujak":
                    return 3;
                case "travanj":
                    return 4;
                case "svibanj":
                    return 5;
                case "lipanj":
                    return 6;
                case "srpanj":
                    return 7;
                case "kolovoz":
                    return 8;
                case "rujan":
                    return 9;
                case "listopad":
                    return 10;
                case "studeni":
                    return 11;
                case "prosinac":
                    return 12;
                default:
                    return 0;
            }
        }

        private void dgvMjesecni_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dgvMjesecni.HitTest(e.X, e.Y);
                dgvMjesecni.ClearSelection();
                brojStupca = hti.ColumnIndex;
                brojRetka = hti.RowIndex;
            }
        }

        private void izbrišiUnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Jeste li sigurni da želite izbrisati unos?", "Upozorenje!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                BrzoBrisanje(brojStupca, brojRetka);
            }
        }

        private void BrisanjeUnosa(djelatnik odabraniDjelatnik, int stupac)
        {
            using (var db = new evidencijaEntities())
            {
                db.djelatnik.Attach(odabraniDjelatnik as djelatnik);
                var listaVeza = db.vezaDjelatnikRad.Where(x => x.djelatnik.id == odabraniDjelatnik.id).ToList();
                foreach (var item in listaVeza)
                {
                    int dan = 1;
                    int mjesec = 1;
                    int godina = 2019;
                    string datum = item.pocetak.ToString();
                    if (datum[1].ToString() == "." && datum[4].ToString() == ".") // 8.10.2019.
                    {
                        dan = int.Parse(datum.Substring(0, 1));
                        mjesec = int.Parse(datum.Substring(2, 2));
                        godina = int.Parse(datum.Substring(5, 4));
                    }
                    else if (datum[2].ToString() == "." && datum[5].ToString() == ".") // 18.10.2019.
                    {
                        dan = int.Parse(datum.Substring(0, 2));
                        mjesec = int.Parse(datum.Substring(3, 2));
                        godina = int.Parse(datum.Substring(6, 4));
                    }
                    else if (datum[1].ToString() == "." && datum[3].ToString() == ".") // 8.9.2019.
                    {
                        dan = int.Parse(datum.Substring(0, 1));
                        mjesec = int.Parse(datum.Substring(2, 1));
                        godina = int.Parse(datum.Substring(4, 4));
                    }
                    else if (datum[2].ToString() == "." && datum[4].ToString() == ".") // 18.9.2019.
                    {
                        dan = int.Parse(datum.Substring(0, 2));
                        mjesec = int.Parse(datum.Substring(3, 1));
                        godina = int.Parse(datum.Substring(5, 4));
                    }
                                        
                    int mjesecProvjera = OdrediMjesec(domMjesec.Text);
                    if (dan == int.Parse(dgvMjesecni.Columns[stupac].Name) && mjesec == mjesecProvjera 
                        && godina == DateTime.Now.Year)
                    {
                        db.vezaDjelatnikRad.Remove(item as vezaDjelatnikRad);
                        db.SaveChanges();
                    }
                    DodajStupceMjesecDGV();
                    DodajRedoveMjesecDGV();
                    CistiDGV();
                    BojajMjesecDGV();
                }
                
            }
        }

        private void BrzoBrisanje(int stupac, int redak)
        {
            djelatnik odabraniDjelatnik = null;
            using (var db = new evidencijaEntities())
            {
                var A = db.vezaDjelatnikRad.ToList();
                foreach (var item in A)
                {
                    if ((item.djelatnik.ime + " " + item.djelatnik.prezime) == dgvMjesecni[0, redak].Value.ToString())
                    {
                        odabraniDjelatnik = item.djelatnik as djelatnik;
                    }
                }
            }
            if (odabraniDjelatnik != null )
            {
                BrisanjeUnosa(odabraniDjelatnik, stupac);
            }
        }
    }    
}

           

