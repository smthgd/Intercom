namespace IntercomProject
{
    partial class ApplicationsForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.EdditingButton = new System.Windows.Forms.Button();
            this.DeletingButton = new System.Windows.Forms.Button();
            this.AddingButton = new System.Windows.Forms.Button();
            this.MoreButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 100);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1300, 350);
            this.dataGridView1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(37)))), ((int)(((byte)(55)))));
            this.panel1.Controls.Add(this.MoreButton);
            this.panel1.Controls.Add(this.EdditingButton);
            this.panel1.Controls.Add(this.DeletingButton);
            this.panel1.Controls.Add(this.AddingButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1300, 100);
            this.panel1.TabIndex = 2;
            // 
            // EdditingButton
            // 
            this.EdditingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(37)))), ((int)(((byte)(55)))));
            this.EdditingButton.FlatAppearance.BorderSize = 0;
            this.EdditingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EdditingButton.Font = new System.Drawing.Font("Century", 15F);
            this.EdditingButton.ForeColor = System.Drawing.SystemColors.Control;
            this.EdditingButton.Location = new System.Drawing.Point(325, 0);
            this.EdditingButton.Name = "EdditingButton";
            this.EdditingButton.Size = new System.Drawing.Size(325, 100);
            this.EdditingButton.TabIndex = 2;
            this.EdditingButton.Text = "Изменить";
            this.EdditingButton.UseVisualStyleBackColor = false;
            this.EdditingButton.Click += new System.EventHandler(this.EdditingButton_Click);
            // 
            // DeletingButton
            // 
            this.DeletingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeletingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(37)))), ((int)(((byte)(55)))));
            this.DeletingButton.FlatAppearance.BorderSize = 0;
            this.DeletingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeletingButton.Font = new System.Drawing.Font("Century", 15F);
            this.DeletingButton.ForeColor = System.Drawing.SystemColors.Control;
            this.DeletingButton.Location = new System.Drawing.Point(650, 0);
            this.DeletingButton.Name = "DeletingButton";
            this.DeletingButton.Size = new System.Drawing.Size(325, 100);
            this.DeletingButton.TabIndex = 3;
            this.DeletingButton.Text = "Удалить";
            this.DeletingButton.UseVisualStyleBackColor = false;
            // 
            // AddingButton
            // 
            this.AddingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(37)))), ((int)(((byte)(55)))));
            this.AddingButton.FlatAppearance.BorderSize = 0;
            this.AddingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddingButton.Font = new System.Drawing.Font("Century", 15F);
            this.AddingButton.ForeColor = System.Drawing.SystemColors.Control;
            this.AddingButton.Location = new System.Drawing.Point(0, 0);
            this.AddingButton.Name = "AddingButton";
            this.AddingButton.Size = new System.Drawing.Size(325, 100);
            this.AddingButton.TabIndex = 1;
            this.AddingButton.Text = "Добавить";
            this.AddingButton.UseVisualStyleBackColor = false;
            // 
            // MoreButton
            // 
            this.MoreButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MoreButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(37)))), ((int)(((byte)(55)))));
            this.MoreButton.FlatAppearance.BorderSize = 0;
            this.MoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MoreButton.Font = new System.Drawing.Font("Century", 15F);
            this.MoreButton.ForeColor = System.Drawing.SystemColors.Control;
            this.MoreButton.Location = new System.Drawing.Point(975, 0);
            this.MoreButton.Name = "MoreButton";
            this.MoreButton.Size = new System.Drawing.Size(325, 100);
            this.MoreButton.TabIndex = 4;
            this.MoreButton.Text = "Подробнее";
            this.MoreButton.UseVisualStyleBackColor = false;
            // 
            // ApplicationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ApplicationsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ApplicationsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button EdditingButton;
        private System.Windows.Forms.Button DeletingButton;
        private System.Windows.Forms.Button AddingButton;
        private System.Windows.Forms.Button MoreButton;
    }
}