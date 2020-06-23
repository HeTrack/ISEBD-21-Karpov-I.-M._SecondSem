using SoftShopBusinessLogic.BindingModels;
using SoftShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SoftShopWarehouseView
{
    public partial class FormFillWarehouse : Form
    {
        private int id;

        public FormFillWarehouse(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        private void FormFillWarehouse_Load(object sender, System.EventArgs e)
        {
            try
            {
                List<SoftViewModel> list = APIWarehouse.GetRequest<List<SoftViewModel>>($"api/Warehouse/getsoftslist");
                if (list != null)
                {
                    comboBoxSoft.DisplayMember = "SoftName";
                    comboBoxSoft.ValueMember = "Id";
                    comboBoxSoft.DataSource = list;
                    comboBoxSoft.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonSave_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxSoft.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                APIWarehouse.PostRequest("api/Warehouse/fillwarehouse", new WarehouseSoftBindingModel
                {
                    Id = 0,
                    WarehouseId = id,
                    SoftId = Convert.ToInt32(comboBoxSoft.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
