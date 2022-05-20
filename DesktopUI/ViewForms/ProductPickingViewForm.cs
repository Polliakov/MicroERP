using BL.DataProviders;
using BL.Models;
using DataBase.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows.Forms;

namespace DesktopUI.ViewForms
{
    public partial class ProductPickingViewForm : Form
    {
        public ProductPickingViewForm(ProductPicking picking)
        {
            InitializeComponent();

            lblTime.Text = picking.Timestamp.ToString();
            lblUser.Text = picking.User.ToString();

            var data = new ProducEntryDataProvider(picking).GetData();
            var list = (IList<ProductEntryModel>)data.ToListAsync().Result;
            dataGridView.DataSource = new BindingList<ProductEntryModel>(list);
        }
    }
}
