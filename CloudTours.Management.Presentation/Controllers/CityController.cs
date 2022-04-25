using CloudTours.Management.Application.Cities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CloudTours.Management.Presentation.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        public IActionResult Index()
        {
            var cities = _cityService.GetAll();

            ViewBag.cityList = cities.Count();

            //ViewBag.success = TempData["success"];
            //Ümitin attığı resmi dene

            return View(cities);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CityDTO cityDTO)
        {
            var result = _cityService.Create(cityDTO);

            if (result.IsSucceeded)
            {
                //İşlem Başarılı Bir Şekilde Gerçekleşti

                TempData["success"] = "Başarılı Bir Şekilde İşlem Gerçekleşti";

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
            var city = _cityService.GetById(id);
            return View(city);
        }

        [HttpPost]
        public IActionResult Delete(CityDTO cityDTO)
        {
            var result = _cityService.Delete(cityDTO);
            if (result.IsSucceeded)
            {
                TempData["success"] = "Başarılı Bir Şekilde İşlem Gerçekleşti";

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.CommandResult = result;
                return View();
            }
        }

        public IActionResult Update(int id)
        {
            var city = _cityService.GetById(id);
            return View(city);
        }

        [HttpPost]
        public IActionResult Update(CityDTO cityDTO)
        {
            var result = _cityService.Update(cityDTO);
            if (result.IsSucceeded)
            {
                TempData["success"] = "Başarılı Bir Şekilde İşlem Gerçekleşti";

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.CommandResult = result;
                return View();
            }
        }
    }
}
