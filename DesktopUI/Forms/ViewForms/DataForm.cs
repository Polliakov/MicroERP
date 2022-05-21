using BL.DataProviders;
using DataBase.Entities;
using DataBase.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace DesktopUI.Forms.ViewForms
{
    public partial class DataForm<TEntity> : Form
        where TEntity : class
    {
        public DataForm(IDataProvider<TEntity> dataProvider, UserRole userRole = UserRole.Cashier)
        {
            InitializeComponent();
            if (userRole == UserRole.Administrator && typeof(TEntity) is IDeletable)
            {
                btnDelete.Visible = true;
            }

            data = dataProvider.GetData();
            RefreshData();
        }

        private readonly IQueryable<TEntity> data;

        private void DataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;

            data.Load();
            var selected = (TEntity)dataGridView.Rows[e.RowIndex].DataBoundItem;
            var viewForm = ViewForm.NewFor(selected);
            viewForm?.Show();
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var row = dataGridView.SelectedRows[0];
            var entity = (TEntity)row.DataBoundItem;
            var dialogResult = MessageBox.Show($"Удалить \"{entity}\"?", "Удаление", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
            {
                dataGridView.Rows.Remove(row);
                ((IDeletable)entity).Deleted = DateTime.Now;
            }
        }

        private void BtnRefreshData_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            var list = (IList<TEntity>)data.ToListAsync().Result;
            dataGridView.DataSource = new BindingList<TEntity>(list);
        }
    }
}
