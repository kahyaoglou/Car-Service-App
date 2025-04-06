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

        private void CreateDatabase()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string queryMusteriler = @"CREATE TABLE IF NOT EXISTS Musteriler (
                                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                    Plaka TEXT NOT NULL,
                                    CreateDate TEXT NOT NULL,
                                    UpdateDate TEXT NOT NULL
                                  );";

                string queryIslemler = @"CREATE TABLE IF NOT EXISTS Islemler (
                                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                    MusteriID INTEGER,
                                    IslemAdi TEXT NOT NULL,
                                    Durum TEXT NOT NULL,
                                    CreateDate TEXT NOT NULL,
                                    UpdateDate TEXT NOT NULL,
                                    FOREIGN KEY(MusteriID) REFERENCES Musteriler(ID)
                                  );";

                new SQLiteCommand(queryMusteriler, conn).ExecuteNonQuery();
                new SQLiteCommand(queryIslemler, conn).ExecuteNonQuery();
            }
        }

        public MainPage()
        {
            CreateDatabase();
            InitializeComponent();
            VerileriGetir();
            YazdirTxt();
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

            VerileriGetir();
            YazdirTxt();
        }

        private void VerileriGetir()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"
                SELECT 
                    m.ID, 
                    m.Plaka, 
                    m.CreateDate AS 'Kay�t Tarihi',  -- Add CreateDate here
                    m.UpdateDate AS 'Son G�ncelleme Tarihi',  -- Add UpdateDate here
                    GROUP_CONCAT(i.IslemAdi || ' (' || i.Durum || ')', ', ') AS Islemler
                FROM Musteriler m
                LEFT JOIN Islemler i ON m.ID = i.MusteriID
                GROUP BY m.ID, m.Plaka
                ORDER BY m.ID DESC;";

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvMusteriler.DataSource = dt;
                dgvMusteriler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvMusteriler.Columns["Kay�t Tarihi"].DefaultCellStyle.Format = "dd-MM-yyyy HH:mm:ss";
                dgvMusteriler.Columns["Son G�ncelleme Tarihi"].DefaultCellStyle.Format = "dd-MM-yyyy HH:mm:ss";
            }
        }

        private void YazdirTxt()
        {
            string carServiceAppFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Car Service App");

            if (!Directory.Exists(carServiceAppFolderPath))
            {
                Directory.CreateDirectory(carServiceAppFolderPath);
            }

            string filePath = Path.Combine(carServiceAppFolderPath, "IslemKaydi.txt");

            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (DataGridViewRow row in dgvMusteriler.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        writer.WriteLine("Plaka: " + row.Cells["Plaka"].Value);
                        writer.WriteLine("��lemler: " + row.Cells["Islemler"].Value);
                        writer.WriteLine("--------------");
                    }
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvMusteriler.SelectedRows.Count == 0)
            {
                MessageBox.Show("L�tfen silmek i�in bir m��teri se�in.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int musteriID = Convert.ToInt32(dgvMusteriler.SelectedRows[0].Cells["ID"].Value);
            var musteriManager = new MusteriManager(connectionString);

            musteriManager.MusteriSil(musteriID);

            MessageBox.Show("M��teri ba�ar�yla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            VerileriGetir();
            YazdirTxt();
        }

        private void dgvMusteriler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMusteriler.SelectedRows.Count > 0)
            {
                int musteriID = Convert.ToInt32(dgvMusteriler.SelectedRows[0].Cells["ID"].Value);
                txtPlaka.Text = dgvMusteriler.SelectedRows[0].Cells["Plaka"].Value.ToString();

                // CheckBox'lar� s�f�rla
                foreach (var checkbox in new CheckBox[] { chkAdBlue, chkDPF, chkEGR, chkStage1, chkStage2, chkOnOff, chkDtcOff, chkAnahtarKopyalama })
                {
                    checkbox.Checked = false;
                }

                // ��lemleri veritaban�ndan �ek ve ilgili checkbox'lar� i�aretle
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
                MessageBox.Show("L�tfen g�ncellemek i�in bir m��teri se�in.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int musteriID = Convert.ToInt32(dgvMusteriler.SelectedRows[0].Cells["ID"].Value);
            string plaka = txtPlaka.Text.Trim();

            if (string.IsNullOrWhiteSpace(plaka))
            {
                MessageBox.Show("L�tfen plaka alan�n� doldurun.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            MessageBox.Show("M��teri ba�ar�yla g�ncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            VerileriGetir();
            YazdirTxt();

            Temizle();

        }

        private void Temizle()
        {
            txtPlaka.Text = "";

            foreach (var checkbox in new CheckBox[] { chkAdBlue, chkDPF, chkEGR, chkStage1, chkStage2, chkOnOff, chkDtcOff, chkAnahtarKopyalama })
            {
                checkbox.Checked = false;
            }
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            string aramaTerimi = txtAra.Text.Trim();
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = @"
                SELECT 
                    m.ID, 
                    m.Plaka, 
                    m.CreateDate AS 'Kay�t Tarihi',  -- Add CreateDate here
                    m.UpdateDate AS 'Son G�ncelleme Tarihi',  -- Add UpdateDate here
                    GROUP_CONCAT(i.IslemAdi, ', ') AS YapilanIslemler
                FROM Musteriler m
                LEFT JOIN Islemler i ON m.ID = i.MusteriID
                WHERE m.Plaka LIKE @Arama
                GROUP BY m.ID, m.Plaka
                ORDER BY m.ID DESC;";

                if (string.IsNullOrEmpty(aramaTerimi))
                {
                    query = @"
                    SELECT 
                        m.ID, 
                        m.Plaka, 
                        m.CreateDate AS 'Kay�t Tarihi', 
                        m.UpdateDate AS 'Son G�ncelleme Tarihi', 
                        GROUP_CONCAT(i.IslemAdi, ', ') AS YapilanIslemler
                    FROM Musteriler m
                    LEFT JOIN Islemler i ON m.ID = i.MusteriID
                    GROUP BY m.ID, m.Plaka
                    ORDER BY m.ID DESC;";
                }

                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@Arama", "%" + aramaTerimi + "%");

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvMusteriler.DataSource = dt;
                dgvMusteriler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // Format date columns
                dgvMusteriler.Columns["Kay�t Tarihi"].DefaultCellStyle.Format = "dd-MM-yyyy HH:mm:ss";
                dgvMusteriler.Columns["Son G�ncelleme Tarihi"].DefaultCellStyle.Format = "dd-MM-yyyy HH:mm:ss";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOrijinalVeriKaydet_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // Kullan�c�ya herhangi bir dosya t�r� se�mesi i�in se�enek sunal�m
                saveFileDialog.Filter = "All files (*.*)|*.*";
                saveFileDialog.Title = "Orijinal Veri Kaydet";

                // Dosya se�ildi�inde
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string carServiceAppFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Car Service App");

                    // Klas�r yoksa olu�tur
                    string originalFolderPath = Path.Combine(carServiceAppFolderPath, "Orijinal Veriler");
                    if (!Directory.Exists(originalFolderPath))
                    {
                        Directory.CreateDirectory(originalFolderPath);
                    }

                    // Se�ilen dosyan�n hedef yolu
                    string targetFilePath = Path.Combine(originalFolderPath, Path.GetFileName(saveFileDialog.FileName));

                    // Se�ilen dosyay� hedef klas�re kopyala
                    File.Copy(saveFileDialog.FileName, targetFilePath, true);

                    MessageBox.Show("Orijinal veri ba�ar�yla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnTuningliVeriKaydet_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "All files (*.*)|*.*";
                saveFileDialog.Title = "Tuningli Veri Kaydet";

                // Dosya se�ildi�inde
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string carServiceAppFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Car Service App");

                    // Klas�r yoksa olu�tur
                    string tuningFolderPath = Path.Combine(carServiceAppFolderPath, "Tuningli Veriler");
                    if (!Directory.Exists(tuningFolderPath))
                    {
                        Directory.CreateDirectory(tuningFolderPath);
                    }

                    // Se�ilen dosyan�n hedef yolu
                    string targetFilePath = Path.Combine(tuningFolderPath, Path.GetFileName(saveFileDialog.FileName));

                    // Se�ilen dosyay� hedef klas�re kopyala
                    File.Copy(saveFileDialog.FileName, targetFilePath, true);

                    MessageBox.Show("Tuningli veri ba�ar�yla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtAra_Click(object sender, EventArgs e)
        {
            txtAra.Clear();
        }
    }
}
