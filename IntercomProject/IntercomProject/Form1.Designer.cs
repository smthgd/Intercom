namespace IntercomProject
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.SystemName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.applicationsButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.panel1.Controls.Add(this.SystemName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1332, 65);
            this.panel1.TabIndex = 1;
            // 
            // SystemName
            // 
            this.SystemName.AutoSize = true;
            this.SystemName.Font = new System.Drawing.Font("Century", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SystemName.ForeColor = System.Drawing.SystemColors.Control;
            this.SystemName.Location = new System.Drawing.Point(12, 15);
            this.SystemName.Name = "SystemName";
            this.SystemName.Size = new System.Drawing.Size(185, 33);
            this.SystemName.TabIndex = 0;
            this.SystemName.Text = "CRM System";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.applicationsButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 713);
            this.panel2.TabIndex = 2;
            // 
            // applicationsButton
            // 
            this.applicationsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.applicationsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(37)))), ((int)(((byte)(55)))));
            this.applicationsButton.Font = new System.Drawing.Font("Century", 15F);
            this.applicationsButton.ForeColor = System.Drawing.SystemColors.Control;
            this.applicationsButton.Location = new System.Drawing.Point(3, 6);
            this.applicationsButton.Name = "applicationsButton";
            this.applicationsButton.Size = new System.Drawing.Size(294, 50);
            this.applicationsButton.TabIndex = 0;
            this.applicationsButton.Text = "Заявки";
            this.applicationsButton.UseVisualStyleBackColor = false;
            this.applicationsButton.Click += new System.EventHandler(this.applicationsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(37)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(1332, 778);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CRM System";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label SystemName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button applicationsButton;
    }
}

