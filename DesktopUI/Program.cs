using BL.DataProviders;
using DataBase;
using DataBase.Entities;
using DesktopUI.Forms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DesktopUI
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var usersCount = new DeletableDataProvider<User>().GetData().Count();
            if (usersCount == 0)
            {
                DefaultAdministrator.SetAlive();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AuthenticationForm());
        }
    }
}
