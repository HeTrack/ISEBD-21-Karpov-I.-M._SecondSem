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
    public partial class FormWarehouse : Form
    {
        public int Id { set { id = value; } }
        private int? id;
        private List<WarehouseSoftViewModel> warehouseSofts;
        public FormWarehouse()
        {
            InitializeComponent();
        }
        private void FormWarehouse_Load(object sender, EventArgs e)
        {
            dataGridView.Columns.Add("Id", "Id");
            dataGridView.Columns.Add("ПО", "ПО");
            dataGridView.Columns.Add("Количество", "Количество");
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (id.HasValue)
            {
                try
                {
                    WarehouseViewModel view = APIWarehouse.GetRequest<WarehouseViewModel>($"api/warehouse/getwarehouse?warehouseId={id.Value}");
                    if (view != null)
                    {
                        warehouseNameTextBox.Text = view.WarehouseName;
                        warehouseSofts = view.WarehouseSofts;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                warehouseSofts = new List<WarehouseSoftViewModel>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (warehouseSofts != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var warehouseSoft in warehouseSofts)
                    {
                        dataGridView.Rows.Add(new object[] { warehouseSoft.Id, warehouseSoft.SoftName, warehouseSoft.Count });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(warehouseNameTextBox.Text))
            {
                MessageBox.Show("Заполните поле Название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                APIWarehouse.PostRequest("api/Warehouse/createorupdatewarehouse", new WarehouseBindingModel
                {
                    Id = id,
                    WarehouseName = warehouseNameTextBox.Text
                });
                MessageBox.Show("Успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}