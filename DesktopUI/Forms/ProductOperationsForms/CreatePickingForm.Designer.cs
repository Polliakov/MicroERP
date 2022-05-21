
namespace DesktopUI.Forms.ProductOperationsForms
{
    partial class CreatePickingForm
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
            this.btnEnter = new System.Windows.Forms.Button();
            this.cbWarehouse = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlProductEntryListSelector
            // 
            this.pnlProductEntryListSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProductEntryListSelector.Location = new System.Drawing.Point(12, 12);
            this.pnlProductEntryListSelector.Name = "pnlProductEntryListSelector";
            this.pnlProductEntryListSelector.Size = new System.Drawing.Size(619, 425);
            this.pnlProductEntryListSelector.TabIndex = 1;
            // 
            // btnEnter
            // 
            this.btnEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnter.BackColor = System.Drawing.SystemColors.Window;
            this.btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnter.Location = new System.Drawing.Point(637, 34);
            this.btnEnter.Margin = new System.Windows.Forms.Padding(3, 25, 3, 12);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(151, 23);
            this.btnEnter.TabIndex = 4;
            this.btnEnter.Text = "Добавить";
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.BtnEnter_Click);
            // 
            // cbWarehouse
            // 
            this.cbWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbWarehouse.FormattingEnabled = true;
            this.cbWarehouse.Location = new System.Drawing.Point(637, 87);
            this.cbWarehouse.Name = "cbWarehouse";
            this.cbWarehouse.Size = new System.Drawing.Size(151, 21);
            this.cbWarehouse.TabIndex = 3;
            this.cbWarehouse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CbWarehouse_KeyPress);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(637, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Склад";
            // 
            // CreatePickingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbWarehouse);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.pnlProductEntryListSelector);
            this.Name = "CreatePickingForm";
            this.Text = "Новая поставка";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlProductEntryListSelector;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.ComboBox cbWarehouse;
        private System.Windows.Forms.Label label4;
    }
}