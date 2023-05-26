using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AgriculturePrensentation.ViewComponents
{
	public class _AboutPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			AgricultureContext c = new AgricultureContext();
			var values = c.Abouts.ToList();
			return View(values);
		}
	}
}
