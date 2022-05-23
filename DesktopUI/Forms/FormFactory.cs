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
        public FormFactory(MainForm mainForm, AuthenticatedUser currentUser)
        {
            this.mainForm = mainForm;
            this.currentUser = currentUser;
        }

        private readonly MainForm mainForm;
        private readonly AuthenticatedUser currentUser;
        private Warehouse warehouse;

        public Form New(EmbaddedForm formType)
        {
            switch (formType)
            {
                // DataForms - IProductOperation
                case EmbaddedForm.ChequeDataForm:
                    CheckWarehouseIsNull();
                    return new DataForm<Cheque>(
                        new ProductOperationDataProvider<Cheque>(warehouse),
                        currentUser.Role)
                        { Title = warehouse.ToString() };
                case EmbaddedForm.ProductPickingDataForm:
                    CheckWarehouseIsNull();
                    return new DataForm<ProductPicking>(
                        new ProductOperationDataProvider<ProductPicking>(warehouse), 
                        currentUser.Role)
                        { Title = warehouse.ToString() };
                case EmbaddedForm.ProductWriteOfDataForm:
                    CheckWarehouseIsNull();
                    return new DataForm<ProductWriteOf>(
                        new ProductOperationDataProvider<ProductWriteOf>(warehouse), 
                        currentUser.Role)
                        { Title = warehouse.ToString() };


                // DataForms - IDeletable
                case EmbaddedForm.ProductDataForm:
                    return new DataForm<Product>(new DeletableDataProvider<Product>(), currentUser.Role);
                case EmbaddedForm.ProductCategoryDataForm:
                    return new DataForm<ProductCategory>(new DeletableDataProvider<ProductCategory>(), currentUser.Role);
                case EmbaddedForm.UserDataForm: 
                    return new DataForm<User>(new DeletableDataProvider<User>(), currentUser.Role);
                case EmbaddedForm.WarehouseDataForm:
                    return new DataForm<Warehouse>(new DeletableDataProvider<Warehouse>(), currentUser.Role);

                // ProductOperationsForms
                case EmbaddedForm.CreatePickingForm:
                    CheckWarehouseIsNull();
                    return new CreatePickingForm(currentUser, warehouse);
                case EmbaddedForm.CreateChequeForm:
                    CheckWarehouseIsNull();
                    return new CreateCheqeForm(currentUser, warehouse);
                case EmbaddedForm.CreateWriteOfForm:
                    CheckWarehouseIsNull();
                    return new CreateWriteOfForm(currentUser, warehouse);

                // AddingForms
                case EmbaddedForm.AddProductForm:
                    return new AddProductForm();
                case EmbaddedForm.AddProductCategoryForm:
                    return new AddProductCategoryForm();
                case EmbaddedForm.AddWarehouseForm:
                    var addWarehouseForm = new AddWarehouseForm();
                    addWarehouseForm.WarehouseAdded += mainForm.OnWarehouseAdded;
                    return addWarehouseForm;
                case EmbaddedForm.AddUserForm:
                    return new AddUserForm();
            }
            throw new NotImplementedException();
        }

        public void WarehouseChanged(Warehouse warehouse)
        {
            this.warehouse = warehouse;
        }

        private void CheckWarehouseIsNull()
        {
            if (warehouse is null)
                throw new WarehouseIsNullException();
        }
    }
}