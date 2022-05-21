using BL.Security;
using BL.Services;
using DataBase.Entities;
using DesktopUI.CustomControls.ProductEntryListSelector;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DesktopUI.Forms.ProductOperationsForms
{
    public partial class CreateCheqeForm : Form
    {
        public CreateCheqeForm(AuthenticatedUser currentUser, Warehouse currentWarehouse)
        {
            service = new CreateChequeService(currentUser, currentWarehouse);

            InitializeComponent();
            InitializeProductEntryListSelector(currentWarehouse);
            lblTotal.Text = lblTotalTitle + 0.ToString("C");
        }

        private readonly CreateChequeService service;
        private ProductEntryListSelector<ProductSell> productEntryListSelector;
        private const string lblTotalTitle = "Cумма: ";

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            var entries = productEntryListSelector.GetEntries();
            if (entries.Count() == 0)
            {
                MessageBox.Show("Нельзя оформить пустой чек.");
                return;
            }

            try
            {
                service.Create(entries);
                productEntryListSelector.Clear();
            }
            catch (WarehouseWriteOfException ex)
            {
                string message = $"Невозможно продать \"{ex.Product}\" в количестве {ex.ProductCount}." +
                                 Environment.NewLine +
                                 $"Остаток на складе \"{ex.Warehouse}\" - {ex.LeftInWarehouse}.";
                MessageBox.Show(message, "Ошибка склада");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateLblTotal()
        {
            var entries = productEntryListSelector.GetEntries();
            var total = entries.Aggregate(0m, (acc, ps) => acc += ps.Product.Price * ps.Count);
            lblTotal.Text = lblTotalTitle + total.ToString("C");
        }

        private void InitializeProductEntryListSelector(Warehouse warehouse)
        {
            productEntryListSelector = new ProductEntryListSelector<ProductSell>(warehouse);
            productEntryListSelector.ListChanged += UpdateLblTotal;

            productEntryListSelector.Dock = DockStyle.Fill;
            productEntryListSelector.SelectorTitle = warehouse.ToString();
            productEntryListSelector.ListTitle = "Чек";
            pnlProductEntryListSelector.Controls.Add(productEntryListSelector);
        }
    }
}
