using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Car_Service_App
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=database.db;Version=3;";

        private void CreateDatabase()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string queryMusteriler = @"CREATE TABLE IF NOT EXISTS Musteriler (
                                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                    Plaka TEXT NOT NULL,
                                    Isim TEXT NOT NULL
                                  );";

                string queryIslemler = @"CREATE TABLE IF NOT EXISTS Islemler (
                                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                    MusteriID INTEGER,
                                    IslemAdi TEXT NOT NULL,
                                    Durum TEXT NOT NULL,
                                    FOREIGN KEY(MusteriID) REFERENCES Musteriler(ID)
                                  );";

                SQLiteCommand cmd1 = new SQLiteCommand(queryMusteriler, conn);
                SQLiteCommand cmd2 = new SQLiteCommand(queryIslemler, conn);
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
            }
        }


        public Form1()
        {
            CreateDatabase();
            InitializeComponent();
            VerileriGetir();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string plaka = txtPlaka.Text.Trim();
            string isim = txtIsim.Text.Trim();

            if (string.IsNullOrWhiteSpace(plaka) || string.IsNullOrWhiteSpace(isim))
            {
                MessageBox.Show("Lütfen plaka ve isim alanlarýný doldurun.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string insertMusteri = "INSERT INTO Musteriler (Plaka, Isim) VALUES (@Plaka, @Isim);";
                SQLiteCommand cmd = new SQLiteCommand(insertMusteri, conn);
                cmd.Parameters.AddWithValue("@Plaka", plaka);
                cmd.Parameters.AddWithValue("@Isim", isim);
                cmd.ExecuteNonQuery();

                long musteriID = conn.LastInsertRowId; // Eklenen müþterinin ID'sini al

                // Ýþlemleri kaydet
                KaydetIslemler(conn, musteriID);

                MessageBox.Show("Müþteri baþarýyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VerileriGetir();
            }
        }

        private void KaydetIslemler(SQLiteConnection conn, long musteriID)
        {
            List<(CheckBox, string)> islemler = new List<(CheckBox, string)>
    {
        (chkAdBlue, "AdBlue"),
        (chkAnahtarKopyalama, "Anahtar Kopyalama"),
        (chkYagDegisimi, "Yað Deðiþimi"),
        (chkLastikDegisimi, "Lastik Deðiþimi"),
        (chkArizaTespiti, "Arýza Tespiti")
    };

            foreach (var (checkBox, islemAdi) in islemler)
            {
                if (checkBox.Checked)
                {
                    string insertIslem = "INSERT INTO Islemler (MusteriID, IslemAdi, Durum) VALUES (@MusteriID, @IslemAdi, 'Yapýldý');";
                    SQLiteCommand cmd = new SQLiteCommand(insertIslem, conn);
                    cmd.Parameters.AddWithValue("@MusteriID", musteriID);
                    cmd.Parameters.AddWithValue("@IslemAdi", islemAdi);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void VerileriGetir()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT m.ID, m.Plaka, m.Isim, 
                                GROUP_CONCAT(i.IslemAdi || ' (' || i.Durum || ')', ', ') AS Islemler
                         FROM Musteriler m
                         LEFT JOIN Islemler i ON m.ID = i.MusteriID
                         GROUP BY m.ID, m.Plaka, m.Isim;";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvMusteriler.DataSource = dt;
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
            }
        }

        private void dgvMusteriler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMusteriler.SelectedRows.Count > 0)
            {
                int musteriID = Convert.ToInt32(dgvMusteriler.SelectedRows[0].Cells["ID"].Value);
                txtPlaka.Text = dgvMusteriler.SelectedRows[0].Cells["Plaka"].Value.ToString();
                txtIsim.Text = dgvMusteriler.SelectedRows[0].Cells["Isim"].Value.ToString();

                // CheckBox'larý sýfýrla
                foreach (var checkbox in new CheckBox[] { chkAdBlue, chkAnahtarKopyalama, chkYagDegisimi, chkLastikDegisimi, chkArizaTespiti })
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
                            case "Anahtar Kopyalama": chkAnahtarKopyalama.Checked = true; break;
                            case "Yað Deðiþimi": chkYagDegisimi.Checked = true; break;
                            case "Lastik Deðiþimi": chkLastikDegisimi.Checked = true; break;
                            case "Arýza Tespiti": chkArizaTespiti.Checked = true; break;
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
            string isim = txtIsim.Text.Trim();

            if (string.IsNullOrWhiteSpace(plaka) || string.IsNullOrWhiteSpace(isim))
            {
                MessageBox.Show("Lütfen plaka ve isim alanlarýný doldurun.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                // Müþteri bilgilerini güncelle
                string updateMusteri = "UPDATE Musteriler SET Plaka = @Plaka, Isim = @Isim WHERE ID = @ID;";
                SQLiteCommand cmd = new SQLiteCommand(updateMusteri, conn);
                cmd.Parameters.AddWithValue("@Plaka", plaka);
                cmd.Parameters.AddWithValue("@Isim", isim);
                cmd.Parameters.AddWithValue("@ID", musteriID);
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
            }

            Temizle();

        }

        private void Temizle()
        {
            txtPlaka.Text = "";
            txtIsim.Text = "";

            foreach (var checkbox in new CheckBox[] { chkAdBlue, chkAnahtarKopyalama, chkYagDegisimi, chkLastikDegisimi, chkArizaTespiti })
            {
                checkbox.Checked = false;
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            string aramaTerimi = txtAra.Text.Trim();
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = @"
            SELECT 
                m.ID, 
                m.Plaka, 
                m.Isim, 
                GROUP_CONCAT(i.IslemAdi, ', ') AS YapilanIslemler
            FROM Musteriler m
            LEFT JOIN Islemler i ON m.ID = i.MusteriID
            WHERE m.Plaka LIKE @Arama OR m.Isim LIKE @Arama
            GROUP BY m.ID, m.Plaka, m.Isim;";

                if (string.IsNullOrEmpty(aramaTerimi))
                {
                    query = @"
                SELECT 
                    m.ID, 
                    m.Plaka, 
                    m.Isim, 
                    GROUP_CONCAT(i.IslemAdi, ', ') AS YapilanIslemler
                FROM Musteriler m
                LEFT JOIN Islemler i ON m.ID = i.MusteriID
                GROUP BY m.ID, m.Plaka, m.Isim;";
                }

                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@Arama", "%" + aramaTerimi + "%");

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvMusteriler.DataSource = dt;
            }
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            btnAra_Click(sender, e); // Ayný arama metodunu çaðýrýyoruz
        }
    }
}
