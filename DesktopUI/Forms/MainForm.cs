using BL.DataProviders;
using BL.Security;
using BL.Services;
using DataBase.Entities;
using DesktopUI.CustomControls.SideMenu;
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
            AddSideMenuItems();
            UpdateCbCurrentWarehouse();
            LoadCbWarehouseIndex();
            lblCurrentUser.Text = currentUser.User.GetFullNameShort();

            formFactory = new FormFactory(this, currentUser);
            WarehouseChanged += formFactory.WarehouseChanged;

            cbCurrentWarehouse.SelectedIndexChanged += (_, e) => WarehouseChanged.Invoke(GetCurrentWarehouse());
            sideMenuView.ItemClick += SideMenu_ItemClick;
            sideMenuAdd.ItemClick += SideMenu_ItemClick;

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
            if (currentUser.Role == UserRole.Administrator)
            {
                sideMenuAdd.AddItem("Склад", EmbaddedForm.AddWarehouseForm);
                sideMenuAdd.AddItem("Пользователь", EmbaddedForm.AddUserForm);
                sideMenuAdd.AddItem("Категория", EmbaddedForm.AddProductCategoryForm);
                sideMenuAdd.AddItem("Товар", EmbaddedForm.AddProductForm);
                sideMenuAdd.AddItem("Списание", EmbaddedForm.CreateWriteOfForm);
                sideMenuAdd.AddItem("Поставка", EmbaddedForm.CreatePickingForm);
            }
            sideMenuAdd.AddItem("Продажа", EmbaddedForm.CreateChequeForm);

            sideMenuView.AddItem("Склады", EmbaddedForm.WarehouseDataForm);
            sideMenuView.AddItem("Пользователи", EmbaddedForm.UserDataForm);
            sideMenuView.AddItem("Категории", EmbaddedForm.ProductCategoryDataForm);
            sideMenuView.AddItem("Товары", EmbaddedForm.ProductDataForm);
            sideMenuView.AddItem("Списания", EmbaddedForm.ProductWriteOfDataForm);
            sideMenuView.AddItem("Поставки", EmbaddedForm.ProductPickingDataForm);
            sideMenuView.AddItem("Продажи", EmbaddedForm.ChequeDataForm);
        }

        private void UpdateCbCurrentWarehouse()
        {
            int selected = cbCurrentWarehouse.SelectedIndex;
            var dataProvider = new DeletableDataProvider<Warehouse>();
            cbCurrentWarehouse.DataSource = dataProvider.GetBindingList();
            if (selected != -1)
                cbCurrentWarehouse.SelectedIndex = selected;
        }

        private void SideMenu_ItemClick(SideMenu sender, string title, object tag)
        {
            if (!(tag is EmbaddedForm))
                throw new NotSupportedException();

            if (sender == sideMenuAdd) title = "+ " + title;
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

        private void LblCurrentUser_Click(object sender, EventArgs e)
        {
            var userView = ViewForms.ViewForm.NewFor(currentUser.User);
            userView.Text = "Текущий пользователь";
            userView.Show();
        }

        private void SaveCbWarehouseIndex()
        {
            var index = cbCurrentWarehouse.SelectedIndex;
            new UserSessionService().SetCurrentWarehousehouseIndex(index);
        }

        private void LoadCbWarehouseIndex()
        {
            try
            {
                var index = new UserSessionService().GetCurrentWarehousehouseIndex();
                if (index == -1) return;
                if (cbCurrentWarehouse.Items.Count > index)
                    cbCurrentWarehouse.SelectedIndex = index;
            }
            catch { /* Do nothing. */ }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try { SaveCbWarehouseIndex(); }
            catch { /* Do nothing. */ }
            Application.Exit();
        }

        private void CbCurrentWarehouse_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
