using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Service_App.Helpers
{
    public class BackupHelper
    {
        public static void YazdirTxt(DataGridView dgvMusteriler)
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
                        writer.WriteLine("İşlemler: " + row.Cells["Islemler"].Value);
                        writer.WriteLine("--------------");
                    }
                }
            }
        }
    }
}
