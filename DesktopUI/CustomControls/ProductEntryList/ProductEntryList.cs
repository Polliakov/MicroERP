using DataBase.Interfaces;
using System;
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

        public event Action ItemChanged;

        public List<ProductEntryListItem> Items { get; } = new List<ProductEntryListItem>();

        public void Add(IProductEntry productEntry, int? maxCount = null)
        {
            var existsItem = Items.FirstOrDefault(i => i.ProductEntry.Product == productEntry.Product);
            if (!(existsItem is null))
            {
                existsItem.IncreaseCount(1);
                return;
            }

            var item = maxCount is null ? new ProductEntryListItem(productEntry, this) :
                                          new ProductEntryListItem(productEntry, this, maxCount.Value);
            item.Close += Remove;
            item.CountChanged += _ => ItemChanged.Invoke();
            Items.Add(item);
            ItemChanged.Invoke();
        }

        public IEnumerable<IProductEntry> GetProductEntries() => Items.Select(item => item.ProductEntry);

        public void Clear()
        {
            Items.ForEach(item => item.Dispose());
            Items.Clear();
            ItemChanged.Invoke();
        }

        private void Remove(ProductEntryListItem item)
        {
            Items.Remove(item);
            item.Dispose();
            ItemChanged.Invoke();
        }
    }
}
