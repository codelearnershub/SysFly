using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;
using AirlineMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AirlineMS.Controllers
{
    public class PassengerController  : Controller
    {
        private readonly IPassengerService _passengerservice ;
        public PassengerController ( IPassengerService passengerservice )
        {
            _passengerservice = passengerservice;
        }

          [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePassengerRequestModel model)
        {
            var passenger = _passengerservice.Create(model);
            if(passenger is not null)
            {
                TempData["Exist"] = "Passenger created Successfully";
            }
            return RedirectToAction("Login" ,"User");
        }

         [HttpGet]
        public IActionResult Delete(string id)
        {
           var passenger = _passengerservice.Get(id);
            return View(passenger.Data);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult SoftDelete(string id)
        {
            
            return View();
        }

         public IActionResult Get(string id)
        {
            var passenger= _passengerservice.Get(id);
            return View(passenger.Data);
        }

         public IActionResult GetAll()
        {
            var passenger= _passengerservice.GetAll();
            return View(passenger.Data);
        }

         public IActionResult GetAllPassengerByFlightId(string flightId)
        {
            var response = _passengerservice.GetPassengersByFlightId(flightId);
            return View(response.Data);
        }

         [HttpGet]
        public IActionResult Update(string id)
        {
            var passenger = _passengerservice.Get(id);
            var model  = new UpdatePassengerRequestModel
            {
                FirstName = passenger.Data.FirstName,
                LastName = passenger.Data.LastName,
                PhoneNumber = passenger.Data.PhoneNumber

            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(string id,UpdatePassengerRequestModel model)
        {
            
            _passengerservice.Update(id,model);
            return RedirectToAction("Add","Flight");
        }
    }
}