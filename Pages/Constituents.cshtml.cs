using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Blackbaud.SkyApiExample.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blackbaud.SkyApiExample.Constituents
{
    public class ConstituentsModel : PageModel
    {
        private readonly IConstituentsService _constituentsService;

        public ConstituentsModel(IConstituentsService constituentsService)
        {
            _constituentsService = constituentsService;
        }
        public IActionResult OnGet()
        {
            var response = _constituentsService.GetConstituents();

            string responseString = response.Content.ReadAsStringAsync().Result;
            var constituents = JsonSerializer.Deserialize<dynamic>(responseString);

            if ((int)response.StatusCode == 401)
            {
                return RedirectToPage("Auth/Login");
            }

            return RedirectToPage();
        }
    }
}
