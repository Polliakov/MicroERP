using DataBase.Contexts;
using DataBase.Entities;
using DataBase.Interfaces;
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

        private readonly MicroERPContext db = MicroERPContextSingleton.Instanse;
        private readonly IQueryable<TEntity> set;

        public IQueryable<TEntity> GetData() => set;
    }
}
