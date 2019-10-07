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
    public partial class unos : Form
    {
        private djelatnik odabraniDjelatnik;
        public unos(djelatnik djelatnik)
        {
            InitializeComponent();
            odabraniDjelatnik = djelatnik;
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            //ProvjeraDuplogUnosa(); TODO provjera duplog unosa
            vrstaRada odabranaVrsta = vrstaRadaBindingSource.Current as vrstaRada;

            Dodaj(odabraniDjelatnik, odabranaVrsta);

            glavnaForma gF = new glavnaForma();
            this.Hide();
            gF.ShowDialog();
            this.Close();
        }

        private void Dodaj(djelatnik odabraniDjelatnik, vrstaRada odabranaVrsta)
        {            
            if (txtBrojSati.Text != "")
            {
                try
                {
                    int temp = Convert.ToInt32(txtBrojSati.Text);
                }
                catch
                {
                    MessageBox.Show("Polje broj sati mora sadržavati samo brojeve!");
                    return;
                }
                using (var db = new evidencijaEntities())
                {
                    db.djelatnik.Attach(odabraniDjelatnik);
                    db.vrstaRada.Attach(odabranaVrsta);
                    vezaDjelatnikRad DR = new vezaDjelatnikRad();
                    DR.djelatnik = odabraniDjelatnik;
                    DR.vrstaRada = odabranaVrsta;
                    DR.pocetak = dtpDatum.Value;
                    DR.kraj = dtpDatum.Value;
                    DR.brojSati = int.Parse(txtBrojSati.Text);
                    DR.danUTjednu = dtpDatum.Value.ToString("dddd", new CultureInfo("hr-HR"));
                    DR.tjedanUGodini = GetIso8601WeekOfYear(dtpDatum.Value);
                    DR.prviDatumTjedna = FirstDateOfWeekISO8601(int.Parse(dtpDatum.Value.ToString("yyyy")),
                        GetIso8601WeekOfYear(dtpDatum.Value));
                    if (domVrijemeOd.SelectedIndex == 0 || domVrijemeOd.SelectedIndex == 1 ||
                        domVrijemeOd.SelectedIndex == 2 || domVrijemeOd.SelectedIndex == 3)
                    {
                        DR.satPocetka = domVrijemeOd.Text.Substring(0, 1);
                    }
                    else
                    {
                        DR.satPocetka = domVrijemeOd.Text.Substring(0, 2);
                    }
                    if (domVrijemeDo.SelectedIndex == 0 || domVrijemeDo.SelectedIndex == 1 ||
                        domVrijemeDo.SelectedIndex == 2 || domVrijemeDo.SelectedIndex == 3)
                    {
                        DR.satKraja = domVrijemeDo.Text.Substring(0, 1);
                    }
                    else
                    {
                        DR.satKraja = domVrijemeDo.Text.Substring(0, 2);
                    }
                    DR.mjesecUGodini = dtpDatum.Value.ToString("MMMM", new CultureInfo("hr-HR"));
                    DR.danUMjesec = dtpDatum.Value.ToString("dd");
                    db.vezaDjelatnikRad.Add(DR);
                    db.SaveChanges();
                    MessageBox.Show("Uspješno ste dodali unos u evidenciju.");
                }
            }
            else
            {
                MessageBox.Show("Unesite broj sati!");
            }
        }

        private void unos_Load(object sender, EventArgs e)
        {
            PuniCombobox();
            PuniVremena();
            txtBrojSati.Text = "8";
        }

        public static int GetIso8601WeekOfYear(DateTime time)
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

        public static DateTime FirstDateOfWeekISO8601(int year, int weekOfYear)
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

        private void PuniVremena()
        {
            DomainUpDown.DomainUpDownItemCollection vremenaOd = this.domVrijemeOd.Items;
            DomainUpDown.DomainUpDownItemCollection vremenaDo = this.domVrijemeDo.Items;
            vremenaOd.Add("6:00");
            vremenaOd.Add("7:00");
            vremenaOd.Add("8:00");
            vremenaOd.Add("9:00");
            vremenaOd.Add("10:00");
            vremenaOd.Add("11:00");
            vremenaOd.Add("12:00");
            vremenaOd.Add("13:00");
            vremenaOd.Add("14:00");
            vremenaOd.Add("15:00");
            vremenaOd.Add("16:00");
            vremenaOd.Add("17:00");
            vremenaOd.Add("18:00");
            vremenaOd.Add("19:00");
            vremenaOd.Add("20:00");
            vremenaOd.Add("21:00");
            vremenaOd.Add("22:00");
            vremenaOd.Add("23:00");
            vremenaDo.Add("00:00");
            domVrijemeOd.SelectedIndex = 1;
                        
            vremenaDo.Add("6:00");
            vremenaDo.Add("7:00");
            vremenaDo.Add("8:00");
            vremenaDo.Add("9:00");
            vremenaDo.Add("10:00");
            vremenaDo.Add("11:00");
            vremenaDo.Add("12:00");
            vremenaDo.Add("13:00");
            vremenaDo.Add("14:00");
            vremenaDo.Add("15:00");
            vremenaDo.Add("16:00");
            vremenaDo.Add("17:00");
            vremenaDo.Add("18:00");
            vremenaDo.Add("19:00");
            vremenaDo.Add("20:00");
            vremenaDo.Add("21:00");
            vremenaDo.Add("22:00");
            vremenaDo.Add("23:00");
            vremenaDo.Add("00:00");
            domVrijemeDo.SelectedIndex = 10;
        }

        private void PuniCombobox()
        {
            BindingList<vrstaRada> listaRada = new BindingList<vrstaRada>();
            using (var db = new evidencijaEntities())
            {
                listaRada = new BindingList<vrstaRada>(db.vrstaRada.ToList());
            }
            vrstaRadaBindingSource.DataSource = listaRada;
        }

        private void btnPovratak_Click(object sender, EventArgs e)
        {
            glavnaForma gF = new glavnaForma();
            this.Hide();
            gF.ShowDialog();
            this.Close();
        }

        private void ProvjeraDuplogUnosa() //TODO provjera duplih unosa
        {
            using (var db = new evidencijaEntities())
            {
                var A = db.vezaDjelatnikRad.Where(x => x.id_djelatnik == 1).ToList();
                foreach (var item in A)
                {
                    if (item.danUMjesec == dtpDatum.Value.ToString("dd"))
                    {
                        /*DialogResult dialogResult = MessageBox.Show("Već postoji unos za taj dan. Želite li nastaviti?", 
                            "Dupli unos", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            
                        }
                        else if (dialogResult == DialogResult.No)
                        {

                        }*/
                    }
                }
            }
        }

        private void domVrijemeOd_SelectedItemChanged(object sender, EventArgs e)
        {
           //TODO automatski mijenjaj polje broj sati ovisno kako se mijenja radno vrijeme
        }

        private void domVrijemeDo_SelectedItemChanged(object sender, EventArgs e)
        {
            //TODO automatski mijenjaj polje broj sati ovisno kako se mijenja radno vrijeme
        }
    }
}
