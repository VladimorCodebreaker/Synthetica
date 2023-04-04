using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Synthetica.Data;
using Synthetica.Models;
using Synthetica.Data.Static;
using Synthetica.Data.ViewModels;

namespace Synthetica.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly DatabaseContext _context;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, DatabaseContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        public IActionResult Login() => View(new LoginVM());

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            var user = await _userManager.FindByEmailAsync(loginVM.Email);

            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);

                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Drug");
                    }
                }
                TempData["Error"] = "Wrong credentials. Please, try again!";
                return View(loginVM);
            }

            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(loginVM);
        }

        public IActionResult Register() => View(new RegistrationVM());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrationVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var newUser = new User
                {
                    UserName = registerVM.Email,
                    Email = registerVM.Email,
                    FullName = registerVM.Name
                };

                var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

                if (newUserResponse.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, UserRoles.User);
                    var signInResult = await _signInManager.PasswordSignInAsync(newUser, registerVM.Password, false, false);

                    if (!signInResult.Succeeded)
                    {
                        TempData["Error"] = "Unable to sign in user";
                        return View(registerVM);
                    }

                    return RedirectToAction("Index", "Drug");
                }
                else
                {
                    foreach (var error in newUserResponse.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(registerVM);
                }
            }

            return View(registerVM);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Drug");
        }

        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }
    }
}

