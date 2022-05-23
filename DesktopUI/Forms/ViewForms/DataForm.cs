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
            this.dataProvider = dataProvider;

            InitializeComponent();
            Icon = Properties.Resources.icon;

            if (userRole == UserRole.Administrator && 
                typeof(TEntity).GetInterface(nameof(IDeletable)) != null)
            {
                btnDelete.Visible = true;
            }

            data = dataProvider.GetData();
            RefreshData();
        }

        public string Title { get => lblTitle.Text; set => lblTitle.Text = value; }

        private readonly IDataProvider<TEntity> dataProvider;
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
            if (dataGridView.SelectedRows.Count == 0) return;

            var row = dataGridView.SelectedRows[0];
            var entity = (TEntity)row.DataBoundItem;
            var dialogResult = MessageBox.Show($"Удалить \"{entity}\"?", "Удаление", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
            {
                dataGridView.Rows.Remove(row);
                ((IDeletable)entity).Deleted = DateTime.Now;
                dataProvider.Save();
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
