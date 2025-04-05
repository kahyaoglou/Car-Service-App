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
            string plaka = txtPlaka.Text.Trim();

            if (string.IsNullOrWhiteSpace(plaka))
            {
                MessageBox.Show("Lütfen plaka alanýný doldurun.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                // Güncellenmiþ insert sorgusu
                string insertMusteri = "INSERT INTO Musteriler (Plaka, CreateDate, UpdateDate) VALUES (@Plaka, @CreateDate, @UpdateDate);";
                SQLiteCommand cmd = new SQLiteCommand(insertMusteri, conn);
                cmd.Parameters.AddWithValue("@Plaka", plaka);
                cmd.Parameters.AddWithValue("@CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
                cmd.ExecuteNonQuery();

                long musteriID = conn.LastInsertRowId;

                KaydetIslemler(conn, musteriID);

                MessageBox.Show("Müþteri baþarýyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VerileriGetir();
                YazdirTxt();
            }
        }

        private void KaydetIslemler(SQLiteConnection conn, long musteriID)
        {
            List<(CheckBox, string)> islemler = new List<(CheckBox, string)>
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

            string currentDate = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

            foreach (var (checkBox, islemAdi) in islemler)
            {
                if (checkBox.Checked)
                {
                    string insertIslem = "INSERT INTO Islemler (MusteriID, IslemAdi, Durum, CreateDate, UpdateDate) VALUES (@MusteriID, @IslemAdi, 'Yapýldý', @CreateDate, @UpdateDate);";
                    SQLiteCommand cmd = new SQLiteCommand(insertIslem, conn);
                    cmd.Parameters.AddWithValue("@MusteriID", musteriID);
                    cmd.Parameters.AddWithValue("@IslemAdi", islemAdi);
                    cmd.Parameters.AddWithValue("@CreateDate", currentDate);
                    cmd.Parameters.AddWithValue("@UpdateDate", currentDate);

                    cmd.ExecuteNonQuery();
                }
            }
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
                    m.CreateDate AS 'Kayýt Tarihi',  -- Add CreateDate here
                    m.UpdateDate AS 'Son Güncelleme Tarihi',  -- Add UpdateDate here
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

                // You can adjust the format of the date columns if needed
                dgvMusteriler.Columns["Kayýt Tarihi"].DefaultCellStyle.Format = "dd-MM-yyyy HH:mm:ss";
                dgvMusteriler.Columns["Son Güncelleme Tarihi"].DefaultCellStyle.Format = "dd-MM-yyyy HH:mm:ss";
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
                        writer.WriteLine("Ýþlemler: " + row.Cells["Islemler"].Value);
                        writer.WriteLine("--------------");
                    }
                }
            }
        }


        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvMusteriler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir müþteri seçin.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int musteriID = Convert.ToInt32(dgvMusteriler.SelectedRows[0].Cells["ID"].Value);

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string deleteIslemler = "DELETE FROM Islemler WHERE MusteriID = @MusteriID;";
                SQLiteCommand cmd1 = new SQLiteCommand(deleteIslemler, conn);
                cmd1.Parameters.AddWithValue("@MusteriID", musteriID);
                cmd1.ExecuteNonQuery();

                string deleteMusteri = "DELETE FROM Musteriler WHERE ID = @ID;";
                SQLiteCommand cmd2 = new SQLiteCommand(deleteMusteri, conn);
                cmd2.Parameters.AddWithValue("@ID", musteriID);
                cmd2.ExecuteNonQuery();

                MessageBox.Show("Müþteri baþarýyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VerileriGetir();
                YazdirTxt();  // Update the text file after deletion
            }
        }

        private void dgvMusteriler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMusteriler.SelectedRows.Count > 0)
            {
                int musteriID = Convert.ToInt32(dgvMusteriler.SelectedRows[0].Cells["ID"].Value);
                txtPlaka.Text = dgvMusteriler.SelectedRows[0].Cells["Plaka"].Value.ToString();

                // CheckBox'larý sýfýrla
                foreach (var checkbox in new CheckBox[] { chkAdBlue, chkDPF, chkEGR, chkStage1, chkStage2, chkOnOff, chkDtcOff, chkAnahtarKopyalama })
                {
                    checkbox.Checked = false;
                }

                // Ýþlemleri veritabanýndan çek ve ilgili checkbox'larý iþaretle
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

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string currentDate = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

                // Müþteri bilgilerini güncelle
                string updateMusteri = "UPDATE Musteriler SET Plaka = @Plaka, UpdateDate = @UpdateDate WHERE ID = @ID;";
                SQLiteCommand cmd = new SQLiteCommand(updateMusteri, conn);
                cmd.Parameters.AddWithValue("@Plaka", plaka);
                cmd.Parameters.AddWithValue("@UpdateDate", currentDate);
                cmd.Parameters.AddWithValue("@ID", musteriID);
                cmd.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
                cmd.ExecuteNonQuery();

                // Eski iþlemleri sil
                string deleteIslemler = "DELETE FROM Islemler WHERE MusteriID = @MusteriID;";
                SQLiteCommand cmdDelete = new SQLiteCommand(deleteIslemler, conn);
                cmdDelete.Parameters.AddWithValue("@MusteriID", musteriID);
                cmdDelete.ExecuteNonQuery();

                // Yeni iþlemleri ekle
                KaydetIslemler(conn, musteriID);

                MessageBox.Show("Müþteri baþarýyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VerileriGetir();
                YazdirTxt();
            }

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
                    m.CreateDate AS 'Kayýt Tarihi',  -- Add CreateDate here
                    m.UpdateDate AS 'Son Güncelleme Tarihi',  -- Add UpdateDate here
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
                        m.CreateDate AS 'Kayýt Tarihi', 
                        m.UpdateDate AS 'Son Güncelleme Tarihi', 
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
                dgvMusteriler.Columns["Kayýt Tarihi"].DefaultCellStyle.Format = "dd-MM-yyyy HH:mm:ss";
                dgvMusteriler.Columns["Son Güncelleme Tarihi"].DefaultCellStyle.Format = "dd-MM-yyyy HH:mm:ss";
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
                // Kullanýcýya herhangi bir dosya türü seçmesi için seçenek sunalým
                saveFileDialog.Filter = "All files (*.*)|*.*";
                saveFileDialog.Title = "Orijinal Veri Kaydet";

                // Dosya seçildiðinde
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string carServiceAppFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Car Service App");

                    // Klasör yoksa oluþtur
                    string originalFolderPath = Path.Combine(carServiceAppFolderPath, "Orijinal Veriler");
                    if (!Directory.Exists(originalFolderPath))
                    {
                        Directory.CreateDirectory(originalFolderPath);
                    }

                    // Seçilen dosyanýn hedef yolu
                    string targetFilePath = Path.Combine(originalFolderPath, Path.GetFileName(saveFileDialog.FileName));

                    // Seçilen dosyayý hedef klasöre kopyala
                    File.Copy(saveFileDialog.FileName, targetFilePath, true);

                    MessageBox.Show("Orijinal veri baþarýyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnTuningliVeriKaydet_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "All files (*.*)|*.*";
                saveFileDialog.Title = "Tuningli Veri Kaydet";

                // Dosya seçildiðinde
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string carServiceAppFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Car Service App");

                    // Klasör yoksa oluþtur
                    string tuningFolderPath = Path.Combine(carServiceAppFolderPath, "Tuningli Veriler");
                    if (!Directory.Exists(tuningFolderPath))
                    {
                        Directory.CreateDirectory(tuningFolderPath);
                    }

                    // Seçilen dosyanýn hedef yolu
                    string targetFilePath = Path.Combine(tuningFolderPath, Path.GetFileName(saveFileDialog.FileName));

                    // Seçilen dosyayý hedef klasöre kopyala
                    File.Copy(saveFileDialog.FileName, targetFilePath, true);

                    MessageBox.Show("Tuningli veri baþarýyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtAra_Click(object sender, EventArgs e)
        {
            txtAra.Clear();
        }
    }
}
