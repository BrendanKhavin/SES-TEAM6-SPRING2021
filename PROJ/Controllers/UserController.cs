using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PROJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ.Controllers
{
    public class UserController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;
        public UserController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(UserRole userRole)
        {

            if (ModelState.IsValid)
            {

                IdentityResult result = await _roleManager.CreateAsync(new ApplicationRole() { Name = userRole.RoleName });
                if (result.Succeeded)
                {
                    ViewBag.Message = "Role Created Successfully";
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = new ApplicationUser
                {
                    UserName = user.Name,
                    Email = user.Email
                };

                IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);

                //Add Role
                await _userManager.AddToRoleAsync(appUser, "Admin");

                if (result.Succeeded)
                {
                    ViewBag.Message = "User Created Successfully";
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(user);
        }
    }


}
