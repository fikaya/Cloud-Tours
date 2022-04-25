using CloudTours.Management.Application.BusManuFactures;
using CloudTours.Management.Application.BusModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CloudTours.Management.Presentation.Controllers
{
    public class BusModelController : Controller
    {
        private readonly IBusModelService _busService;
        private readonly IBusManuFactureService _busManuService;

        public BusModelController(IBusModelService busService, IBusManuFactureService busManuService)
        {
            _busService = busService;
            _busManuService = busManuService;
        }
 
        public IActionResult Index()
        {
            
            var busModelList = _busService.GetSummaries();
            ViewBag.BusModelList = busModelList.Count();
            return View(busModelList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var busManuList = _busManuService.GetAll();

            IEnumerable<int> comboboxCount = new List<int>() { 44, 48, 52, 26, 28, 30 };

            ViewBag.comboboxCount = new SelectList(comboboxCount);

            ViewBag.busManuList = new SelectList(busManuList, "BusManuFacturerId", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(BusModelDTO busModelDTO)
        {
            var result = _busService.Create(busModelDTO);
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

        public IActionResult Delete(int id)
        {
            var busModel = _busService.GetById(id);
            if (busModel != null)
            {
                return View(busModel);
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public IActionResult Delete(BusModelDTO busModelDTO)
        {
  
            var result = _busService.Delete(busModelDTO);
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
            var busModel = _busService.GetById(id);
            if (busModel != null)
            {
                return View(busModel);
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public IActionResult Update(BusModelDTO busModelDTO)
        {
            var result = _busService.Update(busModelDTO);
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


