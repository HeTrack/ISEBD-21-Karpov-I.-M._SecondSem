using SoftShopBusinessLogic.BindingModels;
using SoftShopBusinessLogic.BusinessLogics;
using SoftShopBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace SoftShopView
{
    public partial class FormFillWarehouse : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ISoftLogic logicF;
        private readonly MainLogic logicM;
        private readonly IWarehouseLogic logicS;
        public FormFillWarehouse(ISoftLogic logicF, MainLogic logicM, IWarehouseLogic logicS)
        {
            InitializeComponent();
            this.logicF = logicF;
            this.logicM = logicM;
            this.logicS = logicS;
        }
        private void FormFillWarehouse_Load(object sender, EventArgs e)
        {
            try
            {
                var warehouseList = logicS.GetList();
                comboBoxWarehouse.DataSource = warehouseList;
                comboBoxWarehouse.DisplayMember = "WarehouseName";
                comboBoxWarehouse.ValueMember = "Id";

                var softList = logicF.Read(null);
                comboBoxSoft.DataSource = softList;
                comboBoxSoft.DisplayMember = "SoftName";
                comboBoxSoft.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните количество", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }

            if (comboBoxWarehouse.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK,
MessageBoxIcon.Error);
                return;
            }

            if (comboBoxSoft.SelectedValue == null)
            {
                MessageBox.Show("Выберите по", "Ошибка", MessageBoxButtons.OK,
MessageBoxIcon.Error);
                return;
            }

            try
            {
                int warehouseId = Convert.ToInt32(comboBoxWarehouse.SelectedValue);
                int softId = Convert.ToInt32(comboBoxSoft.SelectedValue);
                int count = Convert.ToInt32(textBoxCount.Text);
                this.logicM.FillWarehouse(new WarehouseSoftBindingModel
                {
                    WarehouseId = warehouseId,
                    SoftId = softId,
                    Count = count
                });
                MessageBox.Show("Склад успешно пополнен", "Сообщение",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
MessageBoxIcon.Error);
            }
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}