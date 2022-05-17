using DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopUI.ViewForms
{
    public abstract class ViewForm<TEntity>
    {
        public static Form New(TEntity entity)
        {
            if (typeof(TEntity) == typeof(Cheque)) ;
            throw new NotImplementedException();
        }
    }
}
