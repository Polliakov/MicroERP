using BL.DataProviders;
using BL.Security;
using DataBase.Contexts;
using DataBase.Entities;
using DesktopUI.EmbeddedForms;
using System;
using System.Windows.Forms;

namespace DesktopUI
{
    public partial class MainForm : Form
    {
        public MainForm(AuthenticatedUser currentUser)
        {
            this.currentUser = currentUser;
            InitializeComponent();
            AddSideMenuItems();
        }

        private readonly EmbaddedFormFactory embaddedFormFactory = new EmbaddedFormFactory();
        private readonly AuthenticatedUser currentUser;

        private void AddSideMenuItems()
        {
            sideMenu.ItemClick += SideMenu_ItemClick;

            sideMenu.AddItem("Товары", EmbaddedForm.ProductDataForm);
            sideMenu.AddItem("Продать", EmbaddedForm.CreateChequeForm);

            if (currentUser.Role != UserRole.Administrator) return;

            sideMenu.AddItem("Новый пользователь", EmbaddedForm.AddUserForm);
            sideMenu.AddItem("Новый склад", EmbaddedForm.AddWarehouseForm);
            sideMenu.AddItem("Продажи", EmbaddedForm.ChequeDataForm);
            sideMenu.AddItem("Поставки", EmbaddedForm.ProductPickingDataForm);
            sideMenu.AddItem("Списания", EmbaddedForm.ProductWriteOfDataForm);
            sideMenu.AddItem("Пользователи", EmbaddedForm.UserDataForm);
            sideMenu.AddItem("Склады", EmbaddedForm.WarehouseDataForm);
        }

        private void SideMenu_ItemClick(string title, object tag)
        {
            if (!(tag is EmbaddedForm))
                throw new NotSupportedException();
            var formType = (EmbaddedForm)tag;
            formTabControl.AddTab(title, embaddedFormFactory.New(formType));
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MicroERPContextSingleton.Instanse.SaveChanges();
            Application.Exit();
        }
    }
}
