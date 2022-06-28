using ElectricityConsumerBusinessLogic.BusinessLogics;
using ElectricityConsumerContracts.BusinessLogicsContracts;
using ElectricityConsumerContracts.StoragesContracts;
using ElectricityConsumerDatabaseImplement.Implements;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace ElectricityConsumerView
{
    static class Program
    {
        private static IUnityContainer container = null;

        public static IUnityContainer Container { get { if (container == null) { container = BuildUnityContainer(); } return container; } }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.Resolve<FormMain>());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();

            currentContainer.RegisterType<IConsumerStorage, ConsumerStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IAddressStorage, AddressStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ITypeElectricMeterStorage, TypeElectricMeterStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IElectricMeterStorage, ElectricMeterStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICounterReadingsStorage, CounterReadingsStorage>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<IConsumerLogic, ConsumerLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IAddressLogic, AddressLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ITypeElectricMeterLogic, TypeElectricMeterLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IElectricMeterLogic, ElectricMeterLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICounterReadingsLogic, CounterReadingsLogic>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
