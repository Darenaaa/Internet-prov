namespace ISPManagementSystem1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItemфайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tariffsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTariffsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewConnectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewPaymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supportTicketsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tariffReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.financialReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxStatistics = new System.Windows.Forms.GroupBox();
            this.labelClientsTitle = new System.Windows.Forms.Label();
            this.labelConnectionsTitle = new System.Windows.Forms.Label();
            this.labelTicketsTitle = new System.Windows.Forms.Label();
            this.labelClientsCount = new System.Windows.Forms.Label();
            this.labelConnectionsCount = new System.Windows.Forms.Label();
            this.labelTicketsCount = new System.Windows.Forms.Label();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.btnAddTicket = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBoxStatistics.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItemфайлToolStripMenuItem,
            this.fileToolStripMenuItem,
            this.tariffsToolStripMenuItem,
            this.connectionsToolStripMenuItem,
            this.paymentsToolStripMenuItem,
            this.supportToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(882, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItemфайлToolStripMenuItem
            // 
            this.fileToolStripMenuItemфайлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItemфайлToolStripMenuItem.Name = "fileToolStripMenuItemфайлToolStripMenuItem";
            this.fileToolStripMenuItemфайлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.fileToolStripMenuItemфайлToolStripMenuItem.Text = "Файл";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exitToolStripMenuItem.Text = "Вихід";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewClientsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.fileToolStripMenuItem.Text = "Клієнти";
            // 
            // tariffsToolStripMenuItem
            // 
            this.tariffsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewTariffsToolStripMenuItem});
            this.tariffsToolStripMenuItem.Name = "tariffsToolStripMenuItem";
            this.tariffsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.tariffsToolStripMenuItem.Text = "Тарифи";
            // 
            // connectionsToolStripMenuItem
            // 
            this.connectionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewConnectionsToolStripMenuItem});
            this.connectionsToolStripMenuItem.Name = "connectionsToolStripMenuItem";
            this.connectionsToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.connectionsToolStripMenuItem.Text = "Підключення";
            // 
            // paymentsToolStripMenuItem
            // 
            this.paymentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewPaymentsToolStripMenuItem});
            this.paymentsToolStripMenuItem.Name = "paymentsToolStripMenuItem";
            this.paymentsToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.paymentsToolStripMenuItem.Text = "Платежі";
            // 
            // supportToolStripMenuItem
            // 
            this.supportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supportTicketsToolStripMenuItem});
            this.supportToolStripMenuItem.Name = "supportToolStripMenuItem";
            this.supportToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
            this.supportToolStripMenuItem.Text = "Технічна підтримка";
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientReportToolStripMenuItem,
            this.tariffReportToolStripMenuItem,
            this.paymentReportToolStripMenuItem,
            this.financialReportToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.reportsToolStripMenuItem.Text = "Звіти";
            // 
            // viewClientsToolStripMenuItem
            // 
            this.viewClientsToolStripMenuItem.Name = "viewClientsToolStripMenuItem";
            this.viewClientsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.viewClientsToolStripMenuItem.Text = "Перегляд клієнтів";
            this.viewClientsToolStripMenuItem.Click += new System.EventHandler(this.viewClientsToolStripMenuItem_Click);
            // 
            // viewTariffsToolStripMenuItem
            // 
            this.viewTariffsToolStripMenuItem.Name = "viewTariffsToolStripMenuItem";
            this.viewTariffsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.viewTariffsToolStripMenuItem.Text = "Перегляд тарифів";
            this.viewTariffsToolStripMenuItem.Click += new System.EventHandler(this.viewTariffsToolStripMenuItem_Click);
            // 
            // viewConnectionsToolStripMenuItem
            // 
            this.viewConnectionsToolStripMenuItem.Name = "viewConnectionsToolStripMenuItem";
            this.viewConnectionsToolStripMenuItem.Size = new System.Drawing.Size(243, 26);
            this.viewConnectionsToolStripMenuItem.Text = "Перегляд підключень";
           
            // viewPaymentsToolStripMenuItem
            // 
            this.viewPaymentsToolStripMenuItem.Name = "viewPaymentsToolStripMenuItem";
            this.viewPaymentsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.viewPaymentsToolStripMenuItem.Text = "Перегляд платежів";
           
            // 
            // supportTicketsToolStripMenuItem
            // 
            this.supportTicketsToolStripMenuItem.Name = "supportTicketsToolStripMenuItem";
            this.supportTicketsToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.supportTicketsToolStripMenuItem.Text = "Заявки на техпідтримку";
           
            // 
            // clientReportToolStripMenuItem
            // 
            this.clientReportToolStripMenuItem.Name = "clientReportToolStripMenuItem";
            this.clientReportToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.clientReportToolStripMenuItem.Text = "Звіт по клієнтам";
            this.clientReportToolStripMenuItem.Click += new System.EventHandler(this.clientReportToolStripMenuItem_Click);
            // 
            // tariffReportToolStripMenuItem
            // 
            this.tariffReportToolStripMenuItem.Name = "tariffReportToolStripMenuItem";
            this.tariffReportToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.tariffReportToolStripMenuItem.Text = "Звіт по тарифам";
            this.tariffReportToolStripMenuItem.Click += new System.EventHandler(this.tariffReportToolStripMenuItem_Click);
            // 
            // paymentReportToolStripMenuItem
            // 
            this.paymentReportToolStripMenuItem.Name = "paymentReportToolStripMenuItem";
            this.paymentReportToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.paymentReportToolStripMenuItem.Text = "Звіт по платежам";
           
            // 
            // financialReportToolStripMenuItem
            // 
            this.financialReportToolStripMenuItem.Name = "financialReportToolStripMenuItem";
            this.financialReportToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.financialReportToolStripMenuItem.Text = "Фінансовий звіт";
            this.financialReportToolStripMenuItem.Click += new System.EventHandler(this.financialReportToolStripMenuItem_Click);
            // 
            // groupBoxStatistics
            // 
            this.groupBoxStatistics.Controls.Add(this.labelTicketsCount);
            this.groupBoxStatistics.Controls.Add(this.labelConnectionsCount);
            this.groupBoxStatistics.Controls.Add(this.labelClientsCount);
            this.groupBoxStatistics.Controls.Add(this.labelTicketsTitle);
            this.groupBoxStatistics.Controls.Add(this.labelConnectionsTitle);
            this.groupBoxStatistics.Controls.Add(this.labelClientsTitle);
            this.groupBoxStatistics.Location = new System.Drawing.Point(124, 115);
            this.groupBoxStatistics.Name = "groupBoxStatistics";
            this.groupBoxStatistics.Size = new System.Drawing.Size(628, 181);
            this.groupBoxStatistics.TabIndex = 1;
            this.groupBoxStatistics.TabStop = false;
            this.groupBoxStatistics.Text = "Статистика";
            //this.groupBoxStatistics.Enter += new System.EventHandler(this.groupBoxStatistics_Enter);
            // 
            // labelClientsTitle
            // 
            this.labelClientsTitle.AutoSize = true;
            this.labelClientsTitle.Location = new System.Drawing.Point(20, 30);
            this.labelClientsTitle.Name = "labelClientsTitle";
            this.labelClientsTitle.Size = new System.Drawing.Size(60, 16);
            this.labelClientsTitle.TabIndex = 0;
            this.labelClientsTitle.Text = "Клієнтів";
            // 
            // labelConnectionsTitle
            // 
            this.labelConnectionsTitle.AutoSize = true;
            this.labelConnectionsTitle.Location = new System.Drawing.Point(20, 60);
            this.labelConnectionsTitle.Name = "labelConnectionsTitle";
            this.labelConnectionsTitle.Size = new System.Drawing.Size(149, 16);
            this.labelConnectionsTitle.TabIndex = 1;
            this.labelConnectionsTitle.Text = "Активних підключень:";
            // 
            // labelTicketsTitle
            // 
            this.labelTicketsTitle.AutoSize = true;
            this.labelTicketsTitle.Location = new System.Drawing.Point(20, 90);
            this.labelTicketsTitle.Name = "labelTicketsTitle";
            this.labelTicketsTitle.Size = new System.Drawing.Size(123, 16);
            this.labelTicketsTitle.TabIndex = 2;
            this.labelTicketsTitle.Text = "Відкритих заявок:";
            // 
            // labelClientsCount
            // 
            this.labelClientsCount.AutoSize = true;
            this.labelClientsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelClientsCount.Location = new System.Drawing.Point(150, 30);
            this.labelClientsCount.Name = "labelClientsCount";
            this.labelClientsCount.Size = new System.Drawing.Size(18, 20);
            this.labelClientsCount.TabIndex = 3;
            this.labelClientsCount.Text = "0";
            // 
            // labelConnectionsCount
            // 
            this.labelConnectionsCount.AutoSize = true;
            this.labelConnectionsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelConnectionsCount.Location = new System.Drawing.Point(175, 60);
            this.labelConnectionsCount.Name = "labelConnectionsCount";
            this.labelConnectionsCount.Size = new System.Drawing.Size(18, 20);
            this.labelConnectionsCount.TabIndex = 4;
            this.labelConnectionsCount.Text = "0";
            // 
            // labelTicketsCount
            // 
            this.labelTicketsCount.AutoSize = true;
            this.labelTicketsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTicketsCount.Location = new System.Drawing.Point(151, 90);
            this.labelTicketsCount.Name = "labelTicketsCount";
            this.labelTicketsCount.Size = new System.Drawing.Size(18, 20);
            this.labelTicketsCount.TabIndex = 5;
            this.labelTicketsCount.Text = "0";
            // 
            // btnAddClient
            // 
            this.btnAddClient.Location = new System.Drawing.Point(147, 302);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(150, 30);
            this.btnAddClient.TabIndex = 6;
            this.btnAddClient.Text = "Додати клієнта";
            this.btnAddClient.UseVisualStyleBackColor = true;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // btnAddPayment
            // 
            this.btnAddPayment.Location = new System.Drawing.Point(147, 351);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.Size = new System.Drawing.Size(150, 30);
            this.btnAddPayment.TabIndex = 7;
            this.btnAddPayment.Text = "Швидкий платіж";
            this.btnAddPayment.UseVisualStyleBackColor = true;
           
            // 
            // btnAddTicket
            // 
            this.btnAddTicket.Location = new System.Drawing.Point(147, 400);
            this.btnAddTicket.Name = "btnAddTicket";
            this.btnAddTicket.Size = new System.Drawing.Size(150, 30);
            this.btnAddTicket.TabIndex = 8;
            this.btnAddTicket.Text = "Створити заявку";
            this.btnAddTicket.UseVisualStyleBackColor = true;
            this.btnAddTicket.Click += new System.EventHandler(this.btnAddTicket_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.btnAddTicket);
            this.Controls.Add(this.btnAddPayment);
            this.Controls.Add(this.btnAddClient);
            this.Controls.Add(this.groupBoxStatistics);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Система керування інтернет-провайдером";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxStatistics.ResumeLayout(false);
            this.groupBoxStatistics.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItemфайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewClientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tariffsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewTariffsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewConnectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewPaymentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supportTicketsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tariffReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem financialReportToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxStatistics;
        private System.Windows.Forms.Label labelClientsCount;
        private System.Windows.Forms.Label labelTicketsTitle;
        private System.Windows.Forms.Label labelConnectionsTitle;
        private System.Windows.Forms.Label labelClientsTitle;
        private System.Windows.Forms.Label labelTicketsCount;
        private System.Windows.Forms.Label labelConnectionsCount;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.Button btnAddPayment;
        private System.Windows.Forms.Button btnAddTicket;
    }
}

