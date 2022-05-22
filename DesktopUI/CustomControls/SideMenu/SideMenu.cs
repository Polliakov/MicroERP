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

        public event Action<SideMenu, string, object> ItemClick;

        public string Title { get => btnTitle.Text; set => btnTitle.Text = value; }
        public List<Button> Items { get; } = new List<Button>();

        private bool isExpanded = true;

        public void AddItem(string title, object tag)
        {
            var item = NewItem(title, tag);
            item.Click += (_, e) => ItemClick.Invoke(this, item.Name, item.Tag);
            Items.Add(item);
            pnlItems.Controls.Add(item);
        }

        private Button NewItem(string title, object tag)
        {
            var button = new Button
            {
                Dock = DockStyle.Top,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Microsoft Sans Serif", 10.75F, FontStyle.Regular, GraphicsUnit.Point, 204),
                Location = new Point(0, 0),
                Name = title,
                Size = new Size(200, 30),
                Padding = new Padding(10, 0, 0, 0),
                TabIndex = 0,
                Text = title,
                TextAlign = ContentAlignment.MiddleLeft,
                UseVisualStyleBackColor = false,
                Tag = tag
            };
            button.FlatAppearance.BorderSize = 0;
            return button;
        }

        private void BtnTitle_Click(object sender, EventArgs e)
        {
            if (isExpanded)
                Size = new Size(Size.Width, btnTitle.Size.Height);
            AutoSize = !AutoSize;
            isExpanded = !isExpanded;
        }
    }
}
