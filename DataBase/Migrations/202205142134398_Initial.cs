namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cheques",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 14, scale: 2),
                        Timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ProductSells",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        ChequeId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.ChequeId })
                .ForeignKey("dbo.Cheques", t => t.ChequeId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.ChequeId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 12, scale: 2),
                        Description = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ParentCategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.ParentCategoryId)
                .Index(t => t.ParentCategoryId);
            
            CreateTable(
                "dbo.ProductInPickings",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        PickingId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.PickingId })
                .ForeignKey("dbo.ProductPickings", t => t.PickingId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.PickingId);
            
            CreateTable(
                "dbo.ProductPickings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Patronymic = c.String(),
                        PhoneNumber = c.String(nullable: false, maxLength: 11),
                        Password = c.Binary(maxLength: 64),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.PhoneNumber, unique: true);
            
            CreateTable(
                "dbo.ProductWriteOfs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ProductInWriteOfs",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        WriteOfId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.WriteOfId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.ProductWriteOfs", t => t.WriteOfId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.WriteOfId);
            
            CreateTable(
                "dbo.ProductInWarehouses",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        WarehouseID = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.WarehouseID })
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.WarehouseID);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductSells", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductInWarehouses", "WarehouseID", "dbo.Warehouses");
            DropForeignKey("dbo.ProductInWarehouses", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductInPickings", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductWriteOfs", "UserId", "dbo.Users");
            DropForeignKey("dbo.ProductInWriteOfs", "WriteOfId", "dbo.ProductWriteOfs");
            DropForeignKey("dbo.ProductInWriteOfs", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductPickings", "UserId", "dbo.Users");
            DropForeignKey("dbo.Cheques", "UserId", "dbo.Users");
            DropForeignKey("dbo.ProductInPickings", "PickingId", "dbo.ProductPickings");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.ProductCategories");
            DropForeignKey("dbo.ProductCategories", "ParentCategoryId", "dbo.ProductCategories");
            DropForeignKey("dbo.ProductSells", "ChequeId", "dbo.Cheques");
            DropIndex("dbo.ProductInWarehouses", new[] { "WarehouseID" });
            DropIndex("dbo.ProductInWarehouses", new[] { "ProductID" });
            DropIndex("dbo.ProductInWriteOfs", new[] { "WriteOfId" });
            DropIndex("dbo.ProductInWriteOfs", new[] { "ProductId" });
            DropIndex("dbo.ProductWriteOfs", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "PhoneNumber" });
            DropIndex("dbo.ProductPickings", new[] { "UserId" });
            DropIndex("dbo.ProductInPickings", new[] { "PickingId" });
            DropIndex("dbo.ProductInPickings", new[] { "ProductId" });
            DropIndex("dbo.ProductCategories", new[] { "ParentCategoryId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.ProductSells", new[] { "ChequeId" });
            DropIndex("dbo.ProductSells", new[] { "ProductId" });
            DropIndex("dbo.Cheques", new[] { "UserId" });
            DropTable("dbo.Warehouses");
            DropTable("dbo.ProductInWarehouses");
            DropTable("dbo.ProductInWriteOfs");
            DropTable("dbo.ProductWriteOfs");
            DropTable("dbo.Users");
            DropTable("dbo.ProductPickings");
            DropTable("dbo.ProductInPickings");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Products");
            DropTable("dbo.ProductSells");
            DropTable("dbo.Cheques");
        }
    }
}
