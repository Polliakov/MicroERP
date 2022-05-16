
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCurrentWarehouse = new System.Windows.Forms.ComboBox();
            this.sideMenu = new DesktopUI.CustomControls.SideMenu.SideMenu();
            this.formTabControl = new DesktopUI.CustomControls.FormTabControl();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.Control;
            this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.cbCurrentWarehouse);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1184, 40);
            this.pnlTop.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(700, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Склад";
            // 
            // cbCurrentWarehouse
            // 
            this.cbCurrentWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCurrentWarehouse.FormattingEnabled = true;
            this.cbCurrentWarehouse.Location = new System.Drawing.Point(748, 9);
            this.cbCurrentWarehouse.Name = "cbCurrentWarehouse";
            this.cbCurrentWarehouse.Size = new System.Drawing.Size(174, 21);
            this.cbCurrentWarehouse.TabIndex = 0;
            this.cbCurrentWarehouse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CbCurrentWarehouse_KeyPress);
            // 
            // sideMenu
            // 
            this.sideMenu.AutoScroll = true;
            this.sideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideMenu.Location = new System.Drawing.Point(0, 40);
            this.sideMenu.Margin = new System.Windows.Forms.Padding(0);
            this.sideMenu.Name = "sideMenu";
            this.sideMenu.Size = new System.Drawing.Size(200, 621);
            this.sideMenu.TabIndex = 5;
            // 
            // formTabControl
            // 
            this.formTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formTabControl.Location = new System.Drawing.Point(200, 40);
            this.formTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.formTabControl.Name = "formTabControl";
            this.formTabControl.Size = new System.Drawing.Size(984, 621);
            this.formTabControl.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.formTabControl);
            this.Controls.Add(this.sideMenu);
            this.Controls.Add(this.pnlTop);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private CustomControls.FormTabControl formTabControl;
        private CustomControls.SideMenu.SideMenu sideMenu;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCurrentWarehouse;
    }
}