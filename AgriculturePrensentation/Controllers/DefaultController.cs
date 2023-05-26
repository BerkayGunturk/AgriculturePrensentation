using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePrensentation.Controllers
{
    public class DefaultController : Controller
    {
       public IActionResult Index()
        {
            
            return View();
        }
    }
}
