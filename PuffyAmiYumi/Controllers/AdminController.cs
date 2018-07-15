using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PuffyAmiYumi.Models;
using PuffyAmiYumi.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PuffyAmiYumi.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AdminController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {

                List<Claim> claims = new List<Claim>();
                var user = new ApplicationUser
                {
                    UserName = rvm.Email,
                    Email = rvm.Email,
                    FirstName = rvm.FirstName,
                    LastName = rvm.LastName,
                    Birthday = rvm.Birthday,
                    Password = rvm.Password
                };
                var result = await _userManager.CreateAsync(user, rvm.Password);
                if (result.Succeeded)
                {
                    Claim nameClaim = new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}");
                    Claim birthdayClaim = new Claim(ClaimTypes.DateOfBirth,
                        new DateTime(user.Birthday.Year,
                        user.Birthday.Month,
                        user.Birthday.Day).ToString("u"),
                        ClaimValueTypes.DateTime);
                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    claims.Add(nameClaim);
                    claims.Add(birthdayClaim);
                    claims.Add(emailClaim);

                    await _userManager.AddClaimsAsync(user, claims);
                    await _userManager.AddToRoleAsync(user, ApplicationRoles.Admin);

                    await _signInManager.SignInAsync(user, false);

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(rvm);
        }
        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}