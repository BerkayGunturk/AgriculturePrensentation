using Microsoft.AspNetCore.Mvc;

namespace AgriculturePrensentation.ViewComponents
{
	public class _TeamPartial : ViewComponent
	{
		
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
