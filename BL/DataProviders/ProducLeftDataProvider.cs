using BL.Models;
using DataBase.Contexts;
using DataBase.Entities;
using System.Linq;

namespace BL.DataProviders
{
    public class ProducLeftDataProvider : IDataProvider<ProductLeftModel>
    {
        private readonly MicroERPContext db = MicroERPContextSingleton.Instanse;

        public ProducLeftDataProvider(Warehouse warehouse)
        {
            this.warehouse = warehouse;
        }

        private readonly Warehouse warehouse;

        public void Save() => db.SaveChanges();

        public IQueryable<ProductLeftModel> GetData()
        {
            return db.ProductsInWarehouses
                   .Where(pw => pw.Warehouse.Id == warehouse.Id && pw.Count > 0)
                   .Select(pw => new ProductLeftModel
                   {
                       Name = pw.Product.Name,
                       Price = pw.Product.Price,
                       Count = pw.Count,
                       Description = pw.Product.Description,
                       Product = pw.Product,
                       Warehouse = pw.Warehouse,
                   });
        }
    }
}
