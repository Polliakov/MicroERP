using BL.DataProviders;
using BL.Security;
using DataBase.Entities;
using System;
using System.Windows.Forms;

namespace DesktopUI.Forms
{
    public partial class MainForm : Form
    {
        public MainForm(AuthenticatedUser currentUser)
        {
            this.currentUser = currentUser;

            InitializeComponent();
            InitializeCbCurrentWarehouse();
            AddSideMenuItems();

            var currentWarehouse = GetCurrentWarehouse();
            formFactory = new FormFactory(currentUser, currentWarehouse);

            cbCurrentWarehouse.SelectedIndexChanged += (_, e) => WarehouseChanged?.Invoke(GetCurrentWarehouse());
            WarehouseChanged += formFactory.WarehouseChanged;
            sideMenu.ItemClick += SideMenu_ItemClick;
        }

        public event Action<Warehouse> WarehouseChanged;

        private readonly FormFactory formFactory;
        private readonly AuthenticatedUser currentUser;

        private Warehouse GetCurrentWarehouse() => (Warehouse)cbCurrentWarehouse.SelectedItem;

        private void AddSideMenuItems()
        {
            sideMenu.AddItem("Продажа товара", EmbaddedForm.CreateChequeForm);
            sideMenu.AddItem("Продажи", EmbaddedForm.ChequeDataForm);
            sideMenu.AddItem("Поставки", EmbaddedForm.ProductPickingDataForm);
            sideMenu.AddItem("Списания", EmbaddedForm.ProductWriteOfDataForm);
            sideMenu.AddItem("Товары", EmbaddedForm.ProductDataForm);
            sideMenu.AddItem("Категории", EmbaddedForm.ProductCategoryDataForm);
            sideMenu.AddItem("Склады", EmbaddedForm.WarehouseDataForm);

            if (currentUser.Role != UserRole.Administrator) return;

            sideMenu.AddItem("Пользователи", EmbaddedForm.UserDataForm);
            sideMenu.AddItem("Новый товар", EmbaddedForm.AddProductForm);
            sideMenu.AddItem("Новая категория", EmbaddedForm.AddProductCategoryForm);
            sideMenu.AddItem("Новый пользователь", EmbaddedForm.AddUserForm);
            sideMenu.AddItem("Новый склад", EmbaddedForm.AddWarehouseForm);
            sideMenu.AddItem("Новая поставка", EmbaddedForm.CreatePickingForm);
            sideMenu.AddItem("Списание товара", EmbaddedForm.CreateWriteOfForm);
        }

        private void InitializeCbCurrentWarehouse()
        {
            var dataProvider = new DeletableDataProvider<Warehouse>();
            cbCurrentWarehouse.DataSource = dataProvider.GetBindingList();
        }

        private void SideMenu_ItemClick(string title, object tag)
        {
            if (!(tag is EmbaddedForm))
                throw new NotSupportedException();

            var formType = (EmbaddedForm)tag;
            formTabControl.AddTab(title, formFactory.New(formType));
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void CbCurrentWarehouse_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
