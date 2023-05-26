using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AgriculturePrensentation.ViewComponents
{
	public class _MapPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			AgricultureContext context = new AgricultureContext();
			var values = context.Addresses.Select(x => x.Mapinfo).FirstOrDefault();
			ViewBag.v = values;
			return View();
		}
	}
}
