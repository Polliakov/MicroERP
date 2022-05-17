using BL.Security;
using DataBase.Contexts;
using DataBase.Entities;
using System.Linq;


namespace MicroERPTests
{
    public static class UsersTestData
    {
        public const string Login = "20000000000";
        public const string Password = "qwe123";
        public const string AdminLogin = "10000000000";
        public const string AdminPassword = "123";

        private static bool isCashierCreated = false;
        private static bool isAdminCreated = false;

        public static void TryCreateTestUsers()
        {
            using (var db = new MicroERPContext())
            {
                if (!isCashierCreated && 
                    db.Users.FirstOrDefault(u => u.PhoneNumber == Login) is null)
                {
                    db.Users.Add(new User
                    {
                        Name = "TestCashierName",
                        Surname = "TestCashierSurname",
                        PhoneNumber = Login,
                        Password = PasswordHash.Calculate(Password, Login),
                        Role = UserRole.Cashier,
                    });
                    db.SaveChanges();
                    isCashierCreated = true;
                }
                if (!isAdminCreated && 
                    db.Users.FirstOrDefault(u => u.PhoneNumber == AdminLogin) is null)
                {
                    db.Users.Add(new User
                    {
                        Name = "TestAdminName",
                        Surname = "TestAdminSurname",
                        Patronymic = "TestAdminPatronymic",
                        PhoneNumber = AdminLogin,
                        Password = PasswordHash.Calculate(AdminPassword, AdminLogin),
                        Role = UserRole.Administrator,
                    });
                    db.SaveChanges();
                    isAdminCreated = true;
                }
            }           
        }
    }
}
