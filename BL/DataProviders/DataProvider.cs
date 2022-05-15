using DataBase.Contexts;
using System.Collections.Generic;
using System.Data.Entity;

namespace BL.DataProviders
{
    public class DataProvider<TEntity>
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

        public DbSet<TEntity> GetDbSet() => set;
        public DbSet<TEntity> GetDbSet(List<Filter<TEntity>> filters)
        {
            IEnumerable<TEntity> result = set;
            foreach (var filter in filters)
                result = filter.Apply(result);
            return result as DbSet<TEntity>;
        }
    }
}
