using BL.DataProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows.Forms;

namespace DesktopUI.CustomControls.EntitySelector
{
    public partial class EntitySelector<TEntity> : UserControl
        where TEntity : class
    {
        public EntitySelector(IDataProvider<TEntity> dataProvider)
        {
            var set = dataProvider.GetData();
            var list = (IList<TEntity>)set.ToListAsync().Result;

            InitializeComponent();
            dataGridView.DataSource = new BindingList<TEntity>(list);
        }

        public event Action<TEntity> EntitySelected;

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var entity = (TEntity)dataGridView.Rows[e.RowIndex].DataBoundItem;
            EntitySelected.Invoke(entity);
        }
    }
}
