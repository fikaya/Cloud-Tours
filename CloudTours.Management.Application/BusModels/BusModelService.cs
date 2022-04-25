using CloudTours.Domain;
using CloudTours.Management.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Management.Application.BusModels
{
    public class BusModelService : IBusModelService
    {
        private readonly IBusModelRepository _repository;

        public BusModelService(IBusModelRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<BusModelDTO> GetAll()
        {
            var busModels = _repository.GetAll();
            var busModelDTOs = new List<BusModelDTO>();
            foreach (var busEntity in busModels)
            {
                busModelDTOs.Add(new BusModelDTO()
                {
                    BusModelId = busEntity.BusModelId,
                    BusModelName = busEntity.BusModelName,
                    HasToilet = busEntity.HasToilet,
                    SeatCapacity = busEntity.SeatCapacity,
                    Type = busEntity.Type,
                    BusManuFacturerId = busEntity.BusManuFacturerId
                });
            }
            return busModelDTOs;
        }

        public IEnumerable<BusModelSummary> GetSummaries()
        {
            var busModels = _repository.GetAll("BusManuFacturer", "BusList");
            var busSummary = new List<BusModelSummary>();
            foreach (var busEntity in busModels)
            {
                busSummary.Add(new BusModelSummary()
                {
                    BusModelId = busEntity.BusModelId,
                    BusModelName = busEntity.BusModelName,
                    HasToilet = busEntity.HasToilet,
                    SeatCapacity = busEntity.SeatCapacity,
                    Type = busEntity.Type,
                    BusManuFacturerName = busEntity.BusManuFacturer.Name
                });
            }
            return busSummary;
        }
        public BusModelDTO GetById(int id)
        {
            var busModel = _repository.Find(id);
            var busModelDTO = new BusModelDTO()
            {
                BusModelId = busModel.BusModelId,
                BusModelName = busModel.BusModelName,
                HasToilet = busModel.HasToilet,
                SeatCapacity = busModel.SeatCapacity,
                Type = busModel.Type,
                BusManuFacturerId = busModel.BusManuFacturerId
            };
            return busModelDTO;
        }

        public BusModelSummary GetSummaryById(int id)
        {
            var busModel = _repository.Find(id, "BusManuFacturer");
            var busModelSummary = new BusModelSummary()
            {
                BusModelId = busModel.BusModelId,
                BusModelName = busModel.BusModelName,
                HasToilet = busModel.HasToilet,
                SeatCapacity = busModel.SeatCapacity,
                Type = busModel.Type,
                BusManuFacturerName = busModel.BusManuFacturer.Name
            };
            return busModelSummary;
        }

        public CommandResult Create(BusModelDTO busModelDTO)
        {
           
            try
            {
                if (string.IsNullOrWhiteSpace(busModelDTO.BusModelName))
                {
                    CommandResult.Error("İsim Boş Geçilmez");
                }
                var busModel = new BusModel(busModelDTO.BusModelId, busModelDTO.BusModelName, busModelDTO.Type, busModelDTO.SeatCapacity, busModelDTO.HasToilet, busModelDTO.BusManuFacturerId);
                _repository.Add(busModel);
                return CommandResult.Success("İşlem Başarıyla Gerçekleşti.");
            }
            catch (Exception)
            {
                return CommandResult.Error("Hata Meydana Geldi");
            }

        }

        public CommandResult Delete(BusModelDTO busModelDTO)
        {
            try
            {
                var busModel  = _repository.Find(busModelDTO.BusModelId);
                if (busModel != null)
                {
                    _repository.Remove(busModel);
                    return CommandResult.Success("İşlem Başarıyla Gerçekleşti.");
                }
                else
                {
                    return CommandResult.Error("Böyle Bir Kayıt Bulunamadı.");
                }

            }
            catch (Exception)
            {
                return CommandResult.Error("Hata Meydana Geldi");
            }
        }


        public CommandResult Update(BusModelDTO busModelDTO)
        {
           try
            {
                if (string.IsNullOrWhiteSpace(busModelDTO.BusModelName))
                {
                    CommandResult.Error("İsim Boş Geçilmez");
                }
                var busModel = new BusModel(busModelDTO.BusModelId, busModelDTO.BusModelName, busModelDTO.Type, busModelDTO.SeatCapacity, busModelDTO.HasToilet, busModelDTO.BusManuFacturerId);
                _repository.Update(busModel);
                return CommandResult.Success("İşlem Başarıyla Gerçekleşti.");
            }
            catch (Exception)
            {
                return CommandResult.Error("Hata Meydana Geldi");
            }
        }
    }
}
