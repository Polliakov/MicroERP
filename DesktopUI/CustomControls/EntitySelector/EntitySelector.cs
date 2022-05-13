using BL.DataProviders;
using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace DesktopUI.CustomControls.EntitySelector
{
    public partial class EntitySelector<TEntity> : UserControl
        where TEntity : class
    {
        public EntitySelector()
        {
            InitializeComponent();
            var set = dataProvider.GetDbSet();
            set.Load();
            dataGridView.DataSource = set.Local.ToBindingList();
        }

        public event Action<TEntity> EntitySelected;

        private readonly DataProvider<TEntity> dataProvider = new DataProvider<TEntity>();

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var entity = (TEntity)dataGridView.Rows[e.RowIndex].DataBoundItem;
            EntitySelected.Invoke(entity);
        }
    }
}
