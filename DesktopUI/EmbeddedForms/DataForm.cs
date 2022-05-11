using BL.DataProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopUI.EmbeddedForms
{
    public partial class DataForm<TEntity> : Form
        where TEntity : class
    {
        public DataForm(DataProvider<TEntity> dataProvider)
        {
            this.dataProvider = dataProvider;
            InitializeComponent();
            var set = dataProvider.GetDbSet();
            set.Load();
            dataGridView.DataSource = set.Local.ToBindingList();
        }

        private readonly DataProvider<TEntity> dataProvider;
    }
}
