using DataBase.Entities;
using System.Windows.Forms;

namespace DesktopUI.Forms.ViewForms
{
    public abstract class ViewForm
    {
        public static Form NewFor<TEntity>(TEntity entity)
        {
            var entityType = typeof(TEntity);
            if (entityType == typeof(Cheque))
                return new ChequeViewForm(entity as Cheque);
            if (entityType == typeof(ProductWriteOf))
                return new ProductWriteOfViewForm(entity as ProductWriteOf);
            if (entityType == typeof(ProductPicking))
                return new ProductPickingViewForm(entity as ProductPicking);
            if (entityType == typeof(Warehouse))
                return new WarehouseViewForm(entity as Warehouse);
            if (entityType == typeof(User))
                return new UserViewForm(entity as User);

            return null;
        }
    }
}
