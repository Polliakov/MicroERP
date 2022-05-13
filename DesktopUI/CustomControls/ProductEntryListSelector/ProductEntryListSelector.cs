using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using DataBase.Entities;
using DesktopUI.CustomControls.EntitySelector;

namespace DesktopUI.CustomControls.ProductEntryListSelector
{
    public partial class ProductEntryListSelector<TEntry> : UserControl
        where TEntry : IProductEntry, new()
    {
        public ProductEntryListSelector()
        {
            InitializeComponent();
            pnlEntitySelector.Controls.Add(entitySelector);
            entitySelector.EntitySelected += AddEntryToList;
        }

        public string ListTitle { get => lblEntryList.Text; set => lblEntryList.Text = value; }
        public string SelectorTitle { get => lblSelector.Text; set => lblSelector.Text = value; }

        private readonly EntitySelector<Product> entitySelector = new EntitySelector<Product>();

        public IEnumerable<TEntry> GetEntries() => productEntryList.GetProductEntries().Cast<TEntry>();

        private void AddEntryToList(Product product)
        {
            var entry = (IProductEntry)(new TEntry());
            entry.Product = product;
            productEntryList.Add(entry);
        }
    }
}
