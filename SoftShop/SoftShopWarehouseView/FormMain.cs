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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            LoadList();
        }
        private void LoadList()
        {
            try
            {
                dataGridView.DataSource = APIWarehouse.GetRequest<List<WarehouseViewModel>>($"api/warehouse/getwarehouseslist");
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void создатьСкладToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormWarehouse();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadList();
            }
        }
        private void изменитьСкладToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = new FormWarehouse();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadList();
                }
            }
            else
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void пополнитьСкладToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = new FormFillWarehouse(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                form.labelWarehouse.Text = dataGridView.SelectedRows[0].Cells[1].Value.ToString();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadList();
                }
            }
            else
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void удалитьСкладToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        APIWarehouse.PostRequest("api/warehouse/deletewarehouse", new WarehouseBindingModel
                        {
                            Id = id,
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadList();
                }
            }
            else
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void обновитьСписокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadList();
        }
    }
}