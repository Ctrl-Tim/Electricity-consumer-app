using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.BusinessLogicsContracts;
using System;
using System.Linq;
using System.Windows.Forms;
using Unity;


namespace ElectricityConsumerView
{
    public partial class FormConsumers : Form
    {
        private readonly IConsumerLogic _logic;

        public FormConsumers(IConsumerLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormConsumers_Load(object sender, EventArgs e)
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
                    dataGridView.DataSource = list.OrderBy(x => x.SurName).ToList();
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[4].Visible = false;
                    labelCount.Text = "Кол-во потребителей: " + list.Count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormConsumer>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormConsumer>();
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
                        _logic.Delete(new ConsumerBindingModel { Id = id });
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
                case "SurName":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            dataGridView.DataSource = list.OrderBy(x => x.SurName).ToList();
                        }
                        else
                        {
                            dataGridView.DataSource = list.OrderByDescending(x => x.SurName).ToList();
                        }
                        break;
                    }
                case "FirstName":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            dataGridView.DataSource = list.OrderBy(x => x.FirstName).ToList();
                        }
                        else
                        {
                            dataGridView.DataSource = list.OrderByDescending(x => x.FirstName).ToList();
                        }
                        break;
                    }
                case "Patronymic":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            dataGridView.DataSource = list.OrderBy(x => x.Patronymic).ToList();
                        }
                        else
                        {
                            dataGridView.DataSource = list.OrderByDescending(x => x.Patronymic).ToList();
                        }
                        break;
                    }
            }
        }
    }
}
