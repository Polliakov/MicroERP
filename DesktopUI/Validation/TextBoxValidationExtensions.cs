using System;
using System.Windows.Forms;

namespace DesktopUI.Validation
{
    public static class TextBoxValidationExtensions
    {
        public static bool Required(this TextBox tb, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                MessageBox.Show($"Поле \"{fieldName}\" обязательное.");
                tb.Focus();
                return false;
            }
            return true;
        }

        public static bool MinLength(this TextBox tb, string fieldName, int length)
        {
            if (length < 0)
                throw new ArgumentException(nameof(length));

            if (tb.Text.Length < length)
            {
                MessageBox.Show($"Поле \"{fieldName}\" должно содержать не менее {length}-и символов.");
                tb.Focus();
                return false;
            }
            return true;
        }
    }
}
