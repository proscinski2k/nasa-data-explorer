using System.Windows.Forms;

namespace win_forms
{
    partial class MainForm
    {
        private TabControl tabControl;
        private TabPage satellitesTab;
        private TabPage apodTab;
        private TabPage missionTab;
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.satellitesTab = new System.Windows.Forms.TabPage();
            this.textBoxSatelliteInfo = new System.Windows.Forms.TextBox();
            this.comboBoxSatellites = new System.Windows.Forms.ComboBox();
            this.buttonGetSatellites = new System.Windows.Forms.Button();
            this.apodTab = new System.Windows.Forms.TabPage();
            this.textBoxAboutPictureOfDay = new System.Windows.Forms.TextBox();
            this.missionTab = new System.Windows.Forms.TabPage();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxOfDay = new System.Windows.Forms.PictureBox();
            this.comboBoxPojazd = new System.Windows.Forms.ComboBox();
            this.comboBoxMisja = new System.Windows.Forms.ComboBox();
            this.buttonPrintResult = new System.Windows.Forms.Button();
            this.textBoxPojazdyMisje = new System.Windows.Forms.TextBox();
            this.LabelPojazd = new System.Windows.Forms.Label();
            this.LabelMisja = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.satellitesTab.SuspendLayout();
            this.apodTab.SuspendLayout();
            this.missionTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOfDay)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.satellitesTab);
            this.tabControl.Controls.Add(this.apodTab);
            this.tabControl.Controls.Add(this.missionTab);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(776, 426);
            this.tabControl.TabIndex = 3;
            // 
            // satellitesTab
            // 
            this.satellitesTab.Controls.Add(this.pictureBox1);
            this.satellitesTab.Controls.Add(this.textBoxSatelliteInfo);
            this.satellitesTab.Controls.Add(this.comboBoxSatellites);
            this.satellitesTab.Controls.Add(this.buttonGetSatellites);
            this.satellitesTab.Location = new System.Drawing.Point(4, 22);
            this.satellitesTab.Name = "satellitesTab";
            this.satellitesTab.Padding = new System.Windows.Forms.Padding(3);
            this.satellitesTab.Size = new System.Drawing.Size(768, 400);
            this.satellitesTab.TabIndex = 0;
            this.satellitesTab.Text = "Satelity";
            this.satellitesTab.UseVisualStyleBackColor = true;
            // 
            // textBoxSatelliteInfo
            // 
            this.textBoxSatelliteInfo.Location = new System.Drawing.Point(211, 202);
            this.textBoxSatelliteInfo.Multiline = true;
            this.textBoxSatelliteInfo.Name = "textBoxSatelliteInfo";
            this.textBoxSatelliteInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSatelliteInfo.Size = new System.Drawing.Size(551, 188);
            this.textBoxSatelliteInfo.TabIndex = 2;
            // 
            // listBoxSatellites
            // 
            this.comboBoxSatellites.Location = new System.Drawing.Point(6, 35);
            this.comboBoxSatellites.Name = "comboBoxSatellites";
            this.comboBoxSatellites.Size = new System.Drawing.Size(199, 21); // Wysokość standardowa dla ComboBox
            this.comboBoxSatellites.TabIndex = 1;
            this.comboBoxSatellites.SelectedIndexChanged += new System.EventHandler(this.comboBoxSatellites_SelectedIndexChanged);
            // 
            // buttonGetSatellites
            // 
            this.buttonGetSatellites.Location = new System.Drawing.Point(6, 6);
            this.buttonGetSatellites.Name = "buttonGetSatellites";
            this.buttonGetSatellites.Size = new System.Drawing.Size(199, 23);
            this.buttonGetSatellites.TabIndex = 0;
            this.buttonGetSatellites.Text = "Pobierz satelity";
            this.buttonGetSatellites.UseVisualStyleBackColor = true;
            this.buttonGetSatellites.Click += new System.EventHandler(this.buttonGetSatellites_Click);
            // 
            // apodTab
            // 
            this.apodTab.Controls.Add(this.textBoxAboutPictureOfDay);
            this.apodTab.Controls.Add(this.pictureBoxOfDay);
            this.apodTab.Location = new System.Drawing.Point(4, 22);
            this.apodTab.Name = "apodTab";
            this.apodTab.Padding = new System.Windows.Forms.Padding(3);
            this.apodTab.Size = new System.Drawing.Size(768, 400);
            this.apodTab.TabIndex = 1;
            this.apodTab.Text = "Zdjęcie dnia";
            this.apodTab.UseVisualStyleBackColor = true;
            // 
            // textBoxAboutPictureOfDay
            // 
            this.textBoxAboutPictureOfDay.Location = new System.Drawing.Point(7, 221);
            this.textBoxAboutPictureOfDay.Multiline = true;
            this.textBoxAboutPictureOfDay.Name = "textBoxAboutPictureOfDay";
            this.textBoxAboutPictureOfDay.Size = new System.Drawing.Size(755, 173);
            this.textBoxAboutPictureOfDay.TabIndex = 1;
            this.textBoxAboutPictureOfDay.Text = "Wczytywanie...";
            // 
            // missionTab
            // 
            this.missionTab.Controls.Add(this.LabelMisja);
            this.missionTab.Controls.Add(this.LabelPojazd);
            this.missionTab.Controls.Add(this.textBoxPojazdyMisje);
            this.missionTab.Controls.Add(this.buttonPrintResult);
            this.missionTab.Controls.Add(this.comboBoxMisja);
            this.missionTab.Controls.Add(this.comboBoxPojazd);
            this.missionTab.Location = new System.Drawing.Point(4, 22);
            this.missionTab.Name = "missionTab";
            this.missionTab.Padding = new System.Windows.Forms.Padding(3);
            this.missionTab.Size = new System.Drawing.Size(768, 400);
            this.missionTab.TabIndex = 2;
            this.missionTab.Text = "Misje";
            this.missionTab.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(211, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(551, 190);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBoxOfDay
            // 
            this.pictureBoxOfDay.AccessibleName = "Możliwe, że zdjęcie dnia się nie pokaże, gdy elementem dnia będzie film lub inny " +
    "element.";
            this.pictureBoxOfDay.ErrorImage = global::win_forms.Properties.Resources.nasa_photo;
            this.pictureBoxOfDay.InitialImage = global::win_forms.Properties.Resources.LogoNasa1;
            this.pictureBoxOfDay.Location = new System.Drawing.Point(6, 6);
            this.pictureBoxOfDay.Name = "pictureBoxOfDay";
            this.pictureBoxOfDay.Size = new System.Drawing.Size(756, 208);
            this.pictureBoxOfDay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxOfDay.TabIndex = 0;
            this.pictureBoxOfDay.TabStop = false;
            // 
            // comboBoxPojazd
            // 
            this.comboBoxPojazd.FormattingEnabled = true;
            this.comboBoxPojazd.Location = new System.Drawing.Point(6, 22);
            this.comboBoxPojazd.Name = "comboBoxPojazd";
            this.comboBoxPojazd.Size = new System.Drawing.Size(149, 21);
            this.comboBoxPojazd.TabIndex = 1;
            this.comboBoxPojazd.SelectedIndexChanged += new System.EventHandler(this.comboBoxPojazd_SelectedIndexChanged);

            // 
            // comboBoxMisja
            // 
            this.comboBoxMisja.FormattingEnabled = true;
            this.comboBoxMisja.Location = new System.Drawing.Point(6, 71);
            this.comboBoxMisja.Name = "comboBoxMisja";
            this.comboBoxMisja.Size = new System.Drawing.Size(149, 21);
            this.comboBoxMisja.TabIndex = 2;
            this.comboBoxMisja.Enabled = false;
            this.comboBoxMisja.SelectedIndexChanged += new System.EventHandler(this.comboBoxMisja_SelectedIndexChanged);
            // 
            // buttonPrintResult
            // 
            this.buttonPrintResult.Location = new System.Drawing.Point(6, 107);
            this.buttonPrintResult.Name = "buttonPrintResult";
            this.buttonPrintResult.Size = new System.Drawing.Size(149, 23);
            this.buttonPrintResult.TabIndex = 3;
            this.buttonPrintResult.Text = "Drukuj wynik";
            this.buttonPrintResult.UseVisualStyleBackColor = true;
            this.buttonPrintResult.Click += new System.EventHandler(this.buttonPrintResult_Click);
            this.buttonPrintResult.Enabled = false;
            // 
            // textBoxPojazdyMisje
            // 
            this.textBoxPojazdyMisje.Location = new System.Drawing.Point(161, 6);
            this.textBoxPojazdyMisje.Multiline = true;
            this.textBoxPojazdyMisje.Name = "textBoxPojazdyMisje";
            this.textBoxPojazdyMisje.Size = new System.Drawing.Size(601, 388);
            this.textBoxPojazdyMisje.TabIndex = 4;
            // 
            // LabelPojazd
            // 
            this.LabelPojazd.AutoSize = true;
            this.LabelPojazd.Location = new System.Drawing.Point(6, 6);
            this.LabelPojazd.Name = "LabelPojazd";
            this.LabelPojazd.Size = new System.Drawing.Size(39, 13);
            this.LabelPojazd.TabIndex = 5;
            this.LabelPojazd.Text = "Pojazd";
            // 
            // LabelMisja
            // 
            this.LabelMisja.AutoSize = true;
            this.LabelMisja.Location = new System.Drawing.Point(6, 55);
            this.LabelMisja.Name = "LabelMisja";
            this.LabelMisja.Size = new System.Drawing.Size(31, 13);
            this.LabelMisja.TabIndex = 6;
            this.LabelMisja.Text = "Misja";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "NASA Data Explorer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.satellitesTab.ResumeLayout(false);
            this.satellitesTab.PerformLayout();
            this.apodTab.ResumeLayout(false);
            this.apodTab.PerformLayout();
            this.missionTab.ResumeLayout(false);
            this.missionTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOfDay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Button buttonGetSatellites;
        private PictureBox pictureBox1;
        private TextBox textBoxSatelliteInfo;
        private ComboBox comboBoxSatellites;
        private TextBox textBoxAboutPictureOfDay;
        private PictureBox pictureBoxOfDay;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private Label LabelPojazd;
        private TextBox textBoxPojazdyMisje;
        private Button buttonPrintResult;
        private ComboBox comboBoxMisja;
        private ComboBox comboBoxPojazd;
        private Label LabelMisja;
    }
}

