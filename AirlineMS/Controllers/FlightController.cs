using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;
using AirlineMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirlineMS.Controllers
{
    public class FlightController : Controller
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService FlightService)
        {
            _flightService = FlightService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CreateFlightRequestModel model)
        {
            var response = _flightService.Create(model);
            if (response.Status)
            {
                TempData["Successful"] = " Created Successful";

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
        public IActionResult RealDelete(string id)
        {
          return View();
        }

        [HttpGet]
        public IActionResult List()
        {
            var response = _flightService.GetAll();
            return View(response.Data);
        }

        [HttpGet]
        public IActionResult Update(string id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(string id, UpdateFlightRequestModel model)
        {
            var response = _flightService.Update(id, model);
            if (response.Status)
            {
                TempData["Successful"] = " Updated Successful";

                return RedirectToAction("List");
            }
            return View();
        }

    }
}