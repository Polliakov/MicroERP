using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.Contexts;
using DataBase.Entities;

namespace BL.DataProviders
{
    public class DataProvider<TEntity>
        where TEntity : class
    {
        public DataProvider(DbSet<TEntity> set)
        {
            this.set = set;
        }

        private readonly DbSet<TEntity> set;

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
