using DataBase.Contexts;
using DataBase.Interfaces;
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

        public IQueryable<TDeletable> GetData(bool getDeleted = false)
        {
            if (getDeleted) return set;

            return set.Where(entity => !entity.Deleted.HasValue);
        }

        public void Save() => db.SaveChanges();
    }
}
