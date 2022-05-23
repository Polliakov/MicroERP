using DataBase.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Attributes
{
    public class UserRoleConverter : EnumConverter
    {
        public UserRoleConverter(Type type) : base(type)
        {
            if (type != enumType)
                throw new NotSupportedException();
        }

        private readonly Type enumType = typeof(UserRole);
        private const string strCashier = "Кассир";
        private const string strAdministrator = "Администратор";

        public override object ConvertTo(
            ITypeDescriptorContext context, 
            CultureInfo culture, 
            object value, Type destType)
        {
            var userRole = (UserRole)value;
            switch (userRole)
            {
                case UserRole.Cashier: return strCashier;
                case UserRole.Administrator: return strAdministrator;
                default: return userRole.ToString();
            }
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var str = (string)value;
            switch (str)
            {
                case strCashier: return UserRole.Cashier;
                case strAdministrator: return UserRole.Administrator;
                default: return Enum.Parse(enumType, (string)value);
            }
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
        {
            return destType == typeof(string);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type srcType)
        {
            return srcType == typeof(string);
        }
    }
}
