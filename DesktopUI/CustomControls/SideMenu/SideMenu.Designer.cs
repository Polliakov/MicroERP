
namespace DesktopUI.CustomControls.SideMenu
{
    partial class SideMenu
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
            this.btnTitle = new System.Windows.Forms.Button();
            this.pnlItems = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnTitle
            // 
            this.btnTitle.BackColor = System.Drawing.SystemColors.Control;
            this.btnTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTitle.FlatAppearance.BorderSize = 0;
            this.btnTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTitle.Location = new System.Drawing.Point(0, 0);
            this.btnTitle.Margin = new System.Windows.Forms.Padding(0);
            this.btnTitle.Name = "btnTitle";
            this.btnTitle.Size = new System.Drawing.Size(200, 30);
            this.btnTitle.TabIndex = 0;
            this.btnTitle.Text = "Меню";
            this.btnTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTitle.UseVisualStyleBackColor = false;
            this.btnTitle.Click += new System.EventHandler(this.BtnTitle_Click);
            // 
            // pnlItems
            // 
            this.pnlItems.AutoSize = true;
            this.pnlItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlItems.Location = new System.Drawing.Point(0, 30);
            this.pnlItems.Name = "pnlItems";
            this.pnlItems.Size = new System.Drawing.Size(200, 370);
            this.pnlItems.TabIndex = 1;
            // 
            // SideMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.pnlItems);
            this.Controls.Add(this.btnTitle);
            this.MinimumSize = new System.Drawing.Size(100, 30);
            this.Name = "SideMenu";
            this.Size = new System.Drawing.Size(200, 400);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTitle;
        private System.Windows.Forms.Panel pnlItems;
    }
}
