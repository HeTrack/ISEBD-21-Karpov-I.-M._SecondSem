using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoftShopBusinessLogic.BindingModels;
using SoftShopBusinessLogic.BusinessLogics;
using Unity;
using SoftShopBusinessLogic.Interfaces;

namespace SoftShopView
{
    public partial class FormReportWarehouseSofts : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        private readonly IWarehouseLogic warehouseLogic;
        public FormReportWarehouseSofts(ReportLogic logic, IWarehouseLogic warehouseLogic)
        {
            InitializeComponent();
            this.logic = logic;
            this.warehouseLogic = warehouseLogic;
        }
        private void ButtonMake_Click(object sender, EventArgs e)
        {
            try
            {
                var dict = warehouseLogic.GetList();
                if (dict != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var elem in dict)
                    {
                        int sum = 0;
                        dataGridView.Rows.Add(new object[] { elem.WarehouseName, "", "" });
                        foreach (var listElem in elem.WarehouseSofts)
                        {
                            dataGridView.Rows.Add(new object[] { "", listElem.SoftName, listElem.Count });
                            sum += listElem.Count;
                        }
                        dataGridView.Rows.Add(new object[] { "Итого", "", sum });
                        dataGridView.Rows.Add(new object[] { });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonSaveToExcel_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveWarehouseSoftsToExcelFile(new ReportBindingModel { FileName = dialog.FileName });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}