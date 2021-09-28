using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PROJ.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) {

            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult AccessDenied() {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user) {
                ApplicationUser appUser = await _userManager.FindByEmailAsync(user.email);

                if (appUser != null) {

                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(appUser, user.password, false, false);
                    if (result.Succeeded) {
                        User userToReturn = new User
                        {
                            firstName = appUser.firstName,
                            lastName = appUser.lastName,
                            email = appUser.email,
                            studentId = appUser.studentId,
                        };
                        return Ok(userToReturn);
                    }
                }
                ModelState.AddModelError(nameof(user), "Login Failed: Invalid Email or Password");
            return Ok(false);
        }

        [Authorize]
        public async Task<IActionResult> Logout() {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
