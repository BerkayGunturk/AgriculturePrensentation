using Microsoft.AspNetCore.Mvc;

namespace AgriculturePrensentation.ViewComponents
{
    public class _DashboardHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
