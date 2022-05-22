using BL.DataProviders;
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
    public partial class CreatePickingForm : Form
    {
        public CreatePickingForm(AuthenticatedUser currentUser)
        {
            service = new CreatePickingService(currentUser);

            InitializeComponent();
            InitializeProductEntryListSelector();

            var dataProvider = new DeletableDataProvider<Warehouse>();
            cbWarehouse.DataSource = dataProvider.GetBindingList();
        }

        private readonly CreatePickingService service;
        private readonly ProductEntryListSelector<ProductInPicking> productEntryListSelector =
            new ProductEntryListSelector<ProductInPicking>();

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            if (cbWarehouse.Required("Выберите склад."))
                return;

            var entries = productEntryListSelector.GetEntries();
            if (entries.Count() == 0)
            {
                MessageBox.Show("Нельзя оформить пустую поставку.");
                return;
            }

            var warehouse = (Warehouse)cbWarehouse.SelectedItem;
            try
            {
                service.Create(entries, warehouse);
                productEntryListSelector.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeProductEntryListSelector()
        {
            productEntryListSelector.Dock = DockStyle.Fill;
            productEntryListSelector.SelectorTitle = "Товары";
            productEntryListSelector.ListTitle = "Поставка";
            pnlProductEntryListSelector.Controls.Add(productEntryListSelector);
        }

        private void CbWarehouse_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
