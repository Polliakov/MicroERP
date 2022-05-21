using BL.DataProviders;
using BL.Models;
using DataBase.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows.Forms;

namespace DesktopUI.Forms.ViewForms
{
    public partial class WarehouseViewForm : Form
    {
        public WarehouseViewForm(Warehouse warehouse)
        {
            InitializeComponent();

            lblName.Text = warehouse.Name ?? "Склад";
            lblAddress.Text = warehouse.Address;

            var data = new ProducEntryDataProvider(warehouse).GetData();
            var list = (IList<ProductEntryModel>)data.ToListAsync().Result;
            dataGridView.DataSource = new BindingList<ProductEntryModel>(list);
        }
    }
}
