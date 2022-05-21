using BL.Security;
using BL.Services;
using DataBase.Entities;
using DesktopUI.CustomControls.ProductEntryListSelector;
using DesktopUI.Validation;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DesktopUI.Forms.ProductOperationsForms
{
    public partial class CreateWriteOfForm : Form
    {
        public CreateWriteOfForm(AuthenticatedUser currentUser, Warehouse currentWarehouse)
        {
            service = new CreateWriteOfService(currentUser, currentWarehouse);

            InitializeComponent();
            InitializeProductEntryListSelector(currentWarehouse);
        }

        private readonly CreateWriteOfService service;
        private ProductEntryListSelector<ProductInWriteOf> productEntryListSelector;

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            if (!tbDescription.Required("Описание"))
                return;
            var entries = productEntryListSelector.GetEntries();
            if (entries.Count() == 0)
            {
                MessageBox.Show("Нельзя оформить пустое списание.");
                return;
            }

            try
            {
                service.Create(entries, tbDescription.Text);
                productEntryListSelector.Clear();
                tbDescription.Text = string.Empty;
            }
            catch (WarehouseWriteOfException ex)
            {
                string message = $"Невозможно списать \"{ex.Product}\" в количестве {ex.ProductCount}." +
                                 Environment.NewLine +
                                 $"Остаток на складе \"{ex.Warehouse}\" - {ex.LeftInWarehouse}.";
                MessageBox.Show(message, "Ошибка склада");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeProductEntryListSelector(Warehouse warehouse)
        {
            productEntryListSelector = new ProductEntryListSelector<ProductInWriteOf>(warehouse);
            productEntryListSelector.Dock = DockStyle.Fill;
            productEntryListSelector.SelectorTitle = warehouse.ToString();
            productEntryListSelector.ListTitle = "Списание";
            pnlProductEntryListSelector.Controls.Add(productEntryListSelector);
        }
    }
}
