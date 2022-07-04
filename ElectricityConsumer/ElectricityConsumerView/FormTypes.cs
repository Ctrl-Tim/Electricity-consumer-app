using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.BusinessLogicsContracts;
using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Linq;
using Unity;

namespace ElectricityConsumerView
{
    public partial class FormTypes : Form
    {
        private readonly ITypeElectricMeterLogic _logic;

        public FormTypes(ITypeElectricMeterLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormTypes_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = _logic.Read(null);
                if (list != null)
                {
                    dataGridView.DataSource = list.OrderBy(x => x.Name).ToList();
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    labelCount.Text = "Кол-во типов: " + list.Count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormType>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormType>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        _logic.Delete(new TypeElectricMeterBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            SortOrder so = SortOrder.None;
            if (grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None ||
                grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Ascending)
            {
                so = SortOrder.Descending;
            }
            else
            {
                so = SortOrder.Ascending;
            }
            //установка SortGlyphDirection после привязки к базе данных, иначе всегда будет none 
            Sort(grid.Columns[e.ColumnIndex].Name, so);
            grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = so;
        }

        private void Sort(string column, SortOrder sortOrder)
        {
            var list = _logic.Read(null);
            switch (column)
            {
                case "Name":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            dataGridView.DataSource = list.OrderBy(x => x.Name).ToList();
                        }
                        else
                        {
                            dataGridView.DataSource = list.OrderByDescending(x => x.Name).ToList();
                        }
                        break;
                    }
            }
        }
    }
}
