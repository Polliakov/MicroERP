using DataBase.Contexts;
using DataBase.Entities;
using System;
using System.Linq;

namespace DataBase
{
    public static class DefaultAdministrator
    {
        public static void SetAlive()
        {
            var db = MicroERPContextSingleton.Instanse;
            var adminsPhone = "10000000000";
            var adminsName = "Default Admin";

            var admin = db.Users.FirstOrDefault(u => u.PhoneNumber == adminsPhone &&
                                                     u.Name == "_" &&
                                                     u.Surname == adminsName);
            if (admin is null)
            {
                db.Users.Add(new User
                {
                    Name = "_",
                    Surname = adminsName,
                    Patronymic = null,
                    PhoneNumber = adminsPhone,
                    // Password = "admin";
                    Password = Convert.FromBase64String("G9xQ6LeCTRLoe4PuVhvcVoDJtcpx/dNsmLvRSC1VSdi7qw7v9hA391l40Y+oxVb4udGkCIZTe4zLKLvShek4Yw=="),
                    Role = UserRole.Administrator,
                });
            }
            else
            {
                admin.Deleted = null;
            }
            db.SaveChanges();
        }
    }
}
