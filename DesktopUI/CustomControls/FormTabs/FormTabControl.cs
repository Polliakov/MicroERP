using DesktopUI.CustomControls.FormTabs;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DesktopUI.CustomControls
{
    public partial class FormTabControl : UserControl
    {
        public FormTabControl()
        {
            InitializeComponent();
        }

        public FormTab ActiveTab { get; private set; }
        public List<FormTab> Tabs { get; } = new List<FormTab>();

        public void AddTab(string title, Form form)
        {
            var formTab = new FormTab(title, pnlTabs, pnlChildForm, form);
            Tabs.Add(formTab);
            SetActive(formTab);
            formTab.Active += FormTab_Active;
            formTab.Close += FormTab_Close;
        }

        private void FormTab_Active(FormTab sender)
        {
            SetActive(sender);
        }

        private void SetActive(FormTab formTab)
        {
            if (formTab.Equals(ActiveTab))
                return;
            if (!(ActiveTab is null))
                ActiveTab.State = TabState.Hidden;

            formTab.State = TabState.Active;
            ActiveTab = formTab;
        }

        private void FormTab_Close(FormTab sender)
        {
            Tabs.Remove(sender);
            sender.Dispose();
        }
    }
}
