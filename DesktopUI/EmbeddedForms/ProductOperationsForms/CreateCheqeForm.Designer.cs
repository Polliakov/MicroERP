
namespace DesktopUI.EmbeddedForms.ProductOperationsForms
{
    partial class CreateCheqeForm
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
            this.pnlProductEntryListSelector = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlProductEntryListSelector
            // 
            this.pnlProductEntryListSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProductEntryListSelector.Location = new System.Drawing.Point(13, 13);
            this.pnlProductEntryListSelector.Name = "pnlProductEntryListSelector";
            this.pnlProductEntryListSelector.Size = new System.Drawing.Size(597, 425);
            this.pnlProductEntryListSelector.TabIndex = 0;
            // 
            // CreateCheqeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlProductEntryListSelector);
            this.Name = "CreateCheqeForm";
            this.Text = "CreateCheqeForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlProductEntryListSelector;
    }
}