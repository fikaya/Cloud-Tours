
using CloudTours.Domain;
using CloudTours.Management.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Management.Application.Buses
{
    public class BusService : IBusService
    {
        private readonly IBusRepository _repository;

        public BusService(IBusRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<BusDTO> GetAll()
        {
            var busList = _repository.GetAll();

            var busDTOs = new List<BusDTO>();

            foreach (var bus in busList)
            {

                busDTOs.Add(
                new BusDTO()
                {
                    BusId = bus.BusId,
                    BusModelId = bus.BusModelId,
                    DistanceTraveled = bus.DistanceTraveled,
                    RegistrationPlate = bus.RegistrationPlate,
                    SeatMapping = bus.SeatMapping,
                    Year = bus.Year
                }
                );

            }
            return busDTOs;
        }
        public IEnumerable<BusSummary> GetSummaries()
        {
            var busList = _repository.GetAll("BusModel");
            var busSummaries = new List<BusSummary>();

            foreach (var bus in busList)
            {
                busSummaries.Add(new BusSummary()
                {
                    BusId = bus.BusId,
                    BusModelName = bus.BusModel.BusModelName,
                    BusModelType=bus.BusModel.Type,
                    SeatCapacity=bus.BusModel.SeatCapacity,
                    DistanceTraveled = bus.DistanceTraveled,
                    RegistrationPlate = bus.RegistrationPlate,
                    SeatCount = bus.SeatCount,
                    SeatMapping = bus.SeatMapping,
                    Year = bus.Year
                });
            }

            return busSummaries;

        }

        public BusDTO GetById(int id)
        {
            var bus = _repository.Find(id);
            return new BusDTO()
            {
                BusId = bus.BusId,
                BusModelId = bus.BusModelId,
                DistanceTraveled = bus.DistanceTraveled,
                RegistrationPlate = bus.RegistrationPlate,
                SeatMapping = bus.SeatMapping,
                Year = bus.Year
            };
        }

        public CommandResult Create(BusDTO busDto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(busDto.RegistrationPlate))
                {
                    CommandResult.Error("Plaka Boş Geçilmez");
                }
                var bus = new Bus(busDto.BusId, busDto.BusModelId, busDto.RegistrationPlate, busDto.Year, busDto.SeatMapping, busDto.DistanceTraveled);
                _repository.Add(bus);
                return CommandResult.Success("İşlem Başarıyla Gerçekleşti.");
            }
            catch (Exception)
            {
                return CommandResult.Error("Hata Meydana Geldi");
            }
        }

        public CommandResult Delete(BusDTO busDto)
        {
             try
            {
                var bus = new Bus(busDto.BusId, busDto.BusModelId, busDto.RegistrationPlate, busDto.Year, busDto.SeatMapping, busDto.DistanceTraveled);
                if (bus != null)
                {
                    //var busManuFacturer = new BusManuFacturer(busManuFacturer2.BusManuFacturerId, busManuFacturer2.Name);

                    _repository.Remove(bus);
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

        public CommandResult Update(BusDTO busDto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(busDto.RegistrationPlate))
                {
                    CommandResult.Error("Plaka Boş Geçilmez");
                }
                var bus = new Bus(busDto.BusId, busDto.BusModelId, busDto.RegistrationPlate, busDto.Year, busDto.SeatMapping, busDto.DistanceTraveled);
                _repository.Update(bus);
                return CommandResult.Success("İşlem Başarıyla Gerçekleşti.");
            }
            catch (Exception)
            {
                return CommandResult.Error("Hata Meydana Geldi");
            }
        }

        public BusSummary GetSummaryById(int id)
        {
            throw new NotImplementedException();
        }

     
    }
}
