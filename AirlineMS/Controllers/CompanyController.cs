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
    public class CompanyController : Controller
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly ICompanyService _companyService;

        public CompanyController(ILogger<CompanyController> logger, ICompanyService companyService)
        {
            _logger = logger;
            _companyService = companyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CreateCompanyRequestModel model)
        {
            var result = _companyService.Create(model);
            if (result.Status)
            {
                return RedirectToAction("List");
            }
            return View(result);
        }

        public IActionResult Delete(string id)
        {
            var result = _companyService.Get(id);
            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult RealDelete(string id)
        {
            var result = _companyService.Delete(id);
            if (result.Status)
            {
                return RedirectToAction("List");
            }
            return View(result);
        }

        public IActionResult Details(string id)
        {
            var result = _companyService.Get(id);
            return View(result.Data);
        }

        public IActionResult List()
        {
            var result = _companyService.GetAll();
            return View(result.Data);
        }

        public IActionResult Update(string id)
        {
            var result = _companyService.Get(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Update(string id, UpdateCompanyRequestModel model)
        {
            var result = _companyService.Update(id, model);
            if (result.Status)
            {
                return RedirectToAction("List");
            }
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}