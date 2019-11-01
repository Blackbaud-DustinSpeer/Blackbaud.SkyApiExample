using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blackbaud.SkyApiExample.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blackbaud.SkyApiExample.Auth
{
    public class LogoutModel : PageModel
    {
        private readonly IAuthenticationService _authService;

        public LogoutModel(IAuthenticationService authService)
        {
            _authService = authService;
        }

        public IActionResult OnGet()
        {
            _authService.LogOut();
            return Redirect("/");
        }
    }
}
