using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataBase.Contexts;
using DataBase.Entities;
using BL.Security;

namespace MicroERPTests
{
    [TestClass]
    public class UserAuthenticationTest
    {
        [TestMethod]
        public void TestRightAuthentication()
        {
            using (var db = new MicroERPContext())
            {
                UsersTestData.TryCreateTestCashier();
                AuthenticatedUser.Authenticate(UsersTestData.Login, UsersTestData.Password);
            }
        }

        [TestMethod]
        public void TestWrongAuthentication()
        {
            using(var db = new MicroERPContext())
            {
                UsersTestData.TryCreateTestCashier();
                bool authResult1 = true;
                bool authResult2 = true;

                try   { AuthenticatedUser.Authenticate(UsersTestData.Login, UsersTestData.Password + "123"); }
                catch { authResult1 = false; }
                try   { AuthenticatedUser.Authenticate(UsersTestData.Login.Replace('0', '1'), UsersTestData.Password); }
                catch { authResult2 = false; }             

                Assert.IsFalse(authResult1 || authResult2);
            }
        }
    }
}
