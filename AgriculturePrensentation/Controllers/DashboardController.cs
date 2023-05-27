using Microsoft.AspNetCore.Mvc;

namespace AgriculturePrensentation.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
