using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;
using win_forms.Properties;
using win_forms.responses;

namespace win_forms
{
    public partial class MainForm : Form
    {
        private readonly HttpClient _httpClient;
        public MainForm()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Client-Token", "token");
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           this.loadPictureOfDay();
            this.loadVehicles();
        }

        private async void loadVehicles()
        {
            buttonPrintResult.Text = "Drukuj wynik - pobieranie pojazdów...";
            var response = await _httpClient.GetAsync("https://localhost:7015/api/Osdr/vehicles");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<VehiclesResponse>(content);
            comboBoxPojazd.Items.Clear();

            foreach (var vehicle in result.data)
            {
                string vehicleName = vehicle.vehicle.Split('/').Last();
                vehicleName = HttpUtility.UrlDecode(vehicleName);

                var item = new VehicleItem
                {
                    Name = vehicleName,
                    Url = vehicle.vehicle
                };

                comboBoxPojazd.Items.Add(item);
            }

            comboBoxPojazd.DisplayMember = "Name";
            buttonPrintResult.Text = "Drukuj wynik";
        }

        private async void loadMissions() {
            buttonPrintResult.Text = "Drukuj wynik - pobieranie misji...";
            var selectedVehicle = (VehicleItem)comboBoxPojazd.SelectedItem;
            string vehicleUrl = selectedVehicle.Url;
            var response = await _httpClient.GetAsync($"https://localhost:7015/api/Osdr/vehicle?url={vehicleUrl}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<VehicleDetails>(content);
            comboBoxMisja.Items.Clear();

            foreach (var vehicleMission in result.parents.mission)
            {
                string missionName = vehicleMission.mission.Split('/').Last();
                missionName = HttpUtility.UrlDecode(missionName);

                var item = new VehicleItem
                {
                    Name = missionName,
                    Url = vehicleMission.mission
                };

                comboBoxMisja.Items.Add(item);
            }

            comboBoxPojazd.DisplayMember = "Name";
            buttonPrintResult.Text = "Drukuj wynik";
        }

        private async void loadPictureOfDay()
        {
            this.textBoxAboutPictureOfDay.Text = "Wczytywanie...";

            var response = await _httpClient.GetAsync($"https://localhost:7015/api/Apod");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var pictureOfDay = JsonSerializer.Deserialize<ApodResponse>(content);
            if (pictureOfDay.media_type == "image")
                pictureBoxOfDay.ImageLocation = pictureOfDay.url;
            else
                pictureBoxOfDay.Image = Properties.Resources.error;

            textBoxAboutPictureOfDay.Text = string.Format(
              "Tytuł: {0}\r\n" +
              "Url: {1}\r\n" +
              "Wersja serwisu: {2}\r\n" +
              "Data: {3}\r\n" +
              "Wyjaśnienie: {4}\r\n" +
              "Typ pliku: {5}\r\n",
              pictureOfDay.title,
              pictureOfDay.url,
              pictureOfDay.service_version,
              pictureOfDay.date,
              pictureOfDay.explanation,
              pictureOfDay.media_type
              );
        }

        private async void buttonGetSatellites_Click(object sender, EventArgs e)
        {
            buttonGetSatellites.Text = "Pobieranie satelit...";
            var response = await _httpClient.GetAsync("https://localhost:7015/api/Satellite");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<SatelliteSearchResponse>(content);
            comboBoxSatellites.Items.Clear();

            foreach (var satellite in result.Satellites)
            {
                comboBoxSatellites.Items.Add(satellite.Name);
            }
            buttonGetSatellites.Text = "Pobrano!";
        }

        private async void comboBoxSatellites_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSatellites.SelectedItem == null) return;

            string satelliteName = comboBoxSatellites.SelectedItem.ToString();

            var response = await _httpClient.GetAsync($"https://localhost:7015/api/Satellite/{satelliteName}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var satelliteDetails = JsonSerializer.Deserialize<SatelliteSearchResponse>(content);
            var satellite = satelliteDetails.Satellites[0];


            textBoxSatelliteInfo.Text = string.Format(
               "ID satelity: {0}\r\n" +
               "ResourceId: {1}\r\n" +
               "ResourceType: {2}\r\n" +
               "Nazwa satelity: {3}\r\n" +
               "TleLine1: {4}\r\n" +
               "TleLine2: {5}\r\n" +
               "Data aktualizacji: {6}",
               satellite.SatelliteId,
               satellite.ResourceId,
               satellite.ResourceType,
               satellite.Name,
               satellite.TleLine1,
               satellite.TleLine2,
               satellite.UpdateDate);
        }


        private async void comboBoxPojazd_SelectedIndexChanged(object sender, EventArgs e) {
            loadMissions();
            comboBoxMisja.SelectedItem = null;
            comboBoxMisja.Enabled = true;
            buttonPrintResult.Enabled = false;
        }
        private async void comboBoxMisja_SelectedIndexChanged(object sender, EventArgs e) {
            buttonPrintResult.Text = "Drukuj wynik - pobieranie danych z misji...";
            var selectedMission = (VehicleItem)comboBoxMisja.SelectedItem;
            if (selectedMission == null) return;
            string missionUrl = selectedMission.Url;
            var response = await _httpClient.GetAsync($"https://localhost:7015/api/Osdr/mission-details?url={missionUrl}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<MissionDetails>(content);

            buttonPrintResult.Text = "Drukuj wynik";
            var members = "";
            foreach (var member in result.people)
            {
                members = $"{members} \r\n {member.person.firstName} {member.person.middleName} {member.person.lastName} E-mail: {member.person.emailAddress} Tel: {member.person.phone} Instytut: {member.institution} Rola: {string.Join(" | ", member.roles)} ";
            }

            textBoxPojazdyMisje.Text = string.Format(
               "Identyfikator misji: {0}\r\n" +
               "Członkowie: {1}",
               result.identifier,
              members);

            buttonPrintResult.Enabled = true;
        }

        private async void buttonPrintResult_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (s, ev) =>
            {
                Font font = new Font("Arial", 12);
                ev.Graphics.DrawString(textBoxPojazdyMisje.Text, font, Brushes.Black, ev.MarginBounds);
            };

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK) printDocument.Print();
        }
    }
}

