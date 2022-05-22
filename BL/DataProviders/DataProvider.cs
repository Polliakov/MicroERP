using DataBase.Contexts;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace BL.DataProviders
{
    public class DataProvider<TEntity> : IDataProvider<TEntity>
        where TEntity : class
    {
        private readonly MicroERPContext db = MicroERPContextSingleton.Instanse;

        public DataProvider()
        {
            set = db.Set<TEntity>();
        }

        private readonly DbSet<TEntity> set;

        public void Add(TEntity entity) => set.Add(entity);

        public void Create(TEntity entity)
        {
            set.Add(entity);
            db.SaveChanges();
        }

        public IQueryable<TEntity> GetData() => set;

        public BindingList<TEntity> GetBindingList()
        {
            var list = (IList<TEntity>)GetData().ToListAsync().Result;
            return new BindingList<TEntity>(list);
        }

        public void Save() => db.SaveChanges();
    }
}
