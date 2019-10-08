using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evidencija
{
    public partial class zaposlenik : Form
    {
        public zaposlenik()
        {
            InitializeComponent();
        }

        private void btnPovratak_Click(object sender, EventArgs e)
        {
            glavnaForma gF = new glavnaForma();
            this.Hide();
            gF.ShowDialog();
            this.Close();
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            DodajDjelatnika();

            glavnaForma gF = new glavnaForma();
            this.Hide();
            gF.ShowDialog();
            this.Close();
        }

        private void DodajDjelatnika()
        {
            using (var db = new evidencijaEntities())
            {
                djelatnik noviDjelatnik = new djelatnik();
                noviDjelatnik.ime = txtIme.Text;
                noviDjelatnik.prezime = txtPrezime.Text;
                db.djelatnik.Add(noviDjelatnik);
                db.SaveChanges();
                MessageBox.Show("Uspješno ste dodali djelatnika.");
            }
        }
    }
}
