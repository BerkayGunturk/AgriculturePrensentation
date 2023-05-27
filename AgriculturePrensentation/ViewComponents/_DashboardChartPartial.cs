using Microsoft.AspNetCore.Mvc;

namespace AgriculturePrensentation.ViewComponents
{
    public class _DashboardChartPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = 88;
            ViewBag.v2 = 98;
            return View();
        }
    }
}
