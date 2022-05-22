using BL.Security;
using BL.Services;
using DataBase.Entities;
using DesktopUI.Validation;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DesktopUI.Forms.AddingForms
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
            cbRole.SelectedIndex = 0;
        }

        private readonly CreateUserService service = new CreateUserService();

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
                Password = PasswordHash.Calculate(tbPassword.Text, tbPhoneNumber.Text),
                Role = (UserRole)cbRole.SelectedIndex,
            };

            try
            {
                service.Create(user);
                ClearFields();
            }
            catch (UserIdentificationException)
            {
                MessageBox.Show($"Пользователь с номером телефона {user.PhoneNumber} уже существует.");
                tbPhoneNumber.Focus();
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
