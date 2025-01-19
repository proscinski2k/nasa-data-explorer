using System.Windows.Forms;
using System.Net.Http;
using System;
using System.Drawing;
using System.Threading.Tasks;
using win_forms.responses;

namespace win_forms
{
    public partial class SplashScreen : Form
    {
        private Timer timer;
        private Label lblTitle;
        private Label lblStatus;
        private PictureBox pictureBox;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private readonly HttpClient httpClient;

        public SplashScreen()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;

            this.StartPosition = FormStartPosition.CenterScreen;

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Client-Token", "token");

            timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += Timer_Tick;
        }

        private async Task<SystemInfoModel> CheckApiAvailability()
        {
            try
            {
                string apiUrl = "https://localhost:7015/api/System/status";

                var response = await httpClient.GetAsync(apiUrl);
                return new SystemInfoModel(response);
            }
            catch (Exception)
            {
                return new SystemInfoModel();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Black;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(138, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(324, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "NASA Data Explorer";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(224, 60);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(133, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Sprawdzanie połączenia...";
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Image = global::win_forms.Properties.Resources.nasa_photo;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(584, 361);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(368, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Autorzy: Adrian Prościński | Yevhenii Soliuk";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "V 1.0";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(0, 316);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 45);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "";
            // 
            // SplashScreen
            // 
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pictureBox);
            this.Name = "SplashScreen";
            this.Load += new System.EventHandler(this.SplashScreen_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private async void SplashScreen_Load_1(object sender, EventArgs e)
        {
            SystemInfoModel systemInfo = await CheckApiAvailability();

            Label lblStatus = (Label)Controls.Find("lblStatus", true)[0];
            if (systemInfo.IsWebApiAvailable && systemInfo.IsNasaApiAvailable)
            {
                lblStatus.Text = $"Serwer NASA APIs dostępny";
                lblStatus.ForeColor = Color.Green;
                timer.Start();
            }
            else
            {
                lblStatus.Text = "Serwer NASA APIs niedostępny";
                lblStatus.ForeColor = Color.Red;
                await Task.Delay(2000);
                Application.Exit();
            }
        }
    }
}
