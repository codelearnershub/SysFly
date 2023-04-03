using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;
using AirlineMS.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace AirlineMS.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserRequestModel model)
        {
            var user = _userService.Login(model);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Data.Email),
                    new Claim(ClaimTypes.Name, user.Data.FirstName +" "+ user.Data.LastName),
                    new Claim(ClaimTypes.HomePhone, user.Data.PhoneNumber)
                };

                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var claimsPrincipal = new ClaimsPrincipal(claimIdentity);

                HttpContext.SignInAsync(claimsPrincipal);
                if(user.Status == true)
                {
                    if(user.Data.Roles.Select(r => r.Name).Contains("super admin"))
                    {
                        return RedirectToAction("Super");
                    }
                }

                
            }
            return View();


        }

        public IActionResult List()
        {
            var users = _userService.GetAll();
            return View(users.Data);
        }

        public IActionResult Super()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }


        
        /* [ChildActionOnly]
        public ActionResult GetHtmlPage(string path)
        {
            return new FilePathResult(path, "text/html");
            
        } */

    }
}