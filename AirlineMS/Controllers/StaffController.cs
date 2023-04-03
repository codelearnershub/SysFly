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
        private readonly IStaffService _staffService;
        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet, ActionName("List")]
        public IActionResult ListOfStaffsByBranch(string branchId)
        {
           var staffs = _staffService.GetStaffsByBranchId(branchId);
           return View(staffs.Data);
        }
        public IActionResult ListOfStaffsByCompany(string companyId)
        {
           var staffs= _staffService.GetStaffsByCompanyId(companyId);
           return View(staffs.Data);
        }

        public IActionResult Details(string id)
        {
            var staff= _staffService.Get(id);
            return View(staff.Data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string branchId, CreateStaffRequestModel model)
        {
            var staff = _staffService.Create(branchId, model);
            if(staff is not null)
            {
                TempData["Exist"] = "Staff created Successfully";
                return RedirectToAction("List");
            }
            return View(); 
        }
        [HttpGet]
        public IActionResult Update(string id)
        {
            var staff = _staffService.Get(id);
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
            
            _staffService.Update(id,model);
            return RedirectToAction("ListOfStaffsByCompany");
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
           var staff = _staffService.Get(id);
            return View(staff.Data);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult ActualDelete(string id)
        {
            
            return View();
        }


    }
}