using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AirlineMS.Controllers
{

    public class BranchManagerController : Controller
    {
        private readonly ILogger<BranchManagerController> _logger;
        private readonly IBranchManagerService _branchManagerService;

        public BranchManagerController(ILogger<BranchManagerController> logger, IBranchManagerService branchManagerService)
        {
            _logger = logger;
            _branchManagerService = branchManagerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}