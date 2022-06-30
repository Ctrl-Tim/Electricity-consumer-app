using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.BusinessLogicsContracts;
using ElectricityConsumerContracts.ViewModels;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Unity;

namespace ElectricityConsumerView
{
    public partial class FormElectricMeter : Form
    {
        public int Id { set { id = value; } }
        private int? id;

        private readonly ITypeElectricMeterLogic _logicT;
        private readonly IAddressLogic _logicA;
        private readonly IElectricMeterLogic _logicE;

        public FormElectricMeter(ITypeElectricMeterLogic logicT, IAddressLogic logicA, IElectricMeterLogic logicE)
        {
            InitializeComponent();
            _logicT = logicT;
            _logicA = logicA;
            _logicE = logicE;
        }

        private void FormElectricMeter_Load(object sender, EventArgs e)
        {
            try
            {
                List<TypeElectricMeterViewModel> listTypes = _logicT.Read(null);
                if (listTypes != null)
                {
                    comboBoxType.DisplayMember = "Name";
                    comboBoxType.ValueMember = "Id";
                    comboBoxType.DataSource = listTypes;
                    comboBoxType.SelectedItem = null;
                }
                else
                {
                    throw new Exception("Не удалось загрузить список типов");
                }

                List<AddressViewModel> listAddresses = _logicA.Read(null);
                if (listAddresses != null)
                {
                    comboBoxAddress.DisplayMember = "FullAddress";
                    comboBoxAddress.ValueMember = "Id";
                    comboBoxAddress.DataSource = listAddresses;
                    comboBoxAddress.SelectedItem = null;
                }
                else
                {
                    throw new Exception("Не удалось загрузить список адресов");
                }

                textBoxConsumer.Text = " ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (id.HasValue)
            {
                try
                {
                    var view = _logicE.Read(new ElectricMeterBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        comboBoxType.SelectedValue = view.TypeId;
                        textBoxNumber.Text = view.Number.ToString();
                        comboBoxAddress.SelectedValue = view.Id;
                        dateTimePickerDateOfCheck.Value = (DateTime)view.DateOfCheck;
                        textBoxInspectionPeriod.Text = view.InspectionPeriod.ToString();
                        dateTimePickerFinalInspection.Value = (DateTime)view.FinalInspection;
                    }
                    else
                    {
                        throw new Exception("Не удалось загрузить список потребителей");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CheckConsumer()
        {
            if (comboBoxAddress.SelectedValue != null)
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxAddress.SelectedValue);
                    AddressViewModel address = _logicA.Read(new AddressBindingModel { Id = id })?[0];
                    textBoxConsumer.Text = address.ConsumerFIO.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboBoxAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckConsumer();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedValue == null)
            {
                MessageBox.Show("Выберите тип", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxNumber.Text))
            {
                MessageBox.Show("Заполните поле Номер", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxAddress.SelectedValue == null)
            {
                MessageBox.Show("Выберите адрес", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dateTimePickerDateOfCheck.Value == null)
            {
                MessageBox.Show("Выберите дату приёмки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxInspectionPeriod.Text))
            {
                MessageBox.Show("Заполните поле Срок госпроверки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dateTimePickerFinalInspection.Value == null)
            {
                MessageBox.Show("Выберите дату последней проверки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_logicA.Read(null).FindIndex(x => x.Id == (int)comboBoxAddress.SelectedValue) != -1)
            {
                MessageBox.Show("Адрес уже занят другим счётчиком", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logicE.CreateOrUpdate(new ElectricMeterBindingModel
                {
                    TypeId = Convert.ToInt32(comboBoxType.SelectedValue),
                    Number = Convert.ToDecimal(textBoxNumber.Text),
                    AddressId = Convert.ToInt32(comboBoxAddress.SelectedValue),
                    DateOfCheck = dateTimePickerDateOfCheck.Value,
                    InspectionPeriod = Convert.ToInt32(textBoxInspectionPeriod.Text),
                    FinalInspection = dateTimePickerFinalInspection.Value
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
