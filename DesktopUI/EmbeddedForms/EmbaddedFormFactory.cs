using BL.DataProviders;
using DataBase.Entities;
using System;
using System.Windows.Forms;
using DesktopUI.EmbeddedForms.ProductOperationsForms;
using DesktopUI.EmbeddedForms.AddingForms;
using BL.Security;

namespace DesktopUI.EmbeddedForms
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

    public class EmbaddedFormFactory
    {
        public EmbaddedFormFactory(AuthenticatedUser currentUser, Warehouse warehouse)
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
                    return new DataForm<Cheque>();
                case EmbaddedForm.ProductDataForm: 
                    return new DataForm<Product>();
                case EmbaddedForm.ProductCategoryDataForm:
                    return new DataForm<ProductCategory>();
                case EmbaddedForm.ProductPickingDataForm:
                    return new DataForm<ProductPicking>();
                case EmbaddedForm.ProductWriteOfDataForm:
                    return new DataForm<ProductWriteOf>();
                case EmbaddedForm.UserDataForm: 
                    return new DataForm<User>();
                case EmbaddedForm.WarehouseDataForm:
                    return new DataForm<Warehouse>();

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