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
            btnTab = new Button
            {
                Dock = DockStyle.Left,
                FlatStyle = FlatStyle.Flat,
                Name = title,
                Size = new Size(32, 27),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowOnly,
                Padding = new Padding(0, 0, 12, 0),
                TabIndex = 1,
                Text = title,
                Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204),
                TextAlign = ContentAlignment.MiddleLeft,
                UseVisualStyleBackColor = false,
                Parent = tabParent,
            };
            btnTab.FlatAppearance.BorderSize = 0;
            btnTab.MouseEnter += Button_MouseEnter;
            btnTab.MouseLeave += Button_MouseLeave;
            hiddenColor = btnTab.BackColor;
            activeColor = SystemColors.Control;


            btnClose = new Button
            {
                Dock = DockStyle.Right,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(18, 27),
                BackColor = Color.FromArgb(0, 240, 165, 160),
                TabIndex = 1,
                Text = string.Empty,
                Font = new Font("Consolas", 10f),
                UseVisualStyleBackColor = false,
                Parent = btnTab,
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.MouseEnter += Button_MouseEnter;
            btnClose.MouseLeave += Button_MouseLeave;

            Form.TopLevel = false;
            Form.Dock = DockStyle.Fill;
            Form.FormBorderStyle = FormBorderStyle.None;
            Form.Parent = formParent;
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            btnClose.Text = "x";
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            btnClose.Text = string.Empty;
        }
    }
}