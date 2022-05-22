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
            UpdateCbCurrentWarehouse();
            AddSideMenuItems();

            formFactory = new FormFactory(this, currentUser);
            WarehouseChanged += formFactory.WarehouseChanged;

            cbCurrentWarehouse.SelectedIndexChanged += (_, e) => WarehouseChanged.Invoke(GetCurrentWarehouse());
            sideMenu.ItemClick += SideMenu_ItemClick;

            WarehouseChanged.Invoke(GetCurrentWarehouse());
        }

        public event Action<Warehouse> WarehouseChanged;

        private readonly FormFactory formFactory;
        private readonly AuthenticatedUser currentUser;

        public void OnWarehouseAdded(Warehouse warehouse)
        {
            UpdateCbCurrentWarehouse();
        }

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

        private void UpdateCbCurrentWarehouse()
        {
            int selected = cbCurrentWarehouse.SelectedIndex;
            var dataProvider = new DeletableDataProvider<Warehouse>();
            cbCurrentWarehouse.DataSource = dataProvider.GetBindingList();
            if (selected != -1)
                cbCurrentWarehouse.SelectedIndex = selected;
        }

        private void SideMenu_ItemClick(string title, object tag)
        {
            if (!(tag is EmbaddedForm))
                throw new NotSupportedException();
            try
            {
                var formType = (EmbaddedForm)tag;
                formTabControl.AddTab(title, formFactory.New(formType));
            }
            catch (WarehouseIsNullException)
            {
                MessageBox.Show("Сначала нужно добавить склад.", "Отсутствуют склады");
            }
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
