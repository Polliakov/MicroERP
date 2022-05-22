using DataBase.Contexts;
using DataBase.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace BL.DataProviders
{
    public class DeletableDataProvider<TDeletable> : IDataProvider<TDeletable>
        where TDeletable : class, IDeletable
    {
        private readonly MicroERPContext db = MicroERPContextSingleton.Instanse;

        public DeletableDataProvider()
        {
            set = db.Set<TDeletable>();
        }

        private readonly DbSet<TDeletable> set;

        public IQueryable<TDeletable> GetData() => set.Where(entity => !entity.Deleted.HasValue);

        public IQueryable<TDeletable> GetDeletedData() => set.Where(entity => entity.Deleted.HasValue);

        public BindingList<TDeletable> GetBindingList()
        {
            var list = (IList<TDeletable>)GetData().ToListAsync().Result;
            return new BindingList<TDeletable>(list);
        }

        public void Save() => db.SaveChanges();
    }
}
