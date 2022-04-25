using CloudTours.Domain;
using CloudTours.Management.Application.Buses;
using CloudTours.Management.Application.BusModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudTours.Management.Presentation.Controllers
{
    public class BusController : Controller
    {
        private readonly IBusService _busService;
        private readonly IBusModelService _busModelService;

        public BusController(IBusService busService,IBusModelService busModelService)
        {
            _busService = busService;
            _busModelService = busModelService;
        }

        public IActionResult Index()
        {
            //public Bus(int busId, int busModelId, string registrationPlate, short year, SeatingType seatMapping, int distanceTraveled)
            var busList = _busService.GetSummaries();
            ViewBag.busList = busList.Count();
            return View(busList);  
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var busDTO = _busService.GetById(id);
            return View(busDTO);
        }
        [HttpPost]
        public IActionResult Delete(BusDTO busDTO)
        {
 
            var result = _busService.Delete(busDTO);
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

        [HttpGet]
        public IActionResult Create()
        {
           
            var busModelList = _busModelService.GetSummaries();

            ViewBag.Buses = new SelectList(busModelList, "BusModelId", "BusModelName");

            return View();

          
        }

        [HttpPost]
        public IActionResult Create(BusDTO busDTO)
        {
           
            var result = _busService.Create(busDTO);
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

        [HttpGet]
        public IActionResult Update(int id)
        {
            var busDTO = _busService.GetById(id);
            return View(busDTO);
        }

        [HttpPost]
        public IActionResult Update(BusDTO busDTO)
        {
            var result = _busService.Update(busDTO);
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


 