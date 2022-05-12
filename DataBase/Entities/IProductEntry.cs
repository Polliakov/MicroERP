namespace DataBase.Entities
{
    public interface IProductEntry
    {
        int Count { get; set; }
        Product Product { get; set; }
    }
}
