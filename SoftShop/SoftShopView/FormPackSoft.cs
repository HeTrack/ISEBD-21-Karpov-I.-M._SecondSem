using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoftShopBusinessLogic.Interfaces;
using SoftShopBusinessLogic.ViewModels;
using Unity;

namespace SoftShopView
{
    public partial class FormPackSoft : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id
        {
            get { return Convert.ToInt32(comboBoxSoft.SelectedValue); }
            set { comboBoxSoft.SelectedValue = value; }
        }
        public string SoftName { get { return comboBoxSoft.Text; } }
        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set
            {
                textBoxCount.Text = value.ToString();
            }
        }
        public FormPackSoft(ISoftLogic logic)
        {
            InitializeComponent();
            List<SoftViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBoxSoft.DisplayMember = "SoftName";
                comboBoxSoft.ValueMember = "Id";
                comboBoxSoft.DataSource = list;
                comboBoxSoft.SelectedItem = null;
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxSoft.SelectedValue == null)
            {
                MessageBox.Show("Выберите ПО", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}