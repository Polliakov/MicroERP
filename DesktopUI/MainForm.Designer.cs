
namespace DesktopUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.formTabControl = new DesktopUI.CustomControls.FormTabControl();
            this.sideMenu = new DesktopUI.CustomControls.SideMenu.SideMenu();
            this.SuspendLayout();
            // 
            // formTabControl
            // 
            this.formTabControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.formTabControl.Location = new System.Drawing.Point(275, 0);
            this.formTabControl.Name = "formTabControl";
            this.formTabControl.Size = new System.Drawing.Size(909, 661);
            this.formTabControl.TabIndex = 4;
            // 
            // sideMenu
            // 
            this.sideMenu.AutoScroll = true;
            this.sideMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sideMenu.Location = new System.Drawing.Point(0, 0);
            this.sideMenu.Name = "sideMenu";
            this.sideMenu.Size = new System.Drawing.Size(275, 661);
            this.sideMenu.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.sideMenu);
            this.Controls.Add(this.formTabControl);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion
        private CustomControls.FormTabControl formTabControl;
        private CustomControls.SideMenu.SideMenu sideMenu;
    }
}