using BL.DataProviders;
using DataBase.Entities;
using System;
using System.Windows.Forms;
using DesktopUI.Forms.ProductOperationsForms;
using DesktopUI.Forms.AddingForms;
using BL.Security;
using DesktopUI.Forms.ViewForms;

namespace DesktopUI.Forms
{
    public enum EmbaddedForm
    {
        ChequeDataForm,
        ProductDataForm,
        ProductCategoryDataForm,
        ProductPickingDataForm,
        ProductWriteOfDataForm,
        UserDataForm,
        WarehouseDataForm,
        CreateChequeForm,
        CreatePickingForm,
        CreateWriteOfForm,
        AddWarehouseForm,
        AddProductForm,
        AddProductCategoryForm,
        AddUserForm,
    }

    public class FormFactory
    {
        public FormFactory(AuthenticatedUser currentUser, Warehouse warehouse)
        {
            this.currentUser = currentUser;
            this.warehouse = warehouse;
        }

        private AuthenticatedUser currentUser;
        private Warehouse warehouse;

        public Form New(EmbaddedForm formType)
        {
            switch (formType)
            {
                // DataForms
                case EmbaddedForm.ChequeDataForm:
                    return new DataForm<Cheque>(new DataProvider<Cheque>(), currentUser.Role);
                case EmbaddedForm.ProductDataForm: 
                    return new DataForm<Product>(new DataProvider<Product>(), currentUser.Role);
                case EmbaddedForm.ProductCategoryDataForm:
                    return new DataForm<ProductCategory>(new DataProvider<ProductCategory>(), currentUser.Role);
                case EmbaddedForm.ProductPickingDataForm:
                    return new DataForm<ProductPicking>(new DataProvider<ProductPicking>(), currentUser.Role);
                case EmbaddedForm.ProductWriteOfDataForm:
                    return new DataForm<ProductWriteOf>(new DataProvider<ProductWriteOf>(), currentUser.Role);
                case EmbaddedForm.UserDataForm: 
                    return new DataForm<User>(new DataProvider<User>(), currentUser.Role);
                case EmbaddedForm.WarehouseDataForm:
                    return new DataForm<Warehouse>(new DataProvider<Warehouse>(), currentUser.Role);

                // ProductOperationsForms
                case EmbaddedForm.CreatePickingForm:
                    return new CreatePickingForm(currentUser);
                case EmbaddedForm.CreateChequeForm:
                    return new CreateCheqeForm(currentUser, warehouse);
                case EmbaddedForm.CreateWriteOfForm:
                    return new CreateWriteOfForm(currentUser, warehouse);

                // AddingForms
                case EmbaddedForm.AddProductForm:
                    return new AddProductForm();
                case EmbaddedForm.AddProductCategoryForm:
                    return new AddProductCategoryForm();
                case EmbaddedForm.AddWarehouseForm:
                    return new AddWarehouseForm();
                case EmbaddedForm.AddUserForm:
                    return new AddUserForm();
            }
            throw new NotImplementedException();
        }

        public void WarehouseChanged(Warehouse warehouse)
        {
            this.warehouse = warehouse;
        }
    }
}