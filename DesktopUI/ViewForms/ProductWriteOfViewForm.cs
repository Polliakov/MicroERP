using BL.DataProviders;
using BL.Models;
using DataBase.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows.Forms;

namespace DesktopUI.ViewForms
{
    public partial class ProductWriteOfViewForm : Form
    {
        public ProductWriteOfViewForm(ProductWriteOf writeOf)
        {
            InitializeComponent();

            lblTime.Text = writeOf.Timestamp.ToString();
            lblUser.Text = writeOf.User.ToString();
            tbDescription.Text = writeOf.Description;

            var data = new ProducEntryDataProvider(writeOf).GetData();
            var list = (IList<ProductEntryModel>)data.ToListAsync().Result;
            dataGridView.DataSource = new BindingList<ProductEntryModel>(list);
        }
    }
}
