using System;
using System.Windows.Forms;
using BL.DataProviders;
using DataBase.Entities;
using DesktopUI.Validation;

namespace DesktopUI.Forms.AddingForms
{
    public partial class AddWarehouseForm : Form
    {
        public AddWarehouseForm()
        {
            InitializeComponent();
        }

        private readonly DataProvider<Warehouse> dataProvider = new DataProvider<Warehouse>();

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            if (!tbAddress.Required("Адрес"))
                return;

            var warehouse = new Warehouse
            {
                Address = tbAddress.Text,
                Name = string.IsNullOrWhiteSpace(tbName.Text) ? null : tbName.Text
            };

            try
            {
                dataProvider.Create(warehouse);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            tbAddress.Text = string.Empty;
            tbName.Text = string.Empty;
        }
    }
}
