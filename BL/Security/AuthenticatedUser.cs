using DataBase.Contexts;
using DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Security
{
    public class AuthenticatedUser
    {
        public UserRole Role { get => user.Role; }
        public User User { get => user; }
        //public string Name { get => user.Name; }
        //public string Surname { get => user.Surname; }
        //public string Patronymic { get => user.Patronymic; }
        //public string PhoneNumber { get => user.PhoneNumber; }

        private readonly User user;

        private AuthenticatedUser(User user)
        {
            this.user = user;
        }

        public static AuthenticatedUser Authenticate(string login, string password)
        {
            using (var db = new MicroERPContext())
            {
                var user = db.Users.FirstOrDefault(u => u.PhoneNumber == login);
                if (user is null)
                    throw new UserIdentificationException();
                var passwordHash = PasswordHash.Calculate(password);
                if (!PasswordsAreEqual(user.Password, passwordHash))
                    throw new UserAuthenticationException();
                return new AuthenticatedUser(user);
            }
        }

        private static bool PasswordsAreEqual(byte[] pass1, byte[] pass2)
        {
            for (int i = 0; i < pass1.Length; i++)
                if (pass1[i] != pass2[i]) return false;
            return true;
        }
    }
}
