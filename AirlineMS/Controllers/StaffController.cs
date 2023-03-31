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

        public IActionResult ListOfStaffsByBranch(string branchId)
        {
           var staffs = _staffservice.GetStaffsByBranchId(branchId);
           return View(staffs.Data);
        }
        public IActionResult ListOfStaffsByCompany(string companyId)
        {
           var staffs= _staffservice.GetStaffsByCompanyId(companyId);
           return View(staffs.Data);
        }

        public IActionResult Details(string id)
        {
            var staff= _staffservice.Get(id);
            return View(staff.Data);
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
        [HttpGet]
        public IActionResult Update(string id)
        {
            var staff = _staffservice.Get(id);
            var updateModel  = new UpdateStaffRequestModel
            {
                FirstName = staff.Data.FirstName,
                LastName = staff.Data.LastName,
                PhoneNumber = staff.Data.PhoneNumber

            };
            return View(updateModel);
        }
        [HttpPost]
        public IActionResult Update(string id,UpdateStaffRequestModel model)
        {
            
            _staffservice.Update(id,model);
            return RedirectToAction("ListOfStaffsByCompany");
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
           var staff = _staffservice.Get(id);
            return View(staff.Data);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult ActualDelete(string id)
        {
            
            return View();
        }


    }
}