using Car_Service_App.Helpers;
using Car_Service_App.Managers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Car_Service_App
{
    public partial class MainPage : Form
    {
        string connectionString = "Data Source=CarServiceApp.db;Version=3;";

        public MainPage()
        {
            InitializeComponent();

            var dbManager = new DatabaseManager(connectionString);
            dbManager.CreateDatabase();

            var musteriManager = new MusteriManager(connectionString);
            musteriManager.MusteriGetir(dgvMusteriler);

            BackupHelper.YazdirTxt(dgvMusteriler);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            var musteriManager = new MusteriManager(connectionString);
            string plaka = txtPlaka.Text;

            var islemler = new List<(CheckBox, string)>
            {
                (chkAdBlue, "AdBlue"),
                (chkDPF, "DPF"),
                (chkEGR, "EGR"),
                (chkStage1, "Stage 1"),
                (chkStage2, "Stage 2"),
                (chkOnOff, "On/Off"),
                (chkDtcOff, "DTC Off"),
                (chkAnahtarKopyalama, "Anahtar Kopyalama")
            };

            musteriManager.MusteriKaydet(plaka, islemler);
            musteriManager.MusteriGetir(dgvMusteriler);
            BackupHelper.YazdirTxt(dgvMusteriler);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvMusteriler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir müþteri seçin.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int musteriID = Convert.ToInt32(dgvMusteriler.SelectedRows[0].Cells["ID"].Value);
            var musteriManager = new MusteriManager(connectionString);

            musteriManager.MusteriSil(musteriID);

            MessageBox.Show("Müþteri baþarýyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            musteriManager.MusteriGetir(dgvMusteriler);
            BackupHelper.YazdirTxt(dgvMusteriler);
        }

        private void dgvMusteriler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMusteriler.SelectedRows.Count > 0)
            {
                int musteriID = Convert.ToInt32(dgvMusteriler.SelectedRows[0].Cells["ID"].Value);
                txtPlaka.Text = dgvMusteriler.SelectedRows[0].Cells["Plaka"].Value.ToString();

                foreach (var checkbox in new CheckBox[] { chkAdBlue, chkDPF, chkEGR, chkStage1, chkStage2, chkOnOff, chkDtcOff, chkAnahtarKopyalama })
                {
                    checkbox.Checked = false;
                }

                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT IslemAdi FROM Islemler WHERE MusteriID = @MusteriID;";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MusteriID", musteriID);
                    SQLiteDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string islemAdi = reader["IslemAdi"].ToString();
                        switch (islemAdi)
                        {
                            case "AdBlue": chkAdBlue.Checked = true; break;
                            case "DPF": chkDPF.Checked = true; break;
                            case "EGR": chkEGR.Checked = true; break;
                            case "Stage 1": chkStage1.Checked = true; break;
                            case "Stage 2": chkStage2.Checked = true; break;
                            case "On/Off": chkOnOff.Checked = true; break;
                            case "DTC Off": chkDtcOff.Checked = true; break;
                            case "Anahtar Kopyalama": chkAnahtarKopyalama.Checked = true; break;
                        }
                    }
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvMusteriler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek için bir müþteri seçin.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int musteriID = Convert.ToInt32(dgvMusteriler.SelectedRows[0].Cells["ID"].Value);
            string plaka = txtPlaka.Text.Trim();

            if (string.IsNullOrWhiteSpace(plaka))
            {
                MessageBox.Show("Lütfen plaka alanýný doldurun.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var musteriManager = new MusteriManager(connectionString);
            var islemler = new List<(CheckBox, string)>
            {
                (chkAdBlue, "AdBlue"),
                (chkDPF, "DPF"),
                (chkEGR, "EGR"),
                (chkStage1, "Stage 1"),
                (chkStage2, "Stage 2"),
                (chkOnOff, "On/Off"),
                (chkDtcOff, "DTC Off"),
                (chkAnahtarKopyalama, "Anahtar Kopyalama")
            };

            musteriManager.MusteriGuncelle(musteriID, plaka, islemler);

            MessageBox.Show("Müþteri baþarýyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            musteriManager.MusteriGetir(dgvMusteriler);
            BackupHelper.YazdirTxt(dgvMusteriler);

            CleanHelper.Temizle(txtPlaka, chkAdBlue, chkDPF, chkEGR, chkStage1, chkStage2, chkOnOff, chkDtcOff, chkAnahtarKopyalama);

        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            string aramaTerimi = txtAra.Text.Trim();

            MusteriManager musteriManager = new MusteriManager(connectionString);
            DataTable dt = musteriManager.MusteriAra(aramaTerimi);

            dgvMusteriler.DataSource = dt;
            dgvMusteriler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            if (dgvMusteriler.Columns.Contains("Kayýt Tarihi"))
                dgvMusteriler.Columns["Kayýt Tarihi"].DefaultCellStyle.Format = "dd-MM-yyyy HH:mm:ss";

            if (dgvMusteriler.Columns.Contains("Son Güncelleme Tarihi"))
                dgvMusteriler.Columns["Son Güncelleme Tarihi"].DefaultCellStyle.Format = "dd-MM-yyyy HH:mm:ss";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOrijinalVeriKaydet_Click(object sender, EventArgs e)
        {
            FileHelper.SaveDataToFolder("Orijinal Veriler", "Orijinal Veri Kaydet", "Orijinal veri baþarýyla kaydedildi.");
        }

        private void btnTuningliVeriKaydet_Click(object sender, EventArgs e)
        {
            FileHelper.SaveDataToFolder("Tuningli Veriler", "Tuningli Veri Kaydet", "Tuningli veri baþarýyla kaydedildi.");
        }

        private void txtAra_Click(object sender, EventArgs e)
        {
            txtAra.Clear();
        }
    }
}
