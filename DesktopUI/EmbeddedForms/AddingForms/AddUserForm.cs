using BL.DataProviders;
using BL.Security;
using DataBase.Entities;
using DesktopUI.Validation;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DesktopUI.EmbeddedForms.AddingForms
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
            cbRole.SelectedIndex = 0;
        }

        private readonly DataProvider<User> dataProvider = new DataProvider<User>();

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            if (!tbName.Required("Имя") ||
                !tbSurname.Required("Фамилия") ||
                !tbPhoneNumber.Required("Телефон") ||
                !tbPhoneNumber.MinLength("Телефон", 6) ||
                !tbPassword.Required("Пароль") ||
                !tbPassword.MinLength("Пароль", 6))
                return;

            var user = new User
            {
                Name = tbName.Text,
                Surname = tbSurname.Text,
                Patronymic = string.IsNullOrWhiteSpace(tbPatronymic.Text) ? null : tbPatronymic.Text,
                PhoneNumber = tbPhoneNumber.Text,
                Password = PasswordHash.Calculate(tbPassword.Text),
                Role = (UserRole)cbRole.SelectedIndex,
            };

            try
            {
                dataProvider.Create(user);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            var pressedKey = e.KeyChar;
            if (!char.IsDigit(pressedKey) && pressedKey != 8) // 8 - BackSpace ASCII code.
                e.Handled = true;
        }

        private void ClearFields()
        {
            foreach (var tb in Controls.OfType<TextBox>())
                tb.Text = string.Empty;
            cbRole.SelectedIndex = 0;
        }

        private void CbRole_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
