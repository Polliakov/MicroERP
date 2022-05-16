using BL.DataProviders;
using System.Data.Entity;
using System.Windows.Forms;

namespace DesktopUI.EmbeddedForms
{
    public partial class DataForm<TEntity> : Form
        where TEntity : class
    {
        public DataForm()
        {
            InitializeComponent();
            var set = dataProvider.GetData();
            set.Load();
            dataGridView.DataSource = set.Local.ToBindingList();
        }

        private readonly DataProvider<TEntity> dataProvider = new DataProvider<TEntity>();
    }
}
