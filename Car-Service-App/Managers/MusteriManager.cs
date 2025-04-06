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

    }
}
