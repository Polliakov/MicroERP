using System.ComponentModel;
using System.Linq;

namespace BL.DataProviders
{
    public interface IDataProvider<T>
    {
        IQueryable<T> GetData();
        BindingList<T> GetBindingList();
        void Save();
    }
}
