namespace SoftShopView
{
    partial class FormMain
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пакетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.исполнителиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderDatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packSoftsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запускРаботToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonPayOrder = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.сообщенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            //
            // menuStrip
            //
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
this.справочникиToolStripMenuItem,
this.reportsToolStripMenuItem,
this.запускРаботToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1142, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            //
            // справочникиToolStripMenuItem
            //
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
this.поToolStripMenuItem,
this.пакетыToolStripMenuItem,
this.клиентыToolStripMenuItem,
this.исполнителиToolStripMenuItem,
this.сообщенияToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            //
            // сообщенияToolStripMenuItem
            //
            this.сообщенияToolStripMenuItem.Name = "сообщенияToolStripMenuItem";
            this.сообщенияToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.сообщенияToolStripMenuItem.Text = "Сообщения";
            this.сообщенияToolStripMenuItem.Click += new System.EventHandler(this.сообщенияToolStripMenuItem_Click);
            //
            // поToolStripMenuItem
            //
            this.поToolStripMenuItem.Name = "поToolStripMenuItem";
            this.поToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.поToolStripMenuItem.Text = "ПО";
            this.поToolStripMenuItem.Click += new System.EventHandler(this.поToolStripMenuItem_Click);
            //
            // пакетыToolStripMenuItem
            //
            this.пакетыToolStripMenuItem.Name = "пакетыToolStripMenuItem";
            this.пакетыToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.пакетыToolStripMenuItem.Text = "Пакеты";
            this.пакетыToolStripMenuItem.Click += new

            System.EventHandler(this.пакетыToolStripMenuItem_Click);
            //
            // клиентыToolStripMenuItem
            //
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            //
            // исполнителиToolStripMenuItem
            //
            this.исполнителиToolStripMenuItem.Name = "исполнителиToolStripMenuItem";
            this.исполнителиToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.исполнителиToolStripMenuItem.Text = "Исполнители";
            this.исполнителиToolStripMenuItem.Click += new System.EventHandler(this.исполнителиToolStripMenuItem_Click);
            //
            // reportsToolStripMenuItem
            //
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
this.packsToolStripMenuItem,
this.orderDatesToolStripMenuItem,
this.packSoftsToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.reportsToolStripMenuItem.Text = "Отчеты";
            //
            // packsToolStripMenuItem
            //
            this.packsToolStripMenuItem.Name = "packsToolStripMenuItem";
            this.packsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.packsToolStripMenuItem.Text = "Список пакетов";
            this.packsToolStripMenuItem.Click += new System.EventHandler(this.packsToolStripMenuItem_Click);
            //
            // orderDatesToolStripMenuItem
            //
            this.orderDatesToolStripMenuItem.Name = "orderDatesToolStripMenuItem";
            this.orderDatesToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.orderDatesToolStripMenuItem.Text = "Заказы по датам";
            this.orderDatesToolStripMenuItem.Click += new System.EventHandler(this.orderDatesToolStripMenuItem_Click);
            //
            // packSoftsToolStripMenuItem
            //
            this.packSoftsToolStripMenuItem.Name = "packSoftsToolStripMenuItem";
            this.packSoftsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.packSoftsToolStripMenuItem.Text = "Детали пакетов";
            this.packSoftsToolStripMenuItem.Click += new System.EventHandler(this.packSoftsToolStripMenuItem_Click);
            //
            // запускРаботToolStripMenuItem
            //
            this.запускРаботToolStripMenuItem.Name = "запускРаботToolStripMenuItem";
            this.запускРаботToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.запускРаботToolStripMenuItem.Text = "Запуск работ";
            this.запускРаботToolStripMenuItem.Click += new System.EventHandler(this.запускРаботToolStripMenuItem_Click);
            //
            // dataGridView
            //
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 33);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(936, 518);
            this.dataGridView.TabIndex = 1;
            //
            // buttonCreateOrder
            //
            this.buttonCreateOrder.Location = new System.Drawing.Point(943, 90);
            this.buttonCreateOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(189, 36);
            this.buttonCreateOrder.TabIndex = 2;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            //
            // buttonPayOrder
            //

            this.buttonPayOrder.Location = new System.Drawing.Point(944, 346);
            this.buttonPayOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonPayOrder.Name = "buttonPayOrder";
            this.buttonPayOrder.Size = new System.Drawing.Size(185, 36);
            this.buttonPayOrder.TabIndex = 5;
            this.buttonPayOrder.Text = "Заказ оплачен";
            this.buttonPayOrder.UseVisualStyleBackColor = true;
            this.buttonPayOrder.Click += new System.EventHandler(this.buttonPayOrder_Click);
            //
            // buttonRef
            //
            this.buttonRef.Location = new System.Drawing.Point(948, 426);
            this.buttonRef.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(184, 33);
            this.buttonRef.TabIndex = 6;
            this.buttonRef.Text = "Обновить";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            //
            // FormMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 554);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonPayOrder);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Магазин ПО";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пакетыToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button buttonPayOrder;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem packsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem packSoftsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderDatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem исполнителиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запускРаботToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сообщенияToolStripMenuItem;
    }
}