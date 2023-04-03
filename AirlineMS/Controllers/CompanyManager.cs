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
    public class CompanyManagerController : Controller
    {
        private readonly ICompanyManagerService _companyManagerService;
        public CompanyManagerController(ICompanyManagerService companyManagerService)
        {
            _companyManagerService = companyManagerService;
        }

        public IActionResult ListOfCompaniesManagerByCompany(string CompanyId)
        {
           var response = _companyManagerService.GetCompanyManagerByCompanyId(CompanyId);
           return View(response.Data);
        }

        public IActionResult Details(string id)
        {
            var response= _companyManagerService.Get(id);
            return View(response.Data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string id, CreateCompanyManagerRequestModel model)
        {
            var companyManager = _companyManagerService.Create(id, model);
            if(companyManager is not null)
            {
                TempData["Exist"] = "CompanyManager created Successfully";
            }
            return RedirectToAction("Login" ,"User");
        }
        [HttpGet]
        public IActionResult Update(string id)
        {
            var companyManager = _companyManagerService.Get(id);
            var updateModel  = new UpdateCompanyManagerRequestModel
            {
                FirstName = companyManager.Data.FirstName,
                LastName = companyManager.Data.LastName,
                PhoneNumber = companyManager.Data.PhoneNumber

            };
            return View(updateModel);
        }
        [HttpPost]
        public IActionResult Update(string id,UpdateCompanyManagerRequestModel model)
        {
            
            _companyManagerService.Update(id,model);
            return RedirectToAction("ListOfCompanyManagersByCompany");
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
           var companyManager = _companyManagerService.Get(id);
            return View(companyManager.Data);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult ActualDelete(string id)
        {
            
            return View();
        }


    }
}