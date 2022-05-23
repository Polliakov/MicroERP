namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Release : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cheques", "WarehouseId", c => c.Int(nullable: false));
            AddColumn("dbo.ProductPickings", "WarehouseId", c => c.Int(nullable: false));
            AddColumn("dbo.ProductWriteOfs", "WarehouseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cheques", "WarehouseId");
            CreateIndex("dbo.ProductPickings", "WarehouseId");
            CreateIndex("dbo.ProductWriteOfs", "WarehouseId");
            AddForeignKey("dbo.ProductWriteOfs", "WarehouseId", "dbo.Warehouses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductPickings", "WarehouseId", "dbo.Warehouses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cheques", "WarehouseId", "dbo.Warehouses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cheques", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.ProductPickings", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.ProductWriteOfs", "WarehouseId", "dbo.Warehouses");
            DropIndex("dbo.ProductWriteOfs", new[] { "WarehouseId" });
            DropIndex("dbo.ProductPickings", new[] { "WarehouseId" });
            DropIndex("dbo.Cheques", new[] { "WarehouseId" });
            DropColumn("dbo.ProductWriteOfs", "WarehouseId");
            DropColumn("dbo.ProductPickings", "WarehouseId");
            DropColumn("dbo.Cheques", "WarehouseId");
        }
    }
}
