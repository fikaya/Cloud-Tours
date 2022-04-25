using CloudTours.Management.Application.BusManuFactures;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CloudTours.Management.Presentation.Controllers
{
    public class BusManuFacturerController : Controller
    {
        private readonly IBusManuFactureService _busService;

        public BusManuFacturerController(IBusManuFactureService service)
        {
            _busService = service;
        }

        public IActionResult Index()
        {
            var busManuFacturerList=_busService.GetAll();
            ViewBag.BusManuFacturers = busManuFacturerList.Count();
            return View(busManuFacturerList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BusManuFacturerDTO busManuFacturerDTO)
        {
           
            var result = _busService.Create(busManuFacturerDTO);
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
           var busManuFacturer=_busService.GetById(id);
            return View(busManuFacturer);
        }
        [HttpPost]
        public IActionResult Delete(BusManuFacturerDTO busManuFacturerDTO)
        {
           
            var result = _busService.Delete(busManuFacturerDTO);
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
            var bus=_busService.GetById(id);
            return View(bus);
        }
        [HttpPost]
        public IActionResult Update(BusManuFacturerDTO busManuFacturerDTO)
        {
           
            var result = _busService.Update(busManuFacturerDTO);
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


  