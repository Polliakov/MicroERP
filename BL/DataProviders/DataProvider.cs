using DataBase.Contexts;
using System.Collections.Generic;
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

        public void Save() => db.SaveChanges();

        public void Create(TEntity entity)
        {
            set.Add(entity);
            db.SaveChanges();
        }

        IQueryable<TEntity> IDataProvider<TEntity>.GetData() => GetData();

        public DbSet<TEntity> GetData() => set;
        public DbSet<TEntity> GetData(List<Filter<TEntity>> filters)
        {
            IEnumerable<TEntity> result = set;
            foreach (var filter in filters)
                result = filter.Apply(result);
            return result as DbSet<TEntity>;
        }
    }
}
