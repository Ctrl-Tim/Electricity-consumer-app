using System;
using System.Collections.Generic;
using ElectricityConsumerContracts.BusinessLogicsContracts;
using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.StoragesContracts;
using ElectricityConsumerContracts.ViewModels;

namespace ElectricityConsumerBusinessLogic.BusinessLogics
{
    public class ConsumerLogic : IConsumerLogic
    {
		private readonly IConsumerStorage _consumerStorage;

        public ConsumerLogic(IConsumerStorage consumerStorage)
        {
            _consumerStorage = consumerStorage;
        }

        public List<ConsumerViewModel> Read(ConsumerBindingModel model)
        {
            if (model == null)
            {
                return _consumerStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ConsumerViewModel> { _consumerStorage.GetElement(model) };
            }

            return _consumerStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(ConsumerBindingModel model)
        {
            var element = _consumerStorage.GetElement(new ConsumerBindingModel
            {
                SurName = model.SurName,
                FirstName = model.FirstName,
                Patronymic = model.Patronymic
            });

            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть потребитель с таким ФИО");
            }
            if (model.Id.HasValue)
            {
                _consumerStorage.Update(model);
            }
            else
            {
                _consumerStorage.Insert(model);
            }
        }

        public void Delete(ConsumerBindingModel model)
        {
            var element = _consumerStorage.GetElement(new ConsumerBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Потребитель не найден!");
            }
            _consumerStorage.Delete(model);
        }
    }
}
