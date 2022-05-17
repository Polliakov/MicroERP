using BL.Models;
using DataBase.Contexts;
using DataBase.Entities;
using System.Linq;

namespace BL.DataProviders
{
    public class ProducEntryDataProvider : IDataProvider<ProductEntryModel>
    {
        private readonly MicroERPContext db = MicroERPContextSingleton.Instanse;

        public ProducEntryDataProvider(Warehouse warehouse)
        {
            this.warehouse = warehouse;
        }

        private readonly Warehouse warehouse;

        public void Save() => db.SaveChanges();

        public IQueryable<ProductEntryModel> GetData()
        {
            return db.ProductsInWarehouses
                   .Where(pw => pw.Warehouse.Id == warehouse.Id && pw.Count > 0)
                   .Select(pw => new ProductEntryModel
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
