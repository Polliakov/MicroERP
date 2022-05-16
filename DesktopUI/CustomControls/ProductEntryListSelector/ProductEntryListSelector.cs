using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using DataBase.Entities;
using DesktopUI.CustomControls.EntitySelector;
using BL.DataProviders;
using BL.Models;

namespace DesktopUI.CustomControls.ProductEntryListSelector
{
    public partial class ProductEntryListSelector<TEntry> : UserControl
        where TEntry : IProductEntry, new()
    {
        public ProductEntryListSelector()
        {
            var dataProvider = new DataProvider<Product>();
            var entitySelector = new EntitySelector<Product>(dataProvider);

            InitializeComponent();
            pnlEntitySelector.Controls.Add(entitySelector);
            entitySelector.EntitySelected += AddEntryToList;
        }

        public ProductEntryListSelector(Warehouse warehouse)
        {
            var dataProvider = new ProducLeftDataProvider(warehouse);
            var entitySelector = new EntitySelector<ProductLeftModel>(dataProvider);

            InitializeComponent();
            pnlEntitySelector.Controls.Add(entitySelector);
            entitySelector.EntitySelected += AddEntryToList;
        }

        public string ListTitle { get => lblEntryList.Text; set => lblEntryList.Text = value; }
        public string SelectorTitle { get => lblSelector.Text; set => lblSelector.Text = value; }

        public IEnumerable<TEntry> GetEntries() => productEntryList.GetProductEntries().Cast<TEntry>();

        public void Clear() => productEntryList.Clear();

        private void AddEntryToList(Product product)
        {
            var entry = (IProductEntry)new TEntry();
            entry.Count = 1;
            entry.Product = product;
            productEntryList.Add(entry);
        }

        private void AddEntryToList(ProductLeftModel productLeft)
        {
            var entry = (IProductEntry)new TEntry();
            entry.Count = 1;
            entry.Product = productLeft.Product;
            productEntryList.Add(entry, productLeft.Count);
        }
    }
}
