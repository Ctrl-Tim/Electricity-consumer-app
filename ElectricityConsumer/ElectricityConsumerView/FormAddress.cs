using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.BusinessLogicsContracts;
using ElectricityConsumerContracts.ViewModels;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Unity;

namespace ElectricityConsumerView
{
    public partial class FormAddress : Form
    {
        public int Id { set { id = value; } }
        private int? id;

        private readonly IConsumerLogic _logicC;
        private readonly IAddressLogic _logicA;

        public FormAddress(IConsumerLogic logicC, IAddressLogic logicA)
        {
            InitializeComponent();
            _logicC = logicC;
            _logicA = logicA;
        }

        private void FormAddress_Load(object sender, EventArgs e)
        {
            List<ConsumerViewModel> listConsumers = _logicC.Read(null);
            if (listConsumers != null)
            {
                comboBoxConsumer.DisplayMember = "FIO";
                comboBoxConsumer.ValueMember = "Id";
                comboBoxConsumer.DataSource = listConsumers;
                comboBoxConsumer.SelectedItem = null;
            }
            else
            {
                throw new Exception("Не удалось загрузить список потребителей");
            }
            if (id.HasValue)
            {
                try
                {
                    var view = _logicA.Read(new AddressBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        comboBoxConsumer.SelectedValue = view.ConsumerId;
                        textBoxStreet.Text = view.Street;
                        textBoxHouse.Text = view.House.ToString();
                        textBoxFlat.Text = view.Flat.ToString();
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxStreet.Text))
            {
                MessageBox.Show("Заполните поле Улица", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxHouse.Text))
            {
                MessageBox.Show("Заполните поле Дом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxFlat.Text))
            {
                MessageBox.Show("Заполните поле Квартира", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxConsumer.SelectedValue == null)
            {
                MessageBox.Show("Выберите потребителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logicA.CreateOrUpdate(new AddressBindingModel
                {
                    ConsumerId = Convert.ToInt32(comboBoxConsumer.SelectedValue),
                    Street = textBoxStreet.Text,
                    House = Convert.ToInt32(textBoxHouse.Text),
                    Flat = Convert.ToInt32(textBoxFlat.Text)
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
