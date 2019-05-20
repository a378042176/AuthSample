using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcCookiesAuthSample.Controllers
{

    public class AccountController : Controller
    {
        // GET: /<controller>/
        public IActionResult MakeLogin()
        {
            var claims = new List<Claim>() {
                new Claim(ClaimTypes.Name,"jgp"),
                new Claim(ClaimTypes.Role,"admin")
            };
            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimIdentity));
            return Ok();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
    }
}
