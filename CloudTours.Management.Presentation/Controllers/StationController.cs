using CloudTours.Management.Application.Cities;
using CloudTours.Management.Application.Stations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Linq;

namespace CloudTours.Management.Presentation.Controllers
{
    public class StationController : Controller
    {
        private readonly IStationService _stationService;
        private readonly ICityService _cityService;

        public StationController(IStationService stationService, ICityService cityService)
        {
            _stationService = stationService;
            _cityService = cityService;
        }

        public IActionResult Index()
        {
            var stations = _stationService.GetSummaries();
            ViewBag.StationsList = stations.Count();
            return View(stations);
         }

        [HttpGet]
        public IActionResult Create()
        {
            var cityList = _cityService.GetAll();
            ViewBag.Cities = new SelectList(cityList, "CityId", "CityName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(StationDTO stationDTO)
        {
           var result= _stationService.Create(stationDTO);
           
            if (result.IsSucceeded)
            {
                //TempData["success"] = "Başarılı Bir Şekilde İşlem Gerçekleşti";

                // JSON
                // JavaScript Object Notation

                // Serialize => Stringleştirme
                var resultJson = JsonConvert.SerializeObject(result);
                TempData["CommandResult"] = resultJson;


                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.CommandResult = result;
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            var city = _stationService.GetById(id);
            return View(city);
        }

        [HttpPost]
        public IActionResult Delete(StationDTO stationDTO)
        {
            var result=_stationService.Delete(stationDTO);
            if (result.IsSucceeded)
            {
                TempData["success"] = "Başarılı Bir Şekilde İşlem Gerçekleşti";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ComamndResult = result;
                return View();
            }
         }

        public IActionResult Update(int id)
        {
            var station = _stationService.GetById(id);
            var cityList = _cityService.GetAll();
            ViewBag.City = new SelectList(cityList, "CityId", "CityName", station.CityId);
            return View(station);
        }

        [HttpPost]
        public IActionResult Update(StationDTO stationDTO)
        {
            var result=_stationService.Update(stationDTO);
            if (result.IsSucceeded)
            {
                TempData["success"] = "Başarılı Bir Şekilde İşlem Gerçekleşti";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ComamndResult = result;
                return View();
            }
        }

    }
}
