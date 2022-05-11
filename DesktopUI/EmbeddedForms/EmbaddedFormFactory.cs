using BL.DataProviders;
using DataBase.Entities;
using System;
using System.Windows.Forms;

namespace DesktopUI.EmbeddedForms
{
    public enum EmbaddedForm
    {
        ChequeDataForm,
        ProductDataForm,
        ProductPickingDataForm,
        ProductWriteOfDataForm,
        UserDataForm,
        WarehouseDataForm,
    }

    public class EmbaddedFormFactory
    {
        public Form New(EmbaddedForm formType)
        {
            switch (formType)
            {
                case EmbaddedForm.ChequeDataForm:
                    return new DataForm<Cheque>();
                case EmbaddedForm.ProductDataForm: 
                    return new DataForm<Product>();
                case EmbaddedForm.ProductPickingDataForm:
                    return new DataForm<ProductPicking>();
                case EmbaddedForm.ProductWriteOfDataForm:
                    return new DataForm<ProductWriteOf>();
                case EmbaddedForm.UserDataForm: 
                    return new DataForm<User>();
                case EmbaddedForm.WarehouseDataForm:
                    return new DataForm<Warehouse>();
            }
            throw new NotImplementedException();
        }
    }
}