using System.Windows.Forms;

namespace DesktopUI.Validation
{
    public static class ComboBoxValidationExtensions
    {
        public static bool Required(this ComboBox cb, string message)
        {
            if (cb.SelectedIndex == -1)
            {
                MessageBox.Show(message);
                cb.Focus();
                return false;
            }
            return true;
        }
    }
}
