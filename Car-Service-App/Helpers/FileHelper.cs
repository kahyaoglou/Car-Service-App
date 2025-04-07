using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Service_App.Helpers
{
    public class FileHelper
    {
        public static void SaveDataToFolder(string folderName, string dialogTitle, string successMessage)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "All files (*.*)|*.*";
                saveFileDialog.Title = dialogTitle;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string carServiceAppFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Car Service App");

                    string targetFolderPath = Path.Combine(carServiceAppFolderPath, folderName);
                    if (!Directory.Exists(targetFolderPath))
                    {
                        Directory.CreateDirectory(targetFolderPath);
                    }

                    string targetFilePath = Path.Combine(targetFolderPath, Path.GetFileName(saveFileDialog.FileName));

                    File.Copy(saveFileDialog.FileName, targetFilePath, true);

                    MessageBox.Show(successMessage, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
