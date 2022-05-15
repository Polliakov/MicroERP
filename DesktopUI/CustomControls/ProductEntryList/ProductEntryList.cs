using DataBase.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DesktopUI.CustomControls.ProductEntryList
{
    public partial class ProductEntryList : UserControl
    {
        public ProductEntryList()
        {
            InitializeComponent();
        }

        public List<ProductEntryListItem> Items { get; } = new List<ProductEntryListItem>();

        public void Add(IProductEntry productEntry)
        {
            var existsItem = Items.FirstOrDefault(i => i.ProductEntry.Product == productEntry.Product);
            if (!(existsItem is null))
            {
                existsItem.IncreaseCount(1);
                return;
            }

            var item = new ProductEntryListItem(productEntry, this);
            item.Close += Remove;
            Items.Add(item);
        }

        public IEnumerable<IProductEntry> GetProductEntries() => Items.Select(item => item.ProductEntry);

        public void Clear()
        {
            Items.ForEach(item => item.Dispose());
            Items.Clear();
        }

        private void Remove(ProductEntryListItem item)
        {
            Items.Remove(item);
            item.Dispose();
        }
    }
}
