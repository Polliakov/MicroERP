using BL.DataProviders;
using DataBase.Entities;
using System.Windows.Forms;

namespace DesktopUI.Forms.ViewForms
{
    public partial class UserViewForm : Form
    {
        public UserViewForm(User user)
        {
            this.user = user;

            InitializeComponent();

            lblName.Text = user.Name;
            lblSurname.Text = user.Surname;
            lblPatronymic.Text = user.Patronymic;
            lblPhoneNumber.Text = user.PhoneNumber;
            lblRole.Text = user.Role.ToString();
        }

        private readonly User user;

        private void BtnCheques_Click(object sender, System.EventArgs e)
        {
            var dataForm = new DataForm<Cheque>(new ProductOperationDataProvider<Cheque>(user));
            dataForm.Text = "Чеки " + user.GetFullNameShort();
            dataForm.Show();
        }

        private void BtnPickings_Click(object sender, System.EventArgs e)
        {
            var dataForm = new DataForm<ProductPicking>(new ProductOperationDataProvider<ProductPicking>(user));
            dataForm.Text = "Поставки " + user.GetFullNameShort();
            dataForm.Show();
        }

        private void BtnWriteOfs_Click(object sender, System.EventArgs e)
        {
            var dataForm = new DataForm<ProductWriteOf>(new ProductOperationDataProvider<ProductWriteOf>(user));
            dataForm.Text = "Списания " + user.GetFullNameShort();
            dataForm.Show();
        }
    }
}
