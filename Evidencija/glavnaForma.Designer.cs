namespace Evidencija
{
    partial class glavnaForma
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(glavnaForma));
            this.dgvVrstaRada = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nazivDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.boja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vezaDjelatnikRadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vrstaRadaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pregledEvidencija = new System.Windows.Forms.TabControl();
            this.mjesecniPregled = new System.Windows.Forms.TabPage();
            this.dgvMjesecni = new System.Windows.Forms.DataGridView();
            this.menuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dodajRedovnih8Sati715ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label21 = new System.Windows.Forms.Label();
            this.domMjesec = new System.Windows.Forms.DomainUpDown();
            this.tjedniPregled = new System.Windows.Forms.TabPage();
            this.dgvTjedni = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDatum = new System.Windows.Forms.Label();
            this.domTjedan = new System.Windows.Forms.DomainUpDown();
            this.dnevniPregled = new System.Windows.Forms.TabPage();
            this.dgvDan = new System.Windows.Forms.DataGridView();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.button4 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.djelatnikBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vezaDjelatnikRadBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.izbrišiUnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVrstaRada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vrstaRadaBindingSource)).BeginInit();
            this.pregledEvidencija.SuspendLayout();
            this.mjesecniPregled.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMjesecni)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.tjedniPregled.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTjedni)).BeginInit();
            this.dnevniPregled.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.djelatnikBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vezaDjelatnikRadBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVrstaRada
            // 
            this.dgvVrstaRada.AllowUserToAddRows = false;
            this.dgvVrstaRada.AllowUserToDeleteRows = false;
            this.dgvVrstaRada.AllowUserToResizeColumns = false;
            this.dgvVrstaRada.AllowUserToResizeRows = false;
            this.dgvVrstaRada.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvVrstaRada.AutoGenerateColumns = false;
            this.dgvVrstaRada.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVrstaRada.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVrstaRada.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVrstaRada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVrstaRada.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.nazivDataGridViewTextBoxColumn,
            this.boja,
            this.vezaDjelatnikRadDataGridViewTextBoxColumn});
            this.dgvVrstaRada.DataSource = this.vrstaRadaBindingSource;
            this.dgvVrstaRada.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvVrstaRada.Location = new System.Drawing.Point(22, 51);
            this.dgvVrstaRada.Name = "dgvVrstaRada";
            this.dgvVrstaRada.ReadOnly = true;
            this.dgvVrstaRada.RowHeadersVisible = false;
            this.dgvVrstaRada.Size = new System.Drawing.Size(173, 265);
            this.dgvVrstaRada.TabIndex = 1;
            this.dgvVrstaRada.SelectionChanged += new System.EventHandler(this.dgvVrstaRada_SelectionChanged);
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "id";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            this.idDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idDataGridViewTextBoxColumn1.Visible = false;
            // 
            // nazivDataGridViewTextBoxColumn
            // 
            this.nazivDataGridViewTextBoxColumn.DataPropertyName = "naziv";
            this.nazivDataGridViewTextBoxColumn.HeaderText = "Vrsta rada";
            this.nazivDataGridViewTextBoxColumn.Name = "nazivDataGridViewTextBoxColumn";
            this.nazivDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // boja
            // 
            this.boja.DataPropertyName = "boja";
            this.boja.HeaderText = "Boja";
            this.boja.Name = "boja";
            this.boja.ReadOnly = true;
            // 
            // vezaDjelatnikRadDataGridViewTextBoxColumn
            // 
            this.vezaDjelatnikRadDataGridViewTextBoxColumn.DataPropertyName = "vezaDjelatnikRad";
            this.vezaDjelatnikRadDataGridViewTextBoxColumn.HeaderText = "vezaDjelatnikRad";
            this.vezaDjelatnikRadDataGridViewTextBoxColumn.Name = "vezaDjelatnikRadDataGridViewTextBoxColumn";
            this.vezaDjelatnikRadDataGridViewTextBoxColumn.ReadOnly = true;
            this.vezaDjelatnikRadDataGridViewTextBoxColumn.Visible = false;
            // 
            // vrstaRadaBindingSource
            // 
            this.vrstaRadaBindingSource.DataSource = typeof(Evidencija.vrstaRada);
            // 
            // pregledEvidencija
            // 
            this.pregledEvidencija.Controls.Add(this.mjesecniPregled);
            this.pregledEvidencija.Controls.Add(this.tjedniPregled);
            this.pregledEvidencija.Controls.Add(this.dnevniPregled);
            this.pregledEvidencija.Location = new System.Drawing.Point(216, 51);
            this.pregledEvidencija.Name = "pregledEvidencija";
            this.pregledEvidencija.SelectedIndex = 0;
            this.pregledEvidencija.Size = new System.Drawing.Size(1143, 269);
            this.pregledEvidencija.TabIndex = 0;
            // 
            // mjesecniPregled
            // 
            this.mjesecniPregled.BackColor = System.Drawing.SystemColors.Control;
            this.mjesecniPregled.Controls.Add(this.dgvMjesecni);
            this.mjesecniPregled.Controls.Add(this.label21);
            this.mjesecniPregled.Controls.Add(this.domMjesec);
            this.mjesecniPregled.Location = new System.Drawing.Point(4, 22);
            this.mjesecniPregled.Name = "mjesecniPregled";
            this.mjesecniPregled.Padding = new System.Windows.Forms.Padding(3);
            this.mjesecniPregled.Size = new System.Drawing.Size(1135, 243);
            this.mjesecniPregled.TabIndex = 2;
            this.mjesecniPregled.Text = "Mjesečni pregled";
            // 
            // dgvMjesecni
            // 
            this.dgvMjesecni.AllowUserToAddRows = false;
            this.dgvMjesecni.AllowUserToDeleteRows = false;
            this.dgvMjesecni.AllowUserToResizeColumns = false;
            this.dgvMjesecni.AllowUserToResizeRows = false;
            this.dgvMjesecni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMjesecni.ContextMenuStrip = this.menuStrip;
            this.dgvMjesecni.Location = new System.Drawing.Point(28, 75);
            this.dgvMjesecni.Name = "dgvMjesecni";
            this.dgvMjesecni.ReadOnly = true;
            this.dgvMjesecni.RowHeadersVisible = false;
            this.dgvMjesecni.Size = new System.Drawing.Size(1023, 143);
            this.dgvMjesecni.TabIndex = 3;
            this.dgvMjesecni.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMjesecni_CellClick);
            this.dgvMjesecni.SelectionChanged += new System.EventHandler(this.dgvMjesecni_SelectionChanged);
            this.dgvMjesecni.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvMjesecni_MouseDown);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajRedovnih8Sati715ToolStripMenuItem,
            this.izbrišiUnosToolStripMenuItem});
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(226, 70);
            // 
            // dodajRedovnih8Sati715ToolStripMenuItem
            // 
            this.dodajRedovnih8Sati715ToolStripMenuItem.Name = "dodajRedovnih8Sati715ToolStripMenuItem";
            this.dodajRedovnih8Sati715ToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.dodajRedovnih8Sati715ToolStripMenuItem.Text = "Dodaj redovnih 8 sati (7 - 15)";
            this.dodajRedovnih8Sati715ToolStripMenuItem.Click += new System.EventHandler(this.dodajRedovnih8Sati715ToolStripMenuItem_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(25, 31);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(44, 13);
            this.label21.TabIndex = 2;
            this.label21.Text = "Mjesec:";
            // 
            // domMjesec
            // 
            this.domMjesec.Location = new System.Drawing.Point(75, 29);
            this.domMjesec.Name = "domMjesec";
            this.domMjesec.ReadOnly = true;
            this.domMjesec.Size = new System.Drawing.Size(85, 20);
            this.domMjesec.TabIndex = 1;
            this.domMjesec.Text = "domainUpDown2";
            this.domMjesec.SelectedItemChanged += new System.EventHandler(this.domainUpDown2_SelectedItemChanged);
            // 
            // tjedniPregled
            // 
            this.tjedniPregled.BackColor = System.Drawing.SystemColors.Control;
            this.tjedniPregled.Controls.Add(this.dgvTjedni);
            this.tjedniPregled.Controls.Add(this.label8);
            this.tjedniPregled.Controls.Add(this.lblDatum);
            this.tjedniPregled.Controls.Add(this.domTjedan);
            this.tjedniPregled.Location = new System.Drawing.Point(4, 22);
            this.tjedniPregled.Name = "tjedniPregled";
            this.tjedniPregled.Padding = new System.Windows.Forms.Padding(3);
            this.tjedniPregled.Size = new System.Drawing.Size(1135, 243);
            this.tjedniPregled.TabIndex = 0;
            this.tjedniPregled.Text = "Tjedni pregled";
            // 
            // dgvTjedni
            // 
            this.dgvTjedni.AllowUserToAddRows = false;
            this.dgvTjedni.AllowUserToDeleteRows = false;
            this.dgvTjedni.AllowUserToResizeColumns = false;
            this.dgvTjedni.AllowUserToResizeRows = false;
            this.dgvTjedni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTjedni.Location = new System.Drawing.Point(28, 69);
            this.dgvTjedni.Name = "dgvTjedni";
            this.dgvTjedni.ReadOnly = true;
            this.dgvTjedni.RowHeadersVisible = false;
            this.dgvTjedni.Size = new System.Drawing.Size(663, 150);
            this.dgvTjedni.TabIndex = 13;
            this.dgvTjedni.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTjedni_CellClick);
            this.dgvTjedni.SelectionChanged += new System.EventHandler(this.dgvTjedni_SelectionChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Tjedan:";
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Location = new System.Drawing.Point(160, 32);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(38, 13);
            this.lblDatum.TabIndex = 11;
            this.lblDatum.Text = "Datum";
            // 
            // domTjedan
            // 
            this.domTjedan.Location = new System.Drawing.Point(74, 30);
            this.domTjedan.Name = "domTjedan";
            this.domTjedan.ReadOnly = true;
            this.domTjedan.Size = new System.Drawing.Size(55, 20);
            this.domTjedan.TabIndex = 10;
            this.domTjedan.Text = "domainUpDown1";
            this.domTjedan.SelectedItemChanged += new System.EventHandler(this.domainUpDown1_SelectedItemChanged);
            // 
            // dnevniPregled
            // 
            this.dnevniPregled.BackColor = System.Drawing.SystemColors.Control;
            this.dnevniPregled.Controls.Add(this.dgvDan);
            this.dnevniPregled.Controls.Add(this.monthCalendar1);
            this.dnevniPregled.Location = new System.Drawing.Point(4, 22);
            this.dnevniPregled.Name = "dnevniPregled";
            this.dnevniPregled.Padding = new System.Windows.Forms.Padding(3);
            this.dnevniPregled.Size = new System.Drawing.Size(1135, 243);
            this.dnevniPregled.TabIndex = 1;
            this.dnevniPregled.Text = "Dnevni pregled";
            // 
            // dgvDan
            // 
            this.dgvDan.AllowUserToAddRows = false;
            this.dgvDan.AllowUserToDeleteRows = false;
            this.dgvDan.AllowUserToResizeColumns = false;
            this.dgvDan.AllowUserToResizeRows = false;
            this.dgvDan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDan.Location = new System.Drawing.Point(230, 26);
            this.dgvDan.Name = "dgvDan";
            this.dgvDan.ReadOnly = true;
            this.dgvDan.RowHeadersVisible = false;
            this.dgvDan.Size = new System.Drawing.Size(603, 150);
            this.dgvDan.TabIndex = 2;
            this.dgvDan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDan_CellClick);
            this.dgvDan.SelectionChanged += new System.EventHandler(this.dgvDan_SelectionChanged);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(9, 22);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.ShowToday = false;
            this.monthCalendar1.ShowTodayCircle = false;
            this.monthCalendar1.TabIndex = 1;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(220, 18);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(109, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "Dodaj djelatnika";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // djelatnikBindingSource
            // 
            this.djelatnikBindingSource.DataSource = typeof(Evidencija.djelatnik);
            // 
            // vezaDjelatnikRadBindingSource
            // 
            this.vezaDjelatnikRadBindingSource.DataSource = typeof(Evidencija.vezaDjelatnikRad);
            // 
            // izbrišiUnosToolStripMenuItem
            // 
            this.izbrišiUnosToolStripMenuItem.Name = "izbrišiUnosToolStripMenuItem";
            this.izbrišiUnosToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.izbrišiUnosToolStripMenuItem.Text = "Izbriši unos";
            this.izbrišiUnosToolStripMenuItem.Click += new System.EventHandler(this.izbrišiUnosToolStripMenuItem_Click);
            // 
            // glavnaForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 333);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.pregledEvidencija);
            this.Controls.Add(this.dgvVrstaRada);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "glavnaForma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evidencija rada";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVrstaRada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vrstaRadaBindingSource)).EndInit();
            this.pregledEvidencija.ResumeLayout(false);
            this.mjesecniPregled.ResumeLayout(false);
            this.mjesecniPregled.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMjesecni)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.tjedniPregled.ResumeLayout(false);
            this.tjedniPregled.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTjedni)).EndInit();
            this.dnevniPregled.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.djelatnikBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vezaDjelatnikRadBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource djelatnikBindingSource;
        private System.Windows.Forms.DataGridView dgvVrstaRada;
        private System.Windows.Forms.BindingSource vrstaRadaBindingSource;
        private System.Windows.Forms.BindingSource vezaDjelatnikRadBindingSource;
        private System.Windows.Forms.TabControl pregledEvidencija;
        private System.Windows.Forms.TabPage tjedniPregled;
        private System.Windows.Forms.TabPage dnevniPregled;
        private System.Windows.Forms.DomainUpDown domTjedan;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.TabPage mjesecniPregled;
        private System.Windows.Forms.DomainUpDown domMjesec;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nazivDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn boja;
        private System.Windows.Forms.DataGridViewTextBoxColumn vezaDjelatnikRadDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView dgvMjesecni;
        private System.Windows.Forms.DataGridView dgvTjedni;
        private System.Windows.Forms.DataGridView dgvDan;
        private System.Windows.Forms.ContextMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem dodajRedovnih8Sati715ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izbrišiUnosToolStripMenuItem;
    }
}

