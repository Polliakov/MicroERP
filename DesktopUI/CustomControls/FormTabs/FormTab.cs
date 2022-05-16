using System;
using System.Windows.Forms;
using System.Drawing;

namespace DesktopUI.CustomControls.FormTabs
{
    public class FormTab : IDisposable
    {
        public FormTab(string title, Control tabParent, Control formParent, Form form)
        {
            Form = form;
            InitializeComponents(title, tabParent, formParent);
            btnTab.Click += (_, e) => Active.Invoke(this);
            btnClose.Click += (_, e) => Close.Invoke(this);
            state = TabState.Hidden;
        }

        public event Action<FormTab> Active;
        public event Action<FormTab> Close;
        public TabState State
        {
            get => state;
            set
            {
                switch (value)
                {
                    case TabState.Active: StateActive(); break;
                    case TabState.Hidden: StateHidden(); break;
                }
            }
        }

        public Form Form { get; }
        private Button btnTab;
        private Button btnClose;
        private Color activeColor;
        private Color hiddenColor;
        private TabState state;

        private void StateActive()
        {
            if (state == TabState.Active) return;
            btnTab.BackColor = activeColor;
            Form.BringToFront();
            Form.Show();
            state = TabState.Active;
        }

        private void StateHidden()
        {
            if (state == TabState.Hidden) return;
            btnTab.BackColor = hiddenColor;
            Form.Hide();
            state = TabState.Hidden;
        }

        public void Dispose()
        {
            btnClose.Dispose();
            btnTab.Dispose();
            Form.Dispose();
        }

        private void InitializeComponents(string title, Control tabParent, Control formParent)
        {
            btnTab = new Button();
            btnTab.Dock = DockStyle.Left;
            btnTab.FlatAppearance.BorderSize = 0;
            btnTab.FlatStyle = FlatStyle.Flat;
            btnTab.Name = title;
            btnTab.Size = new Size(100, 23);
            btnTab.TabIndex = 1;
            btnTab.Text = title;
            btnTab.TextAlign = ContentAlignment.MiddleLeft;
            btnTab.UseVisualStyleBackColor = false;
            btnTab.Parent = tabParent;
            hiddenColor = btnTab.BackColor;
            activeColor = SystemColors.Control;

            btnClose = new Button();
            btnClose.Dock = DockStyle.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Size = new Size(16, 23);
            btnClose.BackColor = Color.FromArgb(0, 240, 165, 160);
            btnClose.TabIndex = 1;
            btnClose.Text = "x";
            btnClose.Font = new Font("Consolas", 10f);
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Parent = btnTab;

            Form.TopLevel = false;
            Form.Dock = DockStyle.Fill;
            Form.FormBorderStyle = FormBorderStyle.None;
            Form.Parent = formParent;
        }
    }
}