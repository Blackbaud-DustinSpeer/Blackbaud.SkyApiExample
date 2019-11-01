using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blackbaud.SkyApiExample.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blackbaud.SkyApiExample.Auth
{
    public class LoginModel : PageModel
    {
        private readonly IAuthenticationService _authService;

        public LoginModel(IAuthenticationService authService)
        {
            _authService = authService;
        }

        public IActionResult OnGet()
        {
            Uri address = _authService.GetAuthorizationUri();
            return Redirect(address.ToString());
        }
    }
}
