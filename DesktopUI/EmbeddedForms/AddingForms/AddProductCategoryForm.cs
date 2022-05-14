using BL.DataProviders;
using DataBase.Entities;
using DesktopUI.Validation;
using System;
using System.Windows.Forms;

namespace DesktopUI.EmbeddedForms.AddingForms
{
    public partial class AddProductCategoryForm : Form
    {
        public AddProductCategoryForm()
        {
            InitializeComponent();
        }

        private readonly DataProvider<ProductCategory> dataProvider = new DataProvider<ProductCategory>();

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            if (!tbName.Required("Название"))
                return;

            var category = new ProductCategory
            {
                Name = tbName.Text,
            };

            try
            {
                dataProvider.Create(category);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            tbName.Text = string.Empty;
        }
    }
}
