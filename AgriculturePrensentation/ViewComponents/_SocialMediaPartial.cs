using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePrensentation.ViewComponents
{
	public class _SocialMediaPartial : ViewComponent
	{
		private readonly ISocialMedialService _socialMedialService;

		public _SocialMediaPartial(ISocialMedialService socialMedialService)
		{
			_socialMedialService = socialMedialService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _socialMedialService.GetListAll();
			return View(values);
		}
	}
}
