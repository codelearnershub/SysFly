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
            _roleService.Create(model);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Delete (string id)
        {
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult ActualDelete (string id)
        {
            _roleService.Delete(id);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var role = _roleService.Get(id);

            return View(role.Data);
        }
        [HttpGet]
        public IActionResult List()
        {
             var roles = _roleService.GetAll();
            return View(roles.Data);
        }
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(UpdateRoleRequestModel roleModel)
        {
            return View();
        }
    }
}