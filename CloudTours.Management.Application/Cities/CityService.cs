using CloudTours.Domain;
using CloudTours.Management.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Management.Application.Cities
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public IEnumerable<CityDTO> GetAll()
        {
            var cityEntities = _cityRepository.GetAll();//Try-Catch

            var cityDTOs = new List<CityDTO>();
            foreach (var entity in cityEntities)
            {
                cityDTOs.Add(new CityDTO
                {
                    CityId = entity.CityId,
                    CityName = entity.CityName
                });
            }
            return cityDTOs;
        }
        public CityDTO GetById(int id)
        {
            var cityEntity = _cityRepository.Find(id);

            if (cityEntity != null)
            {
                var cityDTO = new CityDTO()
                {
                    CityId = cityEntity.CityId,
                    CityName = cityEntity.CityName
                };
                return cityDTO;
            }
            else
            {
                return null;
            }

        }
        public CommandResult Create(CityDTO cityDTO)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cityDTO.CityName))
                {
                    return CommandResult.Error("İsim Boş Geçilmez");
                }

                var city = new City()
                {
                    CityName = cityDTO.CityName
                };

                _cityRepository.Add(city);

                return CommandResult.Success("İşlem Başarıyla Gerçekleşti.");
            }
            catch (Exception)
            {
                return CommandResult.Error("Hata Meydana Geldi");
            }
        }
        public CommandResult Delete(CityDTO cityDTO)
        {
            var city = _cityRepository.Find(cityDTO.CityId);
            if (city != null)
            {
                _cityRepository.Remove(city);
                return CommandResult.Success("İşlem Başarıyla Gerçekleşti.");
            }
            else
            {
                return CommandResult.Error("Böyle Bir Kayıt Bulunamadı.");
            }
        }
        public CommandResult Update(CityDTO cityDTO)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cityDTO.CityName))
                {
                    return CommandResult.Error("İsim Boş Geçilmez");
                }

                var city = new City()
                {
                    CityId = cityDTO.CityId,
                    CityName=cityDTO.CityName
                };

                _cityRepository.Update(city);
                
                return CommandResult.Success("İşlem Başarıyla Gerçekleşti.");
            }
            catch (Exception)
            {
                return CommandResult.Error("Hata Meydana Geldi.");
            }
        }

    }
}
