using Microsoft.AspNetCore.Mvc;

namespace AgriculturePrensentation.ViewComponents
{
    public class _DashboardScriptPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); 
        }
    }
}
