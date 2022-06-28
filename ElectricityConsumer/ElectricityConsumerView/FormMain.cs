using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.BusinessLogicsContracts;
using System;
using System.Windows.Forms;
using Unity;

namespace ElectricityConsumerView
{
    public partial class FormMain : Form
    {
        private readonly ICounterReadingsLogic _counterLogic;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void потребителиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormConsumers>();
            form.ShowDialog();
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
    }
}
