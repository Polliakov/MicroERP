namespace DesktopUI.CustomControls.ProductEntryListSelector
{
    partial class ProductEntryListSelector<TEntry>
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlEntitySelector = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.btnRefreshData = new System.Windows.Forms.Button();
            this.lblSelector = new System.Windows.Forms.Label();
            this.lblEntryList = new System.Windows.Forms.Label();
            this.productEntryList = new DesktopUI.CustomControls.ProductEntryList.ProductEntryList();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEntitySelector
            // 
            this.pnlEntitySelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEntitySelector.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlEntitySelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEntitySelector.Location = new System.Drawing.Point(3, 31);
            this.pnlEntitySelector.Name = "pnlEntitySelector";
            this.pnlEntitySelector.Size = new System.Drawing.Size(473, 371);
            this.pnlEntitySelector.TabIndex = 3;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.btnRefreshData);
            this.splitContainer.Panel1.Controls.Add(this.lblSelector);
            this.splitContainer.Panel1.Controls.Add(this.pnlEntitySelector);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.lblEntryList);
            this.splitContainer.Panel2.Controls.Add(this.productEntryList);
            this.splitContainer.Size = new System.Drawing.Size(770, 405);
            this.splitContainer.SplitterDistance = 479;
            this.splitContainer.TabIndex = 4;
            // 
            // btnRefreshData
            // 
            this.btnRefreshData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRefreshData.FlatAppearance.BorderSize = 0;
            this.btnRefreshData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshData.Location = new System.Drawing.Point(453, 9);
            this.btnRefreshData.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.btnRefreshData.Name = "btnRefreshData";
            this.btnRefreshData.Size = new System.Drawing.Size(20, 20);
            this.btnRefreshData.TabIndex = 5;
            this.btnRefreshData.UseVisualStyleBackColor = true;
            // 
            // lblSelector
            // 
            this.lblSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSelector.Location = new System.Drawing.Point(29, 12);
            this.lblSelector.Margin = new System.Windows.Forms.Padding(29, 0, 3, 0);
            this.lblSelector.Name = "lblSelector";
            this.lblSelector.Size = new System.Drawing.Size(418, 16);
            this.lblSelector.TabIndex = 4;
            this.lblSelector.Text = "Заголовок";
            this.lblSelector.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblEntryList
            // 
            this.lblEntryList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEntryList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEntryList.Location = new System.Drawing.Point(3, 12);
            this.lblEntryList.Name = "lblEntryList";
            this.lblEntryList.Size = new System.Drawing.Size(281, 16);
            this.lblEntryList.TabIndex = 5;
            this.lblEntryList.Text = "Заголовок";
            this.lblEntryList.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // productEntryList
            // 
            this.productEntryList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productEntryList.AutoScroll = true;
            this.productEntryList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.productEntryList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.productEntryList.Location = new System.Drawing.Point(3, 31);
            this.productEntryList.Name = "productEntryList";
            this.productEntryList.Size = new System.Drawing.Size(281, 371);
            this.productEntryList.TabIndex = 0;
            // 
            // ProductEntryListSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "ProductEntryListSelector";
            this.Size = new System.Drawing.Size(770, 405);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEntitySelector;
        private System.Windows.Forms.SplitContainer splitContainer;
        private ProductEntryList.ProductEntryList productEntryList;
        private System.Windows.Forms.Label lblSelector;
        private System.Windows.Forms.Label lblEntryList;
        private System.Windows.Forms.Button btnRefreshData;
    }
}
