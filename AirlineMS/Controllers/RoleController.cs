using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;
using AirlineMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirlineMS.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(CreateRoleRequestModel model)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Delete ()
        {
            return View();
        }
        [HttpPost]

        public IActionResult ActualDelete ()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Details(StaffDto staffModel)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(UpdateStaffRequestModel staffModel)
        {
            return View();
        }
    }
}