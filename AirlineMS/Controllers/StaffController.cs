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
    public class StaffController : Controller
    {
        private readonly IStaffService _staffservice;
        public StaffController(IStaffService staffservice)
        {
            _staffservice = staffservice;
        }

        public IActionResult Staffs(string branchId)
        {
           var staffs= _staffservice.GetAllStaffs(branchId);
           return View(staffs);
        }

        public IActionResult Staff(string id)
        {
            var staff= _staffservice.Get(id);
            return View(staff);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CreateStaffRequestModel model)
        {
            var staff = _staffservice.Create(model);
            if(staff is not null)
            {
                TempData["Exist"] = "Staff created Successfully";
            }
            return RedirectToAction("Login" ,"User");
        }

        public IActionResult Update(string id,UpdateStaffRequestModel model)
        {
                _staffservice.Update(id,model);
                return RedirectToAction("Staffs");
        }
        public IActionResult Index()
        {
            return View();
        }


    }
}