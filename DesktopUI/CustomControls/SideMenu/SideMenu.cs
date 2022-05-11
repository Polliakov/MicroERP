using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopUI.CustomControls.SideMenu
{
    public partial class SideMenu : UserControl
    {
        public SideMenu()
        {
            InitializeComponent();
        }

        public event Action<string, object> ItemClick;
        public List<Button> Items { get; } = new List<Button>();

        public void AddItem(string title, object tag)
        {
            var item = NewItem(title, tag);
            item.Click += (_, e) => ItemClick.Invoke(item.Name, item.Tag);
            Items.Add(item);
            Controls.Add(item);
        }

        private Button NewItem(string title, object tag)
        {
            var button = new Button();
            button.Dock = DockStyle.Top;
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            button.Location = new Point(0, 0);
            button.Name = title;
            button.Size = new Size(200, 30);
            button.TabIndex = 0;
            button.Text = title;
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.UseVisualStyleBackColor = false;
            button.Tag = tag;
            return button;
        }
    }
}
