using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;
using AirlineMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirlineMS.Controllers
{
    public class AircraftController : Controller
    {
         private readonly IAircraftService _aircraftService;

        public AircraftController(IAircraftService aircraftService)
        {
            _aircraftService = aircraftService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string companyId, CreateAircraftRequestModel model)
        {
            var response = _aircraftService.Create(companyId, model);
            if (response.Status)
            {
                TempData["Successful"] = "Created Successful";

                return RedirectToAction("List");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Delete(string id)
        {
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult RealDelete(string companyId, CreateAircraftRequestModel model)
        {
            var response = _aircraftService.Delete(companyId, model);
            if (response.Status)
            {
                TempData["Successful"] = " Deleted Successful";

                return RedirectToAction("List");
            }
            return View();
        }

        [HttpGet]
        public IActionResult List(string id)
        {
            var response = _aircraftService.GetAircraftsByCompanyId(id);
            return View(response.Data);
        }

        public IActionResult Details(string id)
        {
            var response = _aircraftService.GetAircraftByCompanyId(id);
            return View(response.Data);
        }
       
        [HttpGet]
        public IActionResult Update(string id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(string id, UpdateAircraftRequestModel model)
        {
            var response = _aircraftService.Update(id, model);
            if (response.Status)
            {
                TempData["Successful"] = " Updated Successful";

                return RedirectToAction("List");
            }
            return View();
        }
    }
}