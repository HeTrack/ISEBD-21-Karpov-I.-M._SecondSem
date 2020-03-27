namespace SoftShopView
{
    partial class FormFillWarehouse
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelCount = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.labelSoft = new System.Windows.Forms.Label();
            this.labelWarehouse = new System.Windows.Forms.Label();
            this.comboBoxSoft = new System.Windows.Forms.ComboBox();
            this.comboBoxWarehouse = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(171, 121);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(102, 25);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(45, 121);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(102, 25);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(11, 80);
            this.labelCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(66, 13);
            this.labelCount.TabIndex = 10;
            this.labelCount.Text = "Количество";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(132, 73);
            this.textBoxCount.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(141, 20);
            this.textBoxCount.TabIndex = 9;
            // 
            // labelSoft
            // 
            this.labelSoft.AutoSize = true;
            this.labelSoft.Location = new System.Drawing.Point(11, 40);
            this.labelSoft.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSoft.Name = "labelSoft";
            this.labelSoft.Size = new System.Drawing.Size(49, 13);
            this.labelSoft.TabIndex = 7;
            this.labelSoft.Text = "Продукт";
            // 
            // labelWarehouse
            // 
            this.labelWarehouse.AutoSize = true;
            this.labelWarehouse.Location = new System.Drawing.Point(11, 6);
            this.labelWarehouse.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelWarehouse.Name = "labelWarehouse";
            this.labelWarehouse.Size = new System.Drawing.Size(38, 13);
            this.labelWarehouse.TabIndex = 8;
            this.labelWarehouse.Text = "Склад";
            // 
            // comboBoxSoft
            // 
            this.comboBoxSoft.FormattingEnabled = true;
            this.comboBoxSoft.Location = new System.Drawing.Point(132, 40);
            this.comboBoxSoft.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxSoft.Name = "comboBoxSoft";
            this.comboBoxSoft.Size = new System.Drawing.Size(141, 21);
            this.comboBoxSoft.TabIndex = 5;
            // 
            // comboBoxWarehouse
            // 
            this.comboBoxWarehouse.FormattingEnabled = true;
            this.comboBoxWarehouse.Location = new System.Drawing.Point(132, 6);
            this.comboBoxWarehouse.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxWarehouse.Name = "comboBoxWarehouse";
            this.comboBoxWarehouse.Size = new System.Drawing.Size(141, 21);
            this.comboBoxWarehouse.TabIndex = 6;
            // 
            // FormFillWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 193);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelSoft);
            this.Controls.Add(this.labelWarehouse);
            this.Controls.Add(this.comboBoxSoft);
            this.Controls.Add(this.comboBoxWarehouse);
            this.Name = "FormFillWarehouse";
            this.Text = "Заполнение склада";
            this.Load += new System.EventHandler(this.FormFillWarehouse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label labelSoft;
        private System.Windows.Forms.Label labelWarehouse;
        private System.Windows.Forms.ComboBox comboBoxSoft;
        private System.Windows.Forms.ComboBox comboBoxWarehouse;
    }
}