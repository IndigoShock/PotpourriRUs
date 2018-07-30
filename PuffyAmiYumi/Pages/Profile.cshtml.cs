using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PuffyAmiYumi.Models;
using PuffyAmiYumi.Models.ViewModel;

namespace PuffyAmiYumi.Pages
{
    public class ProfileModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        public ProfileModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public string Email { get; set; }

        public async void OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            ProfileViewModel profile = new ProfileViewModel();
            profile.FirstName = user.FirstName;
            profile.LastName = user.LastName;
        }

        public async Task OnPost()
        {
            var user = await _userManager.GetUserAsync(User);
            user.FirstName = FirstName;
            user.LastName = LastName;
            await _userManager.UpdateAsync(user);

            Claim claim = User.Claims.First(c => c.Type == "Name");
            Claim newClaim = new Claim("Name", $"{user.FirstName} {user.LastName}");
            await _userManager.RemoveClaimAsync(user, claim);
            await _userManager.AddClaimAsync(user, newClaim);

            await _signInManager.SignOutAsync();
            await _signInManager.SignInAsync(user, false);
        }
    }
}