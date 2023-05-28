using AgriculturePrensentation.Models;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AgriculturePrensentation.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
	{
		private readonly UserManager<IdentityUser> _userManager;

        public LoginController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SignUp(RegisterViewModel registerViewModel)
		{
			IdentityUser ıdentityUser = new IdentityUser()
			{
				Id = "1",
				UserName  = registerViewModel.userName,
				Email = registerViewModel.mail
			};
			if(registerViewModel.password == registerViewModel.passwordConfirm)
			{
				var result = await _userManager.CreateAsync(ıdentityUser, registerViewModel.password);

				if(result.Succeeded)
				{
					return RedirectToAction("Index");
				}
				else
				{
					foreach(var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			}
			return View(registerViewModel);
		}
	}
}
