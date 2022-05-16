using BL.DataProviders;
using DataBase.Entities;
using DesktopUI.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopUI.EmbeddedForms.AddingForms
{
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            InitializeComponent();
            var set = productCategoryDP.GetData();
            set.Load();
            cbCategory.DataSource = set.Local.ToBindingList();
            cbCategory.SelectedIndex = 0;
        }

        private readonly DataProvider<Product> productDP = new DataProvider<Product>();
        private readonly DataProvider<ProductCategory> productCategoryDP = new DataProvider<ProductCategory>();

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            if (!tbName.Required("Наименование"))
                return;

            var product = new Product
            {
                Name = tbName.Text,
                Description = string.IsNullOrWhiteSpace(tbDescription.Text) ? null : tbDescription.Text,
                Price = nmcPrice.Value,
                Category = (ProductCategory)cbCategory.SelectedItem,
            };

            try
            {
                productDP.Create(product);
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
            tbDescription.Text = string.Empty;
            nmcPrice.Value = 0m;
            cbCategory.SelectedIndex = 0;
        }

        private void CbCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
