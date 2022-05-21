using BL.DataProviders;
using BL.Models;
using DataBase.Entities;
using DesktopUI.CustomControls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows.Forms;

namespace DesktopUI.Forms.ViewForms
{
    public partial class UserViewForm : Form
    {
        public UserViewForm(User user)
        {
            InitializeComponent();

            lblName.Text = user.Name;
            lblSurname.Text = user.Surname;
            lblPatronymic.Text = user.Patronymic;
            lblPhoneNumber.Text = user.PhoneNumber;
            lblRole.Text = user.Role.ToString();
        }

        private void BtnCheques_Click(object sender, System.EventArgs e)
        {

        }

        private void BtnPickings_Click(object sender, System.EventArgs e)
        {

        }

        private void BtnWriteOfs_Click(object sender, System.EventArgs e)
        {

        }
    }
}
