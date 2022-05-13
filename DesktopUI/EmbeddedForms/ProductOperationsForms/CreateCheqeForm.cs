using DataBase.Entities;
using DesktopUI.CustomControls.ProductEntryListSelector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopUI.EmbeddedForms.ProductOperationsForms
{
    public partial class CreateCheqeForm : Form
    {
        public CreateCheqeForm()
        {
            InitializeComponent();
            productEntryListSelector.Dock = DockStyle.Fill;
            productEntryListSelector.SelectorTitle = "Товары";
            productEntryListSelector.ListTitle = "Чек";
            pnlProductEntryListSelector.Controls.Add(productEntryListSelector);
        }

        private readonly ProductEntryListSelector<ProductSell> productEntryListSelector = new ProductEntryListSelector<ProductSell>();
    }
}
