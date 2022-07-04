using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.BusinessLogicsContracts;
using System;
using System.Linq;
using System.Windows.Forms;
using Unity;

namespace ElectricityConsumerView
{
    public partial class FormAddresses : Form
    {
        private readonly IAddressLogic _logic;

        public FormAddresses(IAddressLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormAddresses_Load(object sender, EventArgs e)
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
                    dataGridView.DataSource = list.OrderBy(x => x.FullAddress).ToList();
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].Visible = false;
                    dataGridView.Columns[4].Visible = false;
                    dataGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[7].Width = 80;
                    labelCount.Text = "Кол-во адресов: " + list.Count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormAddress>();
            form.ShowDialog();
            LoadData();
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormAddress>();
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
                        _logic.Delete(new AddressBindingModel { Id = id });
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
                case "FullAddress":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            dataGridView.DataSource = list.OrderBy(x => x.FullAddress).ToList();
                        }
                        else
                        {
                            dataGridView.DataSource = list.OrderByDescending(x => x.FullAddress).ToList();
                        }
                        break;
                    }
                case "ConsumerFIO":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            dataGridView.DataSource = list.OrderBy(x => x.ConsumerFIO).ToList();
                        }
                        else
                        {
                            dataGridView.DataSource = list.OrderByDescending(x => x.ConsumerFIO).ToList();
                        }
                        break;
                    }
                case "ElectricMeterNumber":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            dataGridView.DataSource = list.OrderBy(x => x.ElectricMeterNumber).ToList();
                        }
                        else
                        {
                            dataGridView.DataSource = list.OrderByDescending(x => x.ElectricMeterNumber).ToList();
                        }
                        break;
                    }
            }
        }
    }
}
