
namespace DesktopUI.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.cbCurrentWarehouse = new System.Windows.Forms.ComboBox();
            this.pnlSideMenus = new System.Windows.Forms.Panel();
            this.pnlTopBorder = new System.Windows.Forms.Panel();
            this.pnlSideMenuBorder = new System.Windows.Forms.Panel();
            this.formTabControl = new DesktopUI.CustomControls.FormTabControl();
            this.sideMenuAdd = new DesktopUI.CustomControls.SideMenu.SideMenu();
            this.sideMenuView = new DesktopUI.CustomControls.SideMenu.SideMenu();
            this.pnlTop.SuspendLayout();
            this.pnlSideMenus.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.Control;
            this.pnlTop.Controls.Add(this.lblCurrentUser);
            this.pnlTop.Controls.Add(this.lblWarehouse);
            this.pnlTop.Controls.Add(this.cbCurrentWarehouse);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1184, 40);
            this.pnlTop.TabIndex = 6;
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentUser.AutoEllipsis = true;
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCurrentUser.Location = new System.Drawing.Point(943, 10);
            this.lblCurrentUser.MaximumSize = new System.Drawing.Size(230, 19);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(170, 18);
            this.lblCurrentUser.TabIndex = 2;
            this.lblCurrentUser.Text = "Текущий пользователь";
            this.lblCurrentUser.Click += new System.EventHandler(this.LblCurrentUser_Click);
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWarehouse.Location = new System.Drawing.Point(702, 12);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(42, 15);
            this.lblWarehouse.TabIndex = 1;
            this.lblWarehouse.Text = "Склад";
            // 
            // cbCurrentWarehouse
            // 
            this.cbCurrentWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCurrentWarehouse.FormattingEnabled = true;
            this.cbCurrentWarehouse.Location = new System.Drawing.Point(750, 10);
            this.cbCurrentWarehouse.Name = "cbCurrentWarehouse";
            this.cbCurrentWarehouse.Size = new System.Drawing.Size(174, 21);
            this.cbCurrentWarehouse.TabIndex = 0;
            this.cbCurrentWarehouse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CbCurrentWarehouse_KeyPress);
            // 
            // pnlSideMenus
            // 
            this.pnlSideMenus.AutoScroll = true;
            this.pnlSideMenus.Controls.Add(this.sideMenuAdd);
            this.pnlSideMenus.Controls.Add(this.sideMenuView);
            this.pnlSideMenus.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideMenus.Location = new System.Drawing.Point(0, 41);
            this.pnlSideMenus.Name = "pnlSideMenus";
            this.pnlSideMenus.Size = new System.Drawing.Size(180, 620);
            this.pnlSideMenus.TabIndex = 7;
            // 
            // pnlTopBorder
            // 
            this.pnlTopBorder.BackColor = System.Drawing.Color.Gray;
            this.pnlTopBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBorder.Location = new System.Drawing.Point(0, 40);
            this.pnlTopBorder.Name = "pnlTopBorder";
            this.pnlTopBorder.Size = new System.Drawing.Size(1184, 1);
            this.pnlTopBorder.TabIndex = 8;
            // 
            // pnlSideMenuBorder
            // 
            this.pnlSideMenuBorder.BackColor = System.Drawing.Color.DarkGray;
            this.pnlSideMenuBorder.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideMenuBorder.Location = new System.Drawing.Point(180, 41);
            this.pnlSideMenuBorder.Name = "pnlSideMenuBorder";
            this.pnlSideMenuBorder.Size = new System.Drawing.Size(1, 620);
            this.pnlSideMenuBorder.TabIndex = 9;
            // 
            // formTabControl
            // 
            this.formTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formTabControl.Location = new System.Drawing.Point(181, 41);
            this.formTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.formTabControl.Name = "formTabControl";
            this.formTabControl.Size = new System.Drawing.Size(1003, 620);
            this.formTabControl.TabIndex = 4;
            // 
            // sideMenuAdd
            // 
            this.sideMenuAdd.AutoSize = true;
            this.sideMenuAdd.BackColor = System.Drawing.SystemColors.Window;
            this.sideMenuAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.sideMenuAdd.Location = new System.Drawing.Point(0, 30);
            this.sideMenuAdd.MinimumSize = new System.Drawing.Size(100, 30);
            this.sideMenuAdd.Name = "sideMenuAdd";
            this.sideMenuAdd.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.sideMenuAdd.Size = new System.Drawing.Size(180, 30);
            this.sideMenuAdd.TabIndex = 6;
            this.sideMenuAdd.Title = "Добавление";
            // 
            // sideMenuView
            // 
            this.sideMenuView.AutoSize = true;
            this.sideMenuView.BackColor = System.Drawing.SystemColors.Window;
            this.sideMenuView.Dock = System.Windows.Forms.DockStyle.Top;
            this.sideMenuView.Location = new System.Drawing.Point(0, 0);
            this.sideMenuView.Margin = new System.Windows.Forms.Padding(0);
            this.sideMenuView.MinimumSize = new System.Drawing.Size(100, 30);
            this.sideMenuView.Name = "sideMenuView";
            this.sideMenuView.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.sideMenuView.Size = new System.Drawing.Size(180, 30);
            this.sideMenuView.TabIndex = 5;
            this.sideMenuView.Title = "Просмотр";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.formTabControl);
            this.Controls.Add(this.pnlSideMenuBorder);
            this.Controls.Add(this.pnlSideMenus);
            this.Controls.Add(this.pnlTopBorder);
            this.Controls.Add(this.pnlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlSideMenus.ResumeLayout(false);
            this.pnlSideMenus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private CustomControls.FormTabControl formTabControl;
        private CustomControls.SideMenu.SideMenu sideMenuView;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.ComboBox cbCurrentWarehouse;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Panel pnlSideMenus;
        private CustomControls.SideMenu.SideMenu sideMenuAdd;
        private System.Windows.Forms.Panel pnlTopBorder;
        private System.Windows.Forms.Panel pnlSideMenuBorder;
    }
}