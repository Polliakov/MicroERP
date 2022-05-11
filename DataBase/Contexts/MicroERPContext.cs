using DataBase.Entities;
using System.Data.Entity;

namespace DataBase.Contexts
{

    public class MicroERPContext : DbContext
    {
        public MicroERPContext() : base("name=DefaultConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Cheque> Cheques { get; set; }
        public DbSet<ProductPicking> ProductPickings { get; set; }
        public DbSet<ProductWriteOf> ProductWriteOfs { get; set; }
        public DbSet<ProductSell> ProductsSells { get; set; }
        public DbSet<ProductInPicking> ProductsInPickings { get; set; }
        public DbSet<ProductInWriteOf> ProductsInWriteOfs { get; set; }
        public DbSet<ProductInWarehouse> ProductsInWarehouses { get; set; }
    }
}
