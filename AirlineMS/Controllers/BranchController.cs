using AirlineMS.Models.Dtos;
using AirlineMS.Services.Interfaces;
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
        public IActionResult Create(string agencyId, CreateBranchRequestModel model)
        {
            var response = _branchService.Create(agencyId, model);
            if (response.Status)
            {
                TempData["Successful"] = " Created Successful";

                return RedirectToAction("List");
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateHead()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateHead(string id, CreateHeadRequestModel model)
        {
            var response = _branchService.CreateHeadquarters(id, model);
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
            // var response = _branchService.Get(id);
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult RealDelete(string agencyId, CreateBranchRequestModel model)
        {
            var response = _branchService.Create(agencyId, model);
            if (response.Status)
            {
                TempData["Successful"] = " Created Successful";

                return RedirectToAction("List");
            }
            return View();
        }

        [HttpGet]
        public IActionResult List(string id)
        {
            var response = _branchService.GetBranchesByCompanyId(id);
            return View(response.Data);
        }

        [HttpGet]
        public IActionResult Update(string id)
        {
            // var response = _branchService.Get(id);
            return View();
        }

        [HttpPost]
        public IActionResult Update(string id, UpDateBranchRequestModel model)
        {
            var response = _branchService.Update(id, model);
            if (response.Status)
            {
                TempData["Successful"] = " Updated Successful";

                return RedirectToAction("List");
            }
            return View();
        }
    }
}