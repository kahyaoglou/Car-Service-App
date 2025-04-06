using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Service_App.Managers
{
    public class DatabaseManager
    {
        private string connectionString;

        public DatabaseManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void CreateDatabase()
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
    }
}
