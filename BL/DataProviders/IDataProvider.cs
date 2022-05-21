using System.Linq;

namespace BL.DataProviders
{
    public interface IDataProvider<out T>
    {
        IQueryable<T> GetData(bool getDeleted = false);
        void Save();
    }
}
