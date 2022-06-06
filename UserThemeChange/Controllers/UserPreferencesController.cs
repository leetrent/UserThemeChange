using Microsoft.AspNetCore.Mvc;

namespace UserThemeChange.Controllers
{
    public class UserPreferencesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
