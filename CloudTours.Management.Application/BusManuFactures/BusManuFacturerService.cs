using CloudTours.Domain;
using CloudTours.Management.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Management.Application.BusManuFactures
{
    public class BusManuFacturerService : IBusManuFactureService
    {
        private readonly IBusManuFacturerRepository _repository;

        public BusManuFacturerService(IBusManuFacturerRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<BusManuFacturerDTO> GetAll()
        {
            var busManuFacturers = _repository.GetAll();
            var busManuFacturesDTO = new List<BusManuFacturerDTO>();
            foreach (var busManuFacturer in busManuFacturers)
            {
                busManuFacturesDTO.Add(new BusManuFacturerDTO()
                {
                    BusManuFacturerId = busManuFacturer.BusManuFacturerId,
                    Name = busManuFacturer.Name
                });
            }
            return busManuFacturesDTO;
        }
        public BusManuFacturerDTO GetById(int id)
        {
            var bus = _repository.Find(id);
            var busManuFacturesDTO = new BusManuFacturerDTO()
            {
                BusManuFacturerId = bus.BusManuFacturerId,
                Name = bus.Name
            };
            return busManuFacturesDTO;

        }
        public CommandResult Create(BusManuFacturerDTO busManuFacturerDTO)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(busManuFacturerDTO.Name))
                {
                    return CommandResult.Error("İsim Alanı Boş Geçilemez");
                }

                var busManuFacturer = new BusManuFacturer(busManuFacturerDTO.BusManuFacturerId, busManuFacturerDTO.Name);
                _repository.Add(busManuFacturer);
                return CommandResult.Success("İşlem Başarıyla Gerçekleşti.");
            }
            catch (Exception)
            {
                return CommandResult .Error("Hata Meydana Geldi");
            }
        }
        public CommandResult Update(BusManuFacturerDTO busManuFacturerDTO)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(busManuFacturerDTO.Name))
                {
                    return CommandResult.Error("İsim Alanı Boş Geçilemez");
                }

                var busManuFacturer = new BusManuFacturer(busManuFacturerDTO.BusManuFacturerId, busManuFacturerDTO.Name); 
                _repository.Update(busManuFacturer);
                return CommandResult.Success("İşlem Başarıyla Gerçekleşti.");
            }
            catch (Exception)
            {
               return CommandResult.Error("Hata Meydana Geldi");
            }
        }
        public CommandResult Delete(BusManuFacturerDTO busManuFacturerDTO)
        {
            try
            {
                var busManuFacturer= _repository.Find(busManuFacturerDTO.BusManuFacturerId);
                if (busManuFacturer != null)
                {
                    //var busManuFacturer = new BusManuFacturer(busManuFacturer2.BusManuFacturerId, busManuFacturer2.Name);
                  
                    _repository.Remove(busManuFacturer);
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


    }
}

