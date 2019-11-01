using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blackbaud.SkyApiExample.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blackbaud.SkyApiExample.Auth
{
    public class CallbackModel : PageModel
    {
        private readonly IAuthenticationService _authService;

        public CallbackModel(IAuthenticationService authService)
        {
            _authService = authService;
        }

        public IActionResult OnGet()
        {
            string code = Request.Query["code"];
            _authService.ExchangeCodeForAccessToken(code);
            return Redirect("/");
        }
    }
}
