using AgriculturePrensentation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AgriculturePrensentation.Controllers
{
    public class ProfileControllers : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ProfileControllers(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();

            userEditViewModel.Mail = values.Email;
            userEditViewModel.Phone = values.PhoneNumber;

            return View(userEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Password == p.ConfirmPassword)
            {
                values.PhoneNumber = p.Phone;
                values.Email = p.Mail;
                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, p.Password);
                var result = await _userManager.UpdateAsync(values);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
            }

            return View();
        }
    }
}

