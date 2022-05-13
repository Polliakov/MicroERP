using DataBase.Entities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopUI.CustomControls.ProductEntryList
{
    public class ProductEntryListItem : IDisposable
    {
        public ProductEntryListItem(IProductEntry productEntry, Control parent)
        {
            ProductEntry = productEntry;
            InitializeComponents(parent);
            nmcCount.ValueChanged += NmcCount_ValueChanged;
            btnClose.Click += (_, e) => Close.Invoke(this);
        }

        public event Action<ProductEntryListItem> Close;
        public IProductEntry ProductEntry { get; }

        private Button btnItem;
        private Button btnClose;
        private NumericUpDown nmcCount;

        public void IncreaseCount(int value)
        {
            if (value < 0)
                throw new ArgumentException(nameof(value));

            ProductEntry.Count += value;
            nmcCount.Value += value;
        }

        public void DecreaseCount(int value)
        {
            if (value < 0)
                throw new ArgumentException(nameof(value));

            ProductEntry.Count -= value;
            nmcCount.Value -= value;
        }

        private void NmcCount_ValueChanged(object sender, EventArgs e)
        {
            if (nmcCount.Value <= 0)
            {
                Close.Invoke(this);
                return;
            }
            ProductEntry.Count = (int)nmcCount.Value;
        }

        private void InitializeComponents(Control parent)
        {
            btnItem = new Button();
            btnItem.Dock = DockStyle.Top;
            btnItem.FlatStyle = FlatStyle.Flat;
            btnItem.FlatAppearance.BorderSize = 0;
            btnItem.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnItem.Name = ProductEntry.Product.Name;
            btnItem.Size = new Size(344, 23);
            btnItem.TabIndex = 0;
            btnItem.Text = ProductEntry.Product.Name;
            btnItem.TextAlign = ContentAlignment.MiddleLeft; 
            btnItem.UseVisualStyleBackColor = false;
            btnItem.Parent = parent;

            nmcCount = new NumericUpDown();
            nmcCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nmcCount.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nmcCount.Name = "numericUpDown";
            nmcCount.Size = new Size(50, 21);
            nmcCount.TabIndex = 1;
            nmcCount.TextAlign = HorizontalAlignment.Right;
            int startValue = ProductEntry.Count == 0 ? 1 : ProductEntry.Count;
            nmcCount.Value = new decimal(new int[] { startValue, 0, 0, 0 });
            nmcCount.Parent = btnItem;
            nmcCount.Location = new Point(btnItem.Size.Width - 80, 1);

            btnClose = new Button();
            btnClose.Dock = DockStyle.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Size = new Size(23, 23);
            btnClose.BackColor = Color.FromArgb(0, 240, 165, 160);
            btnClose.TabIndex = 1;
            btnClose.Text = "X";
            btnClose.Font = new Font("Consolas", 10f);
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Parent = btnItem;
        }

        public void Dispose()
        {
            btnClose.Dispose();
            nmcCount.Dispose();
            btnItem.Dispose();
        }
    }
}
