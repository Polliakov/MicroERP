using DataBase.Entities;

namespace DataBase.Interfaces
{
    public interface IProductEntry
    {
        int Count { get; set; }
        Product Product { get; set; }
    }
}
