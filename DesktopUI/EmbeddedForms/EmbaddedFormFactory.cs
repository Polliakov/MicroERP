﻿using BL.DataProviders;
using DataBase.Entities;
using System;
using System.Windows.Forms;
using DesktopUI.EmbeddedForms.ProductOperationsForms;
using DesktopUI.EmbeddedForms.AddingForms;

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
                case EmbaddedForm.CreateChequeForm:
                    return new CreateCheqeForm();

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
    }
}