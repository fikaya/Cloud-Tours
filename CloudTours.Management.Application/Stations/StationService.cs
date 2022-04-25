using CloudTours.Domain;
using CloudTours.Management.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Management.Application.Stations
{
    public class StationService : IStationService
    {
        private readonly IStationRepository _stationRepository;

        public StationService(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public IEnumerable<StationDTO> GetAll()
        {
            var stations = _stationRepository.GetAll();
            var stationsDTOs=new List<StationDTO>();
            foreach (var entity in stations)
            {
                stationsDTOs.Add(new StationDTO()
                {
                    CityId = entity.CityId,
                    StationId = entity.StationId,
                    StationName=entity.StationName      
                });                
            }
            return stationsDTOs;
        }
        public IEnumerable<StationSummary> GetSummaries()
        {
            var station = _stationRepository.GetAll("City");

            var stationSummary = new List<StationSummary>();

            foreach (var item in station)
            {
                stationSummary.Add(new StationSummary()
                {
                    StationId = item.StationId,
                    StationName = item.StationName,
                    CityName = item.City.CityName
                });
            }

            return stationSummary;
        }
        public StationDTO GetById(int id)
        {
            var entity = _stationRepository.Find(id);
            if (entity!=null)
            {
                var stationDTO = new StationDTO()
                {
                    CityId = entity.CityId,
                    StationId = entity.StationId,
                    StationName = entity.StationName
                };
                return stationDTO;
            }
            else
            {
                return null;
            }
        }
        public CommandResult Create(StationDTO stationDTO)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(stationDTO.StationName))
                {
                    return CommandResult.Error("İsim Boş Geçilmez");
                }

                var station = new Station()
                {
                    StationName = stationDTO.StationName,
                    StationId = stationDTO.StationId,
                    CityId=stationDTO.CityId
                };
                _stationRepository.Add(station);
                return CommandResult.Success("İşlem Başarıyla Gerçekleşti.");
            }
            catch (Exception)
            {
                return CommandResult.Error("Hata Meydana Geldi");
            }
        }
        public CommandResult Delete(StationDTO stationDTO)
        {
            var station = _stationRepository.Find(stationDTO.StationId);
            if (station != null)
            {
                _stationRepository.Remove(station);
                return CommandResult.Success("İşlem Başarıyla Gerçekleşti.");
            }
            else
            {
                return CommandResult.Error("Böyle Bir Kayıt Bulunamadı.");
            }
        }

        public CommandResult Update(StationDTO stationDTO)
        {
            try
            {
                var station = new Station()
                {
                    StationName = stationDTO.StationName,
                    CityId = stationDTO.CityId,
                    StationId = stationDTO.StationId
                };
                _stationRepository.Update(station);
                return CommandResult.Success("İşlem Başarıyla Gerçekleşti.");
            }
            catch (Exception)
            {
                return CommandResult.Error("Hata Meydana Geldi");

            }
        }

        public StationSummary GetSummaryById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
