﻿using BL.Security;
using System;
using System.Windows.Forms;

namespace DesktopUI
{
    public partial class AuthenticationForm : Form
    {
        public AuthenticationForm()
        {
            InitializeComponent();
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                lblWrongLogin.Visible = false;
                lblWrongPassword.Visible = false;

                var user = AuthenticatedUser.Authenticate(tbLogin.Text, tbPassword.Text);
                CurrentUser.User = user;
                
                Hide();
                new MainForm().Show();
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