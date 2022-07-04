using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.BusinessLogicsContracts;
using ElectricityConsumerContracts.ViewModels;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using Unity;

namespace ElectricityConsumerView
{
    public partial class FormMain : Form
    {
        private readonly ICounterReadingsLogic _logicR;
        private readonly IConsumerLogic _logicC;

        private int consumerId = 1;

        public FormMain(ICounterReadingsLogic logicR, IConsumerLogic logicC)
        {
            InitializeComponent();
            _logicR = logicR;
            _logicC = logicC;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            List<ConsumerViewModel> listConsumers = _logicC.Read(null);
            if (listConsumers != null)
            {
                comboBoxConsumer.DisplayMember = "FIO";
                comboBoxConsumer.ValueMember = "Id";
                comboBoxConsumer.DataSource = listConsumers;
                comboBoxConsumer.SelectedItem = consumerId;
                comboBoxConsumer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBoxConsumer.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            else
            {
                throw new Exception("Не удалось загрузить список потребителей");
            }

            try
            {
                var list = _logicR.Read(null);
                if (list != null)
                {
                    dataGridView.DataSource = list.Where(x => x.ConsumerId == consumerId).ToList().OrderBy(x => x.Number).ToList();
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].Width = 100;
                    dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void потребителиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consumerId = Convert.ToInt32(comboBoxConsumer.SelectedValue);
            var form = Program.Container.Resolve<FormConsumers>();
            form.ShowDialog();
            LoadData();
        }

        private void адресаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormAddresses>();
            form.ShowDialog();
        }

        private void типыСчётчиковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormTypes>();
            form.ShowDialog();
        }

        private void электросчётчикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormElectricMeters>();
            form.ShowDialog();
        }

        private void снятьПоказанияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consumerId = Convert.ToInt32(comboBoxConsumer.SelectedValue);
            var form = Program.Container.Resolve<FormReadMeter>();
            form.ShowDialog();
            LoadData();
        }

        private void comboBoxConsumer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConsumerReadings();
        }

        private void ConsumerReadings()
        {
            if (comboBoxConsumer.SelectedValue != null)
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxConsumer.SelectedValue);
                    consumerId = id;
                    var list = _logicR.Read(null);

                    if (list != null)
                    {
                        dataGridView.DataSource = list.Where(x => x.ConsumerId == id).ToList();
                        dataGridView.Columns[0].Visible = false;
                        dataGridView.Columns[1].Visible = false;
                        dataGridView.Columns[2].Visible = false;
                        dataGridView.Columns[3].Width = 100;
                        dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dataGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
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
        }

        private void Sort(string column, SortOrder sortOrder)
        {
            var list = _logicR.Read(null);
            switch (column)
            {
                case "Number":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            dataGridView.DataSource = list.Where(x => x.ConsumerId == consumerId).ToList().OrderBy(x => x.Number).ToList();
                        }
                        else
                        {
                            dataGridView.DataSource = list.Where(x => x.ConsumerId == consumerId).ToList().OrderByDescending(x => x.Number).ToList();
                        }
                        break;
                    }
                case "FullAddress":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            dataGridView.DataSource = list.Where(x => x.ConsumerId == consumerId).ToList().OrderBy(x => x.FullAddress).ToList();
                        }
                        else
                        {
                            dataGridView.DataSource = list.Where(x => x.ConsumerId == consumerId).ToList().OrderByDescending(x => x.FullAddress).ToList();
                        }
                        break;
                    }
                case "Date":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            dataGridView.DataSource = list.Where(x => x.ConsumerId == consumerId).ToList().OrderBy(x => x.Date).ToList();
                        }
                        else
                        {
                            dataGridView.DataSource = list.Where(x => x.ConsumerId == consumerId).ToList().OrderByDescending(x => x.Date).ToList();
                        }
                        break;
                    }
                case "BeginningOfMonth":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            dataGridView.DataSource = list.Where(x => x.ConsumerId == consumerId).ToList().OrderBy(x => x.BeginningOfMonth).ToList();
                        }
                        else
                        {
                            dataGridView.DataSource = list.Where(x => x.ConsumerId == consumerId).ToList().OrderByDescending(x => x.BeginningOfMonth).ToList();
                        }
                        break;
                    }
                case "EndOfMonth":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            dataGridView.DataSource = list.Where(x => x.ConsumerId == consumerId).ToList().OrderBy(x => x.EndOfMonth).ToList();
                        }
                        else
                        {
                            dataGridView.DataSource = list.Where(x => x.ConsumerId == consumerId).ToList().OrderByDescending(x => x.EndOfMonth).ToList();
                        }
                        break;
                    }
            }
        }
    }
}
