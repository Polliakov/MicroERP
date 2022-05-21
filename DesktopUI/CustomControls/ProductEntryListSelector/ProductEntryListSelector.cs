using BL.DataProviders;
using BL.Models;
using DataBase.Entities;
using DataBase.Interfaces;
using DesktopUI.CustomControls.EntitySelector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DesktopUI.CustomControls.ProductEntryListSelector
{
    public partial class ProductEntryListSelector<TEntry> : UserControl
        where TEntry : IProductEntry, new()
    {
        public ProductEntryListSelector()
        {
            var dataProvider = new DataProvider<Product>();
            var entitySelector = new EntitySelector<Product>(dataProvider)
            {
                Dock = DockStyle.Fill,
            };
            entitySelector.EntitySelected += AddEntryToList;

            InitializeComponent();
            Initialize(entitySelector);
            pnlEntitySelector.Controls.Add(entitySelector);
        }

        public ProductEntryListSelector(Warehouse warehouse)
        {
            var dataProvider = new ProducEntryDataProvider(warehouse);
            var entitySelector = new EntitySelector<ProductEntryModel>(dataProvider)
            {
                Dock = DockStyle.Fill,
            };
            entitySelector.EntitySelected += AddEntryToList;

            InitializeComponent();
            Initialize(entitySelector);
            pnlEntitySelector.Controls.Add(entitySelector);
        }

        public string ListTitle { get => lblEntryList.Text; set => lblEntryList.Text = value; }
        public string SelectorTitle { get => lblSelector.Text; set => lblSelector.Text = value; }

        public event Action ListChanged;
        private event Action Clearing;

        public IEnumerable<TEntry> GetEntries() => productEntryList.GetProductEntries().Cast<TEntry>();

        public void Clear()
        {
            productEntryList.Clear();
            Clearing.Invoke();
        }

        private void AddEntryToList(Product product)
        {
            var entry = (IProductEntry)new TEntry();
            entry.Count = 1;
            entry.Product = product;
            productEntryList.Add(entry);
        }

        private void AddEntryToList(ProductEntryModel productLeft)
        {
            var entry = (IProductEntry)new TEntry();
            entry.Count = 1;
            entry.Product = productLeft.Product;
            productEntryList.Add(entry, productLeft.Count);
        }

        private void Initialize(IRefreshable entitySelector)
        {
            btnRefreshData.BackgroundImage = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject("RefreshIcon");
            Clearing += entitySelector.RefreshData;
            btnRefreshData.Click += (_, e) => Clear();
            productEntryList.ItemChanged += () => ListChanged?.Invoke();
        }
    }
}
