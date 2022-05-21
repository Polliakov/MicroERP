using BL.DataProviders;
using DataBase.Entities;
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
            if (userRole == UserRole.Administrator)
                canDelete = true;

            data = dataProvider.GetData();
            var list = (IList<TEntity>)data.ToListAsync().Result;
            dataGridView.DataSource = new BindingList<TEntity>(list);
        }

        private readonly bool canDelete = false;
        private readonly IQueryable<TEntity> data;

        private void DataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;

            var menu = new ContextMenu();
            menu.MenuItems.Add("Удалить", (_, args) => TryDelete(dataGridView.Rows[e.RowIndex]));
            menu.Show(dataGridView, new System.Drawing.Point(e.X, e.Y));
            // TODO: Некорректно задаётся координата Y.
        }

        private void DataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;

            data.Load();
            var selected = (TEntity)dataGridView.Rows[e.RowIndex].DataBoundItem;
            var viewForm = ViewForm.NewFor(selected);
            viewForm?.Show();
        }

        private void TryDelete(DataGridViewRow row)
        {
            // TODO: Удаление записей.
            if (!canDelete) return;
            throw new NotImplementedException();
        }

        private void RefreshData()
        {
            var list = (IList<TEntity>)data.ToListAsync().Result;
            dataGridView.DataSource = new BindingList<TEntity>(list);
            dataGridView.ClearSelection();
        }
    }
}
