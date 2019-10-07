namespace Evidencija
{
    partial class unos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbVrstaRada = new System.Windows.Forms.ComboBox();
            this.vrstaRadaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblVrijemeOd = new System.Windows.Forms.Label();
            this.lblVrijemeDo = new System.Windows.Forms.Label();
            this.domVrijemeOd = new System.Windows.Forms.DomainUpDown();
            this.domVrijemeDo = new System.Windows.Forms.DomainUpDown();
            this.txtBrojSati = new System.Windows.Forms.TextBox();
            this.lblSati = new System.Windows.Forms.Label();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.lblDatum = new System.Windows.Forms.Label();
            this.btnPovratak = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.vrstaRadaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vrsta rada: ";
            // 
            // cmbVrstaRada
            // 
            this.cmbVrstaRada.DataSource = this.vrstaRadaBindingSource;
            this.cmbVrstaRada.DisplayMember = "naziv";
            this.cmbVrstaRada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVrstaRada.FormattingEnabled = true;
            this.cmbVrstaRada.Location = new System.Drawing.Point(95, 27);
            this.cmbVrstaRada.Name = "cmbVrstaRada";
            this.cmbVrstaRada.Size = new System.Drawing.Size(164, 21);
            this.cmbVrstaRada.TabIndex = 1;
            this.cmbVrstaRada.ValueMember = "id";
            // 
            // vrstaRadaBindingSource
            // 
            this.vrstaRadaBindingSource.DataSource = typeof(Evidencija.vrstaRada);
            // 
            // lblVrijemeOd
            // 
            this.lblVrijemeOd.AutoSize = true;
            this.lblVrijemeOd.Location = new System.Drawing.Point(29, 100);
            this.lblVrijemeOd.Name = "lblVrijemeOd";
            this.lblVrijemeOd.Size = new System.Drawing.Size(59, 13);
            this.lblVrijemeOd.TabIndex = 2;
            this.lblVrijemeOd.Text = "Vrijeme od:";
            // 
            // lblVrijemeDo
            // 
            this.lblVrijemeDo.AutoSize = true;
            this.lblVrijemeDo.Location = new System.Drawing.Point(28, 133);
            this.lblVrijemeDo.Name = "lblVrijemeDo";
            this.lblVrijemeDo.Size = new System.Drawing.Size(59, 13);
            this.lblVrijemeDo.TabIndex = 3;
            this.lblVrijemeDo.Text = "Vrijeme do:";
            // 
            // domVrijemeOd
            // 
            this.domVrijemeOd.Location = new System.Drawing.Point(94, 98);
            this.domVrijemeOd.Name = "domVrijemeOd";
            this.domVrijemeOd.ReadOnly = true;
            this.domVrijemeOd.Size = new System.Drawing.Size(80, 20);
            this.domVrijemeOd.TabIndex = 4;
            this.domVrijemeOd.Text = "domainUpDown1";
            this.domVrijemeOd.SelectedItemChanged += new System.EventHandler(this.domVrijemeOd_SelectedItemChanged);
            // 
            // domVrijemeDo
            // 
            this.domVrijemeDo.Location = new System.Drawing.Point(93, 131);
            this.domVrijemeDo.Name = "domVrijemeDo";
            this.domVrijemeDo.ReadOnly = true;
            this.domVrijemeDo.Size = new System.Drawing.Size(80, 20);
            this.domVrijemeDo.TabIndex = 5;
            this.domVrijemeDo.Text = "domainUpDown1";
            this.domVrijemeDo.SelectedItemChanged += new System.EventHandler(this.domVrijemeDo_SelectedItemChanged);
            // 
            // txtBrojSati
            // 
            this.txtBrojSati.Location = new System.Drawing.Point(93, 164);
            this.txtBrojSati.Name = "txtBrojSati";
            this.txtBrojSati.Size = new System.Drawing.Size(44, 20);
            this.txtBrojSati.TabIndex = 6;
            // 
            // lblSati
            // 
            this.lblSati.AutoSize = true;
            this.lblSati.Location = new System.Drawing.Point(29, 167);
            this.lblSati.Name = "lblSati";
            this.lblSati.Size = new System.Drawing.Size(47, 13);
            this.lblSati.TabIndex = 7;
            this.lblSati.Text = "Broj sati:";
            // 
            // btnSpremi
            // 
            this.btnSpremi.Location = new System.Drawing.Point(184, 205);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(75, 23);
            this.btnSpremi.TabIndex = 8;
            this.btnSpremi.Text = "Spremi";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.btnSpremi_Click);
            // 
            // dtpDatum
            // 
            this.dtpDatum.Location = new System.Drawing.Point(95, 63);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(164, 20);
            this.dtpDatum.TabIndex = 9;
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Location = new System.Drawing.Point(29, 63);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(47, 13);
            this.lblDatum.TabIndex = 10;
            this.lblDatum.Text = "Broj sati:";
            // 
            // btnPovratak
            // 
            this.btnPovratak.Location = new System.Drawing.Point(32, 205);
            this.btnPovratak.Name = "btnPovratak";
            this.btnPovratak.Size = new System.Drawing.Size(75, 23);
            this.btnPovratak.TabIndex = 11;
            this.btnPovratak.Text = "Povratak";
            this.btnPovratak.UseVisualStyleBackColor = true;
            this.btnPovratak.Click += new System.EventHandler(this.btnPovratak_Click);
            // 
            // unos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 262);
            this.Controls.Add(this.btnPovratak);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.dtpDatum);
            this.Controls.Add(this.btnSpremi);
            this.Controls.Add(this.lblSati);
            this.Controls.Add(this.txtBrojSati);
            this.Controls.Add(this.domVrijemeDo);
            this.Controls.Add(this.domVrijemeOd);
            this.Controls.Add(this.lblVrijemeDo);
            this.Controls.Add(this.lblVrijemeOd);
            this.Controls.Add(this.cmbVrstaRada);
            this.Controls.Add(this.label1);
            this.Name = "unos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unos u evidenciju";
            this.Load += new System.EventHandler(this.unos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vrstaRadaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbVrstaRada;
        private System.Windows.Forms.Label lblVrijemeOd;
        private System.Windows.Forms.Label lblVrijemeDo;
        private System.Windows.Forms.DomainUpDown domVrijemeOd;
        private System.Windows.Forms.DomainUpDown domVrijemeDo;
        private System.Windows.Forms.TextBox txtBrojSati;
        private System.Windows.Forms.Label lblSati;
        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.BindingSource vrstaRadaBindingSource;
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.Button btnPovratak;
    }
}