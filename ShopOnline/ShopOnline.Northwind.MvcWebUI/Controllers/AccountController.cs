using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Northwind.MvcWebUI.Entities;
using ShopOnline.Northwind.MvcWebUI.Models;
using ShopOnline.Northwind.MvcWebUI.StringInfos;
using System.Threading.Tasks;

namespace ShopOnline.Northwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<CustomIdentityUser> _userManager;
        private readonly RoleManager<CustomIdentityRole> _roleManager;
        private readonly SignInManager<CustomIdentityUser> _signInManager;

        public AccountController(
            UserManager<CustomIdentityUser> userManager,
            RoleManager<CustomIdentityRole> roleManager,
            SignInManager<CustomIdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
                return View(registerViewModel);

            var user = new CustomIdentityUser
            {
                UserName = registerViewModel.UserName,
                Email = registerViewModel.Email
            };

            IdentityResult identityResult = await _userManager.CreateAsync(user, registerViewModel.Password);

            if (!identityResult.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Register is failed!");
                return View(registerViewModel);
            }

            //Sistemde admin adında bir role var mı?
            if (!await _roleManager.RoleExistsAsync(Role.ADMIN))
            {
                var customIdentityRole = new CustomIdentityRole
                {
                    Name = Role.ADMIN
                };

                var roleResult = await _roleManager.CreateAsync(customIdentityRole);

                if (!roleResult.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "We can't add the role!");
                    return View(registerViewModel);
                }

            }

            await _userManager.AddToRoleAsync(user, Role.ADMIN);

            return RedirectToAction(nameof(SignIn));
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View(loginViewModel);

            var identityResult = await _signInManager.PasswordSignInAsync(loginViewModel.UserName,
                                                     loginViewModel.Password,
                                                     loginViewModel.RememberMe,
                                                     false);

            if (!identityResult.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid login!");
                return View(loginViewModel);
            }

            return RedirectToAction("Index", "Product", new { area = Role.ADMIN });
        }

        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(SignIn));
        }
    }
}
