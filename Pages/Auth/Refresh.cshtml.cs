using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Blackbaud.SkyApiExample.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blackbaud.SkyApiExample.Auth
{
    public class RefreshModel : PageModel
    {
        private readonly IAuthenticationService _authService;

        public RefreshModel(IAuthenticationService authService)
        {
            _authService = authService;
        }

        public IActionResult OnGet()
        {
            HttpResponseMessage response = _authService.RefreshAccessToken();
            string jsonString = response.Content.ReadAsStringAsync().Result;
            return Redirect("/");
        }
    }
}
