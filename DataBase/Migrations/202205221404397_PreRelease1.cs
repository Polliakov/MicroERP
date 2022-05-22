namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PreRelease1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Users", new[] { "PhoneNumber" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Users", "PhoneNumber", unique: true);
        }
    }
}
