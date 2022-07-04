using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.BusinessLogicsContracts;
using ElectricityConsumerContracts.ViewModels;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ElectricityConsumerView
{
    public partial class FormReadMeter : Form
    {
        private readonly IElectricMeterLogic _logicE;
        private readonly ICounterReadingsLogic _logicR;

        public FormReadMeter(IElectricMeterLogic logicE, ICounterReadingsLogic logicR)
        {
            InitializeComponent();
            _logicE = logicE;
            _logicR = logicR;
        }

        private void FormReadMeter_Load(object sender, EventArgs e)
        {
            try
            {
                List<ElectricMeterViewModel> listMeters = _logicE.Read(null);
                if (listMeters != null)
                {
                    comboBoxNumber.DisplayMember = "Number";
                    comboBoxNumber.ValueMember = "Id";
                    comboBoxNumber.DataSource = listMeters;
                    comboBoxNumber.SelectedItem = null;
                    comboBoxNumber.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboBoxNumber.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
                else
                {
                    throw new Exception("Не удалось загрузить список счётчиков");
                }

                textBoxAddress.Text = " ";
                textBoxConsumer.Text = " ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckInfo()
        {
            if (comboBoxNumber.SelectedValue != null)
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxNumber.SelectedValue);
                    ElectricMeterViewModel em = _logicE.Read(new ElectricMeterBindingModel { Id = id })?[0];
                    textBoxAddress.Text = em.FullAddress.ToString();
                    textBoxConsumer.Text = em.ConsumerFIO.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboBoxNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckInfo();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxNumber.SelectedValue == null)
            {
                MessageBox.Show("Выберите номер счётчика", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxBegin.Text))
            {
                MessageBox.Show("Заполните показания в начале месяца", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxEnd.Text))
            {
                MessageBox.Show("Заполните показания в конце месяца", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 
            try
            {
                _logicE.CreateReading(new ElectricMeterBindingModel { Id = Convert.ToInt32(comboBoxNumber.SelectedValue) });
                _logicR.CreateReading(new CreateReadingBindingModel
                {
                    Id = Convert.ToInt32(comboBoxNumber.SelectedValue),
                    ElectricMeterId = Convert.ToInt32(comboBoxNumber.SelectedValue),
                    BeginningOfMonth = (float)Convert.ToDouble(textBoxBegin.Text),
                    EndOfMonth = (float)Convert.ToDouble(textBoxEnd.Text)
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
