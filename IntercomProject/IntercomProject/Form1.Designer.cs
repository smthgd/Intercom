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
            this.CloseButton = new System.Windows.Forms.Button();
            this.SystemName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.addressesButton = new System.Windows.Forms.Button();
            this.applicationsButton = new System.Windows.Forms.Button();
            this.employeesButton = new System.Windows.Forms.Button();
            this.intercomeButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Controls.Add(this.SystemName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1332, 65);
            this.panel1.TabIndex = 1;
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseButton.ForeColor = System.Drawing.SystemColors.Control;
            this.CloseButton.Location = new System.Drawing.Point(1270, 7);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(50, 50);
            this.CloseButton.TabIndex = 3;
            this.CloseButton.Text = "x";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
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
            this.panel2.Controls.Add(this.intercomeButton);
            this.panel2.Controls.Add(this.employeesButton);
            this.panel2.Controls.Add(this.addressesButton);
            this.panel2.Controls.Add(this.applicationsButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 713);
            this.panel2.TabIndex = 2;
            // 
            // addressesButton
            // 
            this.addressesButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addressesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(37)))), ((int)(((byte)(55)))));
            this.addressesButton.FlatAppearance.BorderSize = 0;
            this.addressesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addressesButton.Font = new System.Drawing.Font("Century", 15F);
            this.addressesButton.ForeColor = System.Drawing.SystemColors.Control;
            this.addressesButton.Location = new System.Drawing.Point(3, 51);
            this.addressesButton.Name = "addressesButton";
            this.addressesButton.Size = new System.Drawing.Size(294, 50);
            this.addressesButton.TabIndex = 2;
            this.addressesButton.Text = "Адреса";
            this.addressesButton.UseVisualStyleBackColor = false;
            this.addressesButton.Click += new System.EventHandler(this.addressesButton_Click);
            // 
            // applicationsButton
            // 
            this.applicationsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.applicationsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(37)))), ((int)(((byte)(55)))));
            this.applicationsButton.FlatAppearance.BorderSize = 0;
            this.applicationsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applicationsButton.Font = new System.Drawing.Font("Century", 15F);
            this.applicationsButton.ForeColor = System.Drawing.SystemColors.Control;
            this.applicationsButton.Location = new System.Drawing.Point(3, 0);
            this.applicationsButton.Name = "applicationsButton";
            this.applicationsButton.Size = new System.Drawing.Size(294, 50);
            this.applicationsButton.TabIndex = 0;
            this.applicationsButton.Text = "Заявки";
            this.applicationsButton.UseVisualStyleBackColor = false;
            this.applicationsButton.Click += new System.EventHandler(this.applicationsButton_Click);
            // 
            // employeesButton
            // 
            this.employeesButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.employeesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(37)))), ((int)(((byte)(55)))));
            this.employeesButton.FlatAppearance.BorderSize = 0;
            this.employeesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.employeesButton.Font = new System.Drawing.Font("Century", 15F);
            this.employeesButton.ForeColor = System.Drawing.SystemColors.Control;
            this.employeesButton.Location = new System.Drawing.Point(3, 101);
            this.employeesButton.Name = "employeesButton";
            this.employeesButton.Size = new System.Drawing.Size(294, 50);
            this.employeesButton.TabIndex = 4;
            this.employeesButton.Text = "Сотрудники";
            this.employeesButton.UseVisualStyleBackColor = false;
            this.employeesButton.Click += new System.EventHandler(this.employeesButton_Click);
            // 
            // intercomeButton
            // 
            this.intercomeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.intercomeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(37)))), ((int)(((byte)(55)))));
            this.intercomeButton.FlatAppearance.BorderSize = 0;
            this.intercomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.intercomeButton.Font = new System.Drawing.Font("Century", 15F);
            this.intercomeButton.ForeColor = System.Drawing.SystemColors.Control;
            this.intercomeButton.Location = new System.Drawing.Point(3, 151);
            this.intercomeButton.Name = "intercomeButton";
            this.intercomeButton.Size = new System.Drawing.Size(294, 50);
            this.intercomeButton.TabIndex = 5;
            this.intercomeButton.Text = "Домофоны";
            this.intercomeButton.UseVisualStyleBackColor = false;
            this.intercomeButton.Click += new System.EventHandler(this.intercomeButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(37)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(1332, 778);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CRM System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button addressesButton;
        private System.Windows.Forms.Button employeesButton;
        private System.Windows.Forms.Button intercomeButton;
    }
}

