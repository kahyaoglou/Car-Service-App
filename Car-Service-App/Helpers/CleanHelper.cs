using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Service_App.Helpers
{
    public class CleanHelper
    {
        public static void Temizle(TextBox plakaTextBox, params CheckBox[] checkBoxes)
        {
            plakaTextBox.Text = "";

            foreach (var checkbox in checkBoxes)
            {
                checkbox.Checked = false;
            }
        }
    }
}
