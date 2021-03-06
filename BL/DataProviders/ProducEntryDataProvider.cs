using BL.Models;
using DataBase.Contexts;
using DataBase.Entities;
using DataBase.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace BL.DataProviders
{
    public class ProducEntryDataProvider : IDataProvider<ProductEntryModel>
    {
        public ProducEntryDataProvider(Warehouse warehouse)
        {
            var productsInWarehouse = db.ProductsInWarehouses
                .Where(pw => pw.WarehouseID == warehouse.Id && pw.Count > 0);
            set = SelectProductEntries(productsInWarehouse);
        }

        public ProducEntryDataProvider(Cheque cheque)
        {
            var productSells = db.ProductsSells.Where(ps => ps.ChequeId == cheque.Id);
            set = SelectProductEntries(productSells);
        }

        public ProducEntryDataProvider(ProductWriteOf writeOf)
        {
            var productsInWriteOf = db.ProductsInWriteOfs.Where(pw => pw.WriteOfId == writeOf.Id);
            set = SelectProductEntries(productsInWriteOf);
        }

        public ProducEntryDataProvider(ProductPicking picking)
        {
            var productsInPicking = db.ProductsInPickings.Where(pp => pp.PickingId == picking.Id);
            set = SelectProductEntries(productsInPicking);
        }

        private readonly MicroERPContext db = MicroERPContextSingleton.Instanse;
        private readonly IQueryable<ProductEntryModel> set;

        public IQueryable<ProductEntryModel> GetData() => set;

        public BindingList<ProductEntryModel> GetBindingList()
        {
            var list = (IList<ProductEntryModel>)GetData().ToListAsync().Result;
            return new BindingList<ProductEntryModel>(list);
        }

        public void Save() => db.SaveChanges();

        private IQueryable<ProductEntryModel> SelectProductEntries(IQueryable<IProductEntry> entries)
        {
            return entries.Select(pw => new ProductEntryModel
            {
                Name = pw.Product.Name,
                Price = pw.Product.Price,
                Count = pw.Count,
                Description = pw.Product.Description,
                Product = pw.Product,
            });
        }
    }
}
