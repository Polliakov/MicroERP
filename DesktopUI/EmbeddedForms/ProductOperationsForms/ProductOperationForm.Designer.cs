
namespace DesktopUI.EmbeddedForms.ProductOperationsForms
{
    partial class ProductOperationForm
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.productEntryList1 = new DesktopUI.CustomControls.ProductEntryList.ProductEntryList();
            this.pnlEntitySelector = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Location = new System.Drawing.Point(12, 12);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.productEntryList1);
            this.splitContainer.Size = new System.Drawing.Size(459, 426);
            this.splitContainer.SplitterDistance = 229;
            this.splitContainer.TabIndex = 2;
            // 
            // productEntryList1
            // 
            this.productEntryList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productEntryList1.AutoScroll = true;
            this.productEntryList1.Location = new System.Drawing.Point(3, 36);
            this.productEntryList1.Name = "productEntryList1";
            this.productEntryList1.Size = new System.Drawing.Size(220, 359);
            this.productEntryList1.TabIndex = 0;
            // 
            // pnlEntitySelector
            // 
            this.pnlEntitySelector.Location = new System.Drawing.Point(12, 48);
            this.pnlEntitySelector.Name = "pnlEntitySelector";
            this.pnlEntitySelector.Size = new System.Drawing.Size(230, 359);
            this.pnlEntitySelector.TabIndex = 0;
            // 
            // ProductOperationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlEntitySelector);
            this.Controls.Add(this.splitContainer);
            this.Name = "ProductOperationForm";
            this.Text = "ProductOperationForm";
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private CustomControls.ProductEntryList.ProductEntryList productEntryList1;
        private System.Windows.Forms.Panel pnlEntitySelector;
    }
}