namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PreRelease : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Deleted", c => c.DateTime());
            AddColumn("dbo.ProductCategories", "Deleted", c => c.DateTime());
            AddColumn("dbo.Users", "Deleted", c => c.DateTime());
            AddColumn("dbo.Warehouses", "Deleted", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Warehouses", "Deleted");
            DropColumn("dbo.Users", "Deleted");
            DropColumn("dbo.ProductCategories", "Deleted");
            DropColumn("dbo.Products", "Deleted");
        }
    }
}
