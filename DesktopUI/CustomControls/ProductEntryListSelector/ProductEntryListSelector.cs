using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using DataBase.Entities;
using DesktopUI.CustomControls.EntitySelector;
using BL.DataProviders;
using BL.Models;
using System;

namespace DesktopUI.CustomControls.ProductEntryListSelector
{
    public partial class ProductEntryListSelector<TEntry> : UserControl
        where TEntry : IProductEntry, new()
    {
        public ProductEntryListSelector()
        {
            var dataProvider = new DataProvider<Product>();
            var entitySelector = new EntitySelector<Product>(dataProvider);

            btnRefreshData.BackgroundImage = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject("RefreshIcon");

            pnlEntitySelector.Controls.Add(entitySelector);
            entitySelector.EntitySelected += AddEntryToList;
            Clearing += entitySelector.RefreshData;
            btnRefreshData.Click += (_, e) => entitySelector.RefreshData();
        }

        public ProductEntryListSelector(Warehouse warehouse)
        {
            var dataProvider = new ProducLeftDataProvider(warehouse);
            var entitySelector = new EntitySelector<ProductLeftModel>(dataProvider);

            InitializeComponent();
            btnRefreshData.BackgroundImage = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject("RefreshIcon");

            pnlEntitySelector.Controls.Add(entitySelector);
            entitySelector.EntitySelected += AddEntryToList;
            Clearing += entitySelector.RefreshData;
            btnRefreshData.Click += (_, e) => entitySelector.RefreshData();           
        }

        public string ListTitle { get => lblEntryList.Text; set => lblEntryList.Text = value; }
        public string SelectorTitle { get => lblSelector.Text; set => lblSelector.Text = value; }

        private event Action Clearing;

        public IEnumerable<TEntry> GetEntries() => productEntryList.GetProductEntries().Cast<TEntry>();

        public void Clear() 
        {
            productEntryList.Clear();
            Clearing?.Invoke();
        }

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
