using DataBase.Contexts;
using DataBase.Entities;
using DataBase.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace BL.DataProviders
{
    public class ProductOperationDataProvider<TEntity> : IDataProvider<TEntity>
        where TEntity : class, IProductOperation
    {
        public ProductOperationDataProvider()
        {
            set = db.Set<TEntity>();
        }

        public ProductOperationDataProvider(User user)
        {
            set = db.Set<TEntity>().Where(po => po.UserId == user.Id);
        }

        public ProductOperationDataProvider(Warehouse warehouse)
        {
            set = db.Set<TEntity>().Where(po => po.WarehouseId == warehouse.Id);
        }

        private readonly MicroERPContext db = MicroERPContextSingleton.Instanse;
        private readonly IQueryable<TEntity> set;

        public IQueryable<TEntity> GetData() => set;

        public BindingList<TEntity> GetBindingList()
        {
            var list = (IList<TEntity>)GetData().ToListAsync().Result;
            return new BindingList<TEntity>(list);
        }

        public void Save() => db.SaveChanges();
    }
}
