using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Car_Service_App.Managers
{
    public class MusteriManager
    {
        private readonly string _connectionString;

        public MusteriManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void MusteriKaydet(string plaka, List<(CheckBox, string)> islemler)
        {
            if (string.IsNullOrWhiteSpace(plaka))
            {
                MessageBox.Show("Lütfen plaka alanını doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();

                string insertMusteri = "INSERT INTO Musteriler (Plaka, CreateDate, UpdateDate) VALUES (@Plaka, @CreateDate, @UpdateDate);";
                using (SQLiteCommand cmd = new SQLiteCommand(insertMusteri, conn))
                {
                    cmd.Parameters.AddWithValue("@Plaka", plaka.ToUpper().Trim());
                    cmd.Parameters.AddWithValue("@CreateDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }

                long musteriID = conn.LastInsertRowId;
                string currentDate = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

                foreach (var (checkBox, islemAdi) in islemler)
                {
                    if (checkBox.Checked)
                    {
                        string insertIslem = "INSERT INTO Islemler (MusteriID, IslemAdi, Durum, CreateDate, UpdateDate) VALUES (@MusteriID, @IslemAdi, 'Yapıldı', @CreateDate, @UpdateDate);";
                        using (SQLiteCommand cmd = new SQLiteCommand(insertIslem, conn))
                        {
                            cmd.Parameters.AddWithValue("@MusteriID", musteriID);
                            cmd.Parameters.AddWithValue("@IslemAdi", islemAdi);
                            cmd.Parameters.AddWithValue("@CreateDate", currentDate);
                            cmd.Parameters.AddWithValue("@UpdateDate", currentDate);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Müşteri başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void MusteriGuncelle(int musteriID, string plaka, List<(CheckBox, string)> islemler)
        {
            using (SQLiteConnection conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();

                string currentDate = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

                // Müşteri bilgilerini güncelle
                string updateMusteri = "UPDATE Musteriler SET Plaka = @Plaka, UpdateDate = @UpdateDate WHERE ID = @ID;";
                SQLiteCommand cmd = new SQLiteCommand(updateMusteri, conn);
                cmd.Parameters.AddWithValue("@Plaka", plaka);
                cmd.Parameters.AddWithValue("@UpdateDate", currentDate);
                cmd.Parameters.AddWithValue("@ID", musteriID);
                cmd.ExecuteNonQuery();

                // Eski işlemleri sil
                string deleteIslemler = "DELETE FROM Islemler WHERE MusteriID = @MusteriID;";
                SQLiteCommand cmdDelete = new SQLiteCommand(deleteIslemler, conn);
                cmdDelete.Parameters.AddWithValue("@MusteriID", musteriID);
                cmdDelete.ExecuteNonQuery();

                // Yeni işlemleri ekle
                foreach (var (checkBox, islemAdi) in islemler)
                {
                    if (checkBox.Checked)
                    {
                        string insertIslem = "INSERT INTO Islemler (MusteriID, IslemAdi, Durum, CreateDate, UpdateDate) VALUES (@MusteriID, @IslemAdi, 'Yapıldı', @CreateDate, @UpdateDate);";
                        SQLiteCommand cmdInsert = new SQLiteCommand(insertIslem, conn);
                        cmdInsert.Parameters.AddWithValue("@MusteriID", musteriID);
                        cmdInsert.Parameters.AddWithValue("@IslemAdi", islemAdi);
                        cmdInsert.Parameters.AddWithValue("@CreateDate", currentDate);
                        cmdInsert.Parameters.AddWithValue("@UpdateDate", currentDate);

                        cmdInsert.ExecuteNonQuery();
                    }
                }
            }
        }

        public void MusteriSil(int musteriID)
        {
            using (SQLiteConnection conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();

                string deleteIslemler = "DELETE FROM Islemler WHERE MusteriID = @MusteriID;";
                using (SQLiteCommand cmd1 = new SQLiteCommand(deleteIslemler, conn))
                {
                    cmd1.Parameters.AddWithValue("@MusteriID", musteriID);
                    cmd1.ExecuteNonQuery();
                }

                string deleteMusteri = "DELETE FROM Musteriler WHERE ID = @ID;";
                using (SQLiteCommand cmd2 = new SQLiteCommand(deleteMusteri, conn))
                {
                    cmd2.Parameters.AddWithValue("@ID", musteriID);
                    cmd2.ExecuteNonQuery();
                }
            }
        }
    }
}
