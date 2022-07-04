using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.BusinessLogicsContracts;
using System;
using System.Linq;
using System.Windows.Forms;
using Unity;

namespace ElectricityConsumerView
{
    public partial class FormElectricMeters : Form
    {
        private readonly IElectricMeterLogic _logic;

        public FormElectricMeters(IElectricMeterLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormElectricMeters_Load(object sender, EventArgs e)
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
                    dataGridView.DataSource = list.OrderBy(x => x.Number).ToList();
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].Width = 100;
                    dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[6].Width = 70;
                    dataGridView.Columns[7].Width = 100;
                    dataGridView.Columns[8].Width = 85;
                    labelCount.Text = "Кол-во счётчиков: " + list.Count;
                }
                CheckExpiredDate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormElectricMeter>();
            form.ShowDialog();
            LoadData();
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormElectricMeter>();
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
                        _logic.Delete(new ElectricMeterBindingModel { Id = id });
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

        private void CheckExpiredDate()
        {
            //подсветка записей с истекшим сроком госповерки
            foreach (DataGridViewRow row in dataGridView.Rows)
                if (Convert.ToDateTime(row.Cells[9].Value).AddYears(Convert.ToInt32(row.Cells[8].Value)) < DateTime.Today)
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                }
        }

        private void buttonCheckInspection_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    _logic.CheckInspection(new ElectricMeterBindingModel { Id = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            CheckExpiredDate();
        }

        private void Sort(string column, SortOrder sortOrder)
        {
            var list = _logic.Read(null);
            switch (column)
            {
                case "Number":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            dataGridView.DataSource = list.OrderBy(x => x.Number).ToList();
                        }
                        else
                        {
                            dataGridView.DataSource = list.OrderByDescending(x => x.Number).ToList();
                        }
                        break;
                    }
                case "TypeName":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            dataGridView.DataSource = list.OrderBy(x => x.TypeName).ToList();
                        }
                        else
                        {
                            dataGridView.DataSource = list.OrderByDescending(x => x.TypeName).ToList();
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
                case "DateOfCheck":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            dataGridView.DataSource = list.OrderBy(x => x.DateOfCheck).ToList();
                        }
                        else
                        {
                            dataGridView.DataSource = list.OrderByDescending(x => x.DateOfCheck).ToList();
                        }
                        break;
                    }
                case "InspectionPeriod":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            dataGridView.DataSource = list.OrderBy(x => x.InspectionPeriod).ToList();
                        }
                        else
                        {
                            dataGridView.DataSource = list.OrderByDescending(x => x.InspectionPeriod).ToList();
                        }
                        break;
                    }
                case "FinalInspection":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            dataGridView.DataSource = list.OrderBy(x => x.FinalInspection).ToList();
                        }
                        else
                        {
                            dataGridView.DataSource = list.OrderByDescending(x => x.FinalInspection).ToList();
                        }
                        break;
                    }
            }
        }
    }
}
