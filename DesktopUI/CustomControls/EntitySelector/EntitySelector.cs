using BL.DataProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace DesktopUI.CustomControls.EntitySelector
{
    public partial class EntitySelector<TEntity> : UserControl, IRefreshable
        where TEntity : class
    {
        public EntitySelector(IDataProvider<TEntity> dataProvider)
        {
            data = dataProvider.GetData();

            InitializeComponent();
            RefreshData();
        }

        private readonly IQueryable<TEntity> data;

        public event Action<TEntity> EntitySelected;

        public void RefreshData()
        {
            var list = (IList<TEntity>)data.ToListAsync().Result;
            dataGridView.DataSource = new BindingList<TEntity>(list);
            dataGridView.ClearSelection();
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var entity = (TEntity)dataGridView.Rows[e.RowIndex].DataBoundItem;
            EntitySelected.Invoke(entity);
        }
    }
}
