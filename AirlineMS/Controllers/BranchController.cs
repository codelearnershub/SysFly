using System.Security.Claims;
using AirlineMS.Models.Dtos;
using AirlineMS.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace AirlineMS.Controllers
{
    public class BranchController : Controller
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(CreateBranchRequestModel model)
        {
            var branch = _branchService.Create(model);
            if (branch is not null)
            {
                TempData["Successful"] = " Craedted Successful";

                return RedirectToAction("Login","User");
            }
            return View();
        }
    }
}