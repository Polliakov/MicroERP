using BL.DataProviders;
using BL.Security;
using DataBase.Entities;
using System;
using System.Linq;

namespace BL.Services
{
    public class CreateUserService
    {
        private DeletableDataProvider<User> dataProvider = new DeletableDataProvider<User>();

        public void Create(User user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            if (dataProvider
                    .GetData()
                    .Any(u => u.PhoneNumber == user.PhoneNumber))
                throw new UserIdentificationException();

            dataProvider.Create(user);
        }
    }
}
