namespace SoftShopWarehouseView
{
    partial class FormWarehouse
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
            this.warehouseNameLabel = new System.Windows.Forms.Label();
            this.warehouseNameTextBox = new System.Windows.Forms.TextBox();
            this.softsGroupBox = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.softsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // warehouseNameLabel
            // 
            this.warehouseNameLabel.AutoSize = true;
            this.warehouseNameLabel.Location = new System.Drawing.Point(21, 9);
            this.warehouseNameLabel.Name = "warehouseNameLabel";
            this.warehouseNameLabel.Size = new System.Drawing.Size(60, 13);
            this.warehouseNameLabel.TabIndex = 0;
            this.warehouseNameLabel.Text = "Название:";
            // 
            // warehouseNameTextBox
            // 
            this.warehouseNameTextBox.Location = new System.Drawing.Point(87, 6);
            this.warehouseNameTextBox.Name = "warehouseNameTextBox";
            this.warehouseNameTextBox.Size = new System.Drawing.Size(234, 20);
            this.warehouseNameTextBox.TabIndex = 1;
            // 
            // softsGroupBox
            // 
            this.softsGroupBox.Controls.Add(this.dataGridView);
            this.softsGroupBox.Location = new System.Drawing.Point(11, 43);
            this.softsGroupBox.Name = "softsGroupBox";
            this.softsGroupBox.Size = new System.Drawing.Size(405, 362);
            this.softsGroupBox.TabIndex = 2;
            this.softsGroupBox.TabStop = false;
            this.softsGroupBox.Text = "Компоненты";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 19);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(403, 342);
            this.dataGridView.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(260, 411);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(341, 411);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 443);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.softsGroupBox);
            this.Controls.Add(this.warehouseNameTextBox);
            this.Controls.Add(this.warehouseNameLabel);
            this.Name = "FormWarehouse";
            this.Text = "Склад";
            this.Load += new System.EventHandler(this.FormWarehouse_Load);
            this.softsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label warehouseNameLabel;
        private System.Windows.Forms.TextBox warehouseNameTextBox;
        private System.Windows.Forms.GroupBox softsGroupBox;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}