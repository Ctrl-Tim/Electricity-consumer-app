using System;
using System.Collections.Generic;
using ElectricityConsumerContracts.BusinessLogicsContracts;
using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.StoragesContracts;
using ElectricityConsumerContracts.ViewModels;

namespace ElectricityConsumerBusinessLogic.BusinessLogics
{
    public class ElectricMeterLogic : IElectricMeterLogic
    {
        private readonly IElectricMeterStorage _electricmeterStorage;

        public ElectricMeterLogic(IElectricMeterStorage electricmeterStorage)
        {
            _electricmeterStorage = electricmeterStorage;
        }

        public List<ElectricMeterViewModel> Read(ElectricMeterBindingModel model)
        {
            if (model == null)
            {
                return _electricmeterStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ElectricMeterViewModel> { _electricmeterStorage.GetElement(model) };
            }

            return _electricmeterStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(ElectricMeterBindingModel model)
        {
            var element = _electricmeterStorage.GetElement(new ElectricMeterBindingModel
            {
                Number = model.Number
            });

            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть электросчётчик с таким номером");
            }
            if (model.Id.HasValue && element != null)
            {
                _electricmeterStorage.Update(model);
            }
            else
            {
                _electricmeterStorage.Insert(model);
            }
        }

        public void Delete(ElectricMeterBindingModel model)
        {
            var element = _electricmeterStorage.GetElement(new ElectricMeterBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Счётчик не найден!");
            }
            _electricmeterStorage.Delete(model);
        }

        public void CheckInspection(ElectricMeterBindingModel model)
        {
            var em = _electricmeterStorage.GetElement(new ElectricMeterBindingModel { Id = model.Id });

            if (em == null)
            {
                throw new Exception("Не найден счётчик");
            }
            if (DateTime.Today.AddDays(7) < Convert.ToDateTime(em.FinalInspection).AddYears(em.InspectionPeriod)) //за неделю до крайнего срока
            {
                throw new Exception("Время госпроверки ещё не пришло");
            }

            _electricmeterStorage.Update(new ElectricMeterBindingModel
            {
                Id = em.Id,
                TypeId = em.TypeId,
                Number = Math.Round(em.Number),
                DateOfCheck = em.DateOfCheck,
                InspectionPeriod = em.InspectionPeriod,
                FinalInspection = DateTime.Now
            });
        }

        public void CreateReading(ElectricMeterBindingModel model)
        {
            var em = _electricmeterStorage.GetElement(new ElectricMeterBindingModel { Id = model.Id });
            if (em == null)
            {
                throw new Exception("Не найден счётчик");
            }
            if (DateTime.Today < Convert.ToDateTime(em.DateOfCheck))
            {
                throw new Exception("Время снятия показаний ещё не пришло");
            }

            _electricmeterStorage.Update(new ElectricMeterBindingModel
            {
                Id = em.Id,
                TypeId = em.TypeId,
                Number = Math.Round(em.Number),
                DateOfCheck = em.DateOfCheck.Value.AddMonths(1),
                InspectionPeriod = em.InspectionPeriod,
                FinalInspection = em.FinalInspection
            });
        }
    }
}
