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

        private static bool isCashierCreated = false;

        public static void TryCreateTestCashier()
        {
            using (var db = new MicroERPContext())
            {
                if (!isCashierCreated && db.Users.Count(u => u.PhoneNumber == Login) == 0)
                {
                    db.Users.Add(new User
                    {
                        Name = "TestCashierName",
                        Surname = "TestCashierSurname",
                        PhoneNumber = Login,
                        Password = PasswordHash.Calculate(Password),
                        Role = UserRole.Cashier,
                    });
                    db.SaveChanges();
                    isCashierCreated = true;
                }
            }           
        }
    }
}
