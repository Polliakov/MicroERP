namespace DataBase.Migrations
{
    using DataBase.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataBase.Contexts.MicroERPContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataBase.Contexts.MicroERPContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Users.AddOrUpdate(new User
            {
                Name = "admin",
                Surname = "admin",
                Patronymic = null,
                PhoneNumber = "10000000000",
                // Password = "admin";
                Password = Convert.FromBase64String("G9xQ6LeCTRLoe4PuVhvcVoDJtcpx/dNsmLvRSC1VSdi7qw7v9hA391l40Y+oxVb4udGkCIZTe4zLKLvShek4Yw=="),
                Role = UserRole.Administrator,
            });
        }
    }
}
