namespace ISPManagementSystem1
{
    partial class TariffsForm
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
            this.dataGridViewTariffs = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDeleteTariff = new System.Windows.Forms.Button();
            this.btnEditTariff = new System.Windows.Forms.Button();
            this.btnAddTariff = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTariffs)).BeginInit();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewTariffs
            // 
            this.dataGridViewTariffs.AllowUserToAddRows = false;
            this.dataGridViewTariffs.AllowUserToDeleteRows = false;
            this.dataGridViewTariffs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTariffs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTariffs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTariffs.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewTariffs.MultiSelect = false;
            this.dataGridViewTariffs.Name = "dataGridViewTariffs";
            this.dataGridViewTariffs.ReadOnly = true;
            this.dataGridViewTariffs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTariffs.Size = new System.Drawing.Size(760, 327);
            this.dataGridViewTariffs.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnDeleteTariff);
            this.panel1.Controls.Add(this.btnEditTariff);
            this.panel1.Controls.Add(this.btnAddTariff);
            this.panel1.Location = new System.Drawing.Point(12, 345);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 50);
            this.panel1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(673, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Закрити";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDeleteTariff
            // 
            this.btnDeleteTariff.Location = new System.Drawing.Point(206, 14);
            this.btnDeleteTariff.Name = "btnDeleteTariff";
            this.btnDeleteTariff.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteTariff.TabIndex = 2;
            this.btnDeleteTariff.Text = "Видалити";
            this.btnDeleteTariff.UseVisualStyleBackColor = true;
            this.btnDeleteTariff.Click += new System.EventHandler(this.btnDeleteTariff_Click);
            // 
            // btnEditTariff
            // 
            this.btnEditTariff.Location = new System.Drawing.Point(125, 14);
            this.btnEditTariff.Name = "btnEditTariff";
            this.btnEditTariff.Size = new System.Drawing.Size(75, 23);
            this.btnEditTariff.TabIndex = 1;
            this.btnEditTariff.Text = "Редагувати";
            this.btnEditTariff.UseVisualStyleBackColor = true;
            this.btnEditTariff.Click += new System.EventHandler(this.btnEditTariff_Click);
            // 
            // btnAddTariff
            // 
            this.btnAddTariff.Location = new System.Drawing.Point(44, 14);
            this.btnAddTariff.Name = "btnAddTariff";
            this.btnAddTariff.Size = new System.Drawing.Size(75, 23);
            this.btnAddTariff.TabIndex = 0;
            this.btnAddTariff.Text = "Додати";
            this.btnAddTariff.UseVisualStyleBackColor = true;
            this.btnAddTariff.Click += new System.EventHandler(this.btnAddTariff_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 398);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(53, 17);
            this.statusLabel.Text = "Готово";
            // 
            // TariffsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 420);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewTariffs);
            this.Name = "TariffsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тарифи";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTariffs)).EndInit();
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTariffs;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeleteTariff;
        private System.Windows.Forms.Button btnEditTariff;
        private System.Windows.Forms.Button btnAddTariff;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Button btnClose;
    }
}