﻿using Microsoft.AspNetCore.Mvc;
using UserThemeChange.Models;

namespace UserThemeChange.Controllers
{
    public class UserPreferencesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetThemes()
        {
            var themes = new List<Theme>()
            {
                new Theme() { ThemeId = "default-v2", Name = "Default-v2" },
                new Theme() { ThemeId = "bootstrap-v4", Name = "Bootstrap v4" },
                new Theme() { ThemeId = "material-v2", Name = "Material-v2" },
                new Theme() { ThemeId = "default", Name = "Default" },
                new Theme() { ThemeId = "material", Name = "Material" },
                new Theme() { ThemeId = "moonlight", Name = "Moonlight" },
                new Theme() { ThemeId = "uniform", Name = "Uniform" },
                new Theme() { ThemeId = "bootstrap", Name = "Bootstrap v3" },
                new Theme() { ThemeId = "highcontrast", Name = "High Contrast" },
                new Theme() { ThemeId = "metroblack", Name = "Metro Black" },
                new Theme() { ThemeId = "silver", Name = "Sliver" },
                new Theme() { ThemeId = "blueopal", Name = "Blue Opal" },
                new Theme() { ThemeId = "flat", Name = "Flat" },
                new Theme() { ThemeId = "metro", Name = "Metro" },
                new Theme() { ThemeId = "office365", Name = "Office 365" },
                new Theme() { ThemeId = "black", Name = "Black" },
                new Theme() { ThemeId = "fiori", Name = "Fiori" },
                new Theme() { ThemeId = "materialblack", Name = "Material black" },
                new Theme() { ThemeId = "nova", Name = "Nova" },
            };
            return Json(themes);
        }

        [HttpPost]
        public IActionResult SetTheme(string selection)
        {
            string logSnippet = "[ClientThemeChangeController][SetTheme] =>";

            Console.WriteLine();
            Console.WriteLine($"{logSnippet} (param:selection): '{selection}'");

            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddMinutes(10);

            Response.Cookies.Append("theme", selection, cookie);
            var returnUrl = Request.Headers["Referer"].ToString();
            Console.WriteLine($"{logSnippet} (local:returnUrl): '{returnUrl}'");
            Console.WriteLine();

            return Json(new { result = "Redirect", url = returnUrl });
        }
    }
}
