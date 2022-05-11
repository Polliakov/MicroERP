using DataBase.Contexts;
using DataBase.Entities;

namespace BL.DataProviders
{
    public class DataProviderFactory
    {
        private readonly MicroERPContext db = MicroERPContextSingleton.Instanse;

        public DataProvider<Product> NewProductDataProvider()
        {
            return new DataProvider<Product>(db.Products);
        }
        public DataProvider<User> NewUserDataProvider()
        {
            return new DataProvider<User>(db.Users);
        }
    }
}
