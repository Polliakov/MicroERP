using BL.Security;
using System;
using System.Windows.Forms;
using DesktopUI.Validation;

namespace DesktopUI.Forms
{
    public partial class AuthenticationForm : Form
    {
        public AuthenticationForm()
        {
            InitializeComponent();
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            if (!tbLogin.Required("Номер телефона") ||
                !tbPassword.Required("Пароль"))
                return;

            try
            {
                lblWrongLogin.Visible = false;
                lblWrongPassword.Visible = false;

                var user = AuthenticatedUser.Authenticate(tbLogin.Text, tbPassword.Text);
                
                Hide();
                new MainForm(user).Show();
            }
            catch (UserIdentificationException)
            {
                lblWrongLogin.Visible = true;
                tbLogin.Focus();
            }
            catch (UserAuthenticationException)
            {
                lblWrongPassword.Visible = true;
                tbPassword.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TbLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            var pressedKey = e.KeyChar;
            if (!char.IsDigit(pressedKey) && pressedKey != 8) // 8 - BackSpace ASCII code.
                e.Handled = true;
        }
    }
}
