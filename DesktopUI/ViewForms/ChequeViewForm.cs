using BL.DataProviders;
using BL.Models;
using DataBase.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows.Forms;

namespace DesktopUI.ViewForms
{
    public partial class ChequeViewForm : Form
    {
        public ChequeViewForm(Cheque cheque)
        {
            InitializeComponent();

            lblTime.Text = cheque.Timestamp.ToString();
            lblUser.Text = cheque.User.ToString();
            lblTotal.Text = cheque.Total.ToString("C");

            var data = new ProducEntryDataProvider(cheque).GetData();
            var list = (IList<ProductEntryModel>)data.ToListAsync().Result;
            dataGridView.DataSource = new BindingList<ProductEntryModel>(list);
        }
    }
}
