using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using PuffyAmiYumi.Models;
using PuffyAmiYumi.Models.ViewModel;

namespace PuffyAmiYumi.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IEmailSender _emailSender;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }
        //[HttpGet]
        //[AllowAnonymous]
        //public IActionResult Index()
        //{
        //    return View();
        //}
        /// <summary>
        /// Displays the Register page
        /// </summary>
        /// <returns>Register View</returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        /// <summary>
        /// Displays the Login Page
        /// </summary>
        /// <returns>Login View</returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// When we are on development environment we want Microsoft/Google (our 3rd party OAuths) to redirect us to our local ip address
        /// </summary>
        /// <param name="returnURL">localhost:5555</param>
        /// <returns>To a signed in page</returns>
        private IActionResult RedirectToLocal(string returnURL)
        {
            if (Url.IsLocalUrl(returnURL))
            {
                return Redirect(returnURL);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        /// <summary>
        /// When a user wants to login with a 3rd party for the first time, this page is displayed after a successful login and displays a different login page captuing their detials from the selected provider
        /// </summary>
        /// <param name="provider">Either Google, or MS is our provider</param>
        /// <returns>A Result of OK or Failed</returns>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult ExternalLogin(string provider)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }
        /// <summary>
        /// The method that triggers when we get word back from the OAuth Provider
        /// </summary>
        /// <param name="remoteError"></param>
        /// <returns>On success it logs you in and displays the home screen, on failure, back to the login screen</returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string remoteError)
        {
            if (remoteError != null)
            {
                TempData["ErrorMessage"] = "Error from Provider";
                return RedirectToAction("Login");
            }

            //Checking to see if the web app supports that external login async. 
            var info = await _signInManager.GetExternalLoginInfoAsync();

            if (info == null)
            {
                return RedirectToAction("Login");
            }

            // sign the user in with the external login. See if the user has used this external login provider previously. 
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey,
                isPersistent: false, bypassTwoFactor: true);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            //get the email if this is the first time
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            var firstName = info.Principal.FindFirstValue(ClaimTypes.GivenName);
            string lastName = info.Principal.FindFirstValue(ClaimTypes.Surname);



            //redirect to the external login page for the user to 
            return View("ExternalLogin", new ExternalLoginViewModel { Email = email, FirstName = firstName, LastName = lastName});
        }
        /// <summary>
        /// Once the user confirms their information is correct, they trigger this function, which captures the information the user put in the textboxes
        /// </summary>
        /// <param name="elvm">A view model that holds the text box info</param>
        /// <returns>On success - Home page, on failure - Back to the login screen</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginViewModel elvm)
        {
            if (ModelState.IsValid)
            {
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    TempData["Error"] = "Error loading information";
                }


                var user = new ApplicationUser { UserName = elvm.Email, Email = elvm.Email, FirstName = elvm.FirstName, LastName = elvm.LastName };

                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    List<Claim> claims = new List<Claim>();
                    //TODO: Potentially add Claims here.....
                    Claim nameClaim = new Claim("Name", $"{user.FirstName} {user.LastName}");
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
                    await _userManager.AddToRoleAsync(user, ApplicationRoles.Member);
                    result = await _userManager.AddLoginAsync(user, info);

                    if (result.Succeeded)
                    {
                        // sign the user in with the information they gave us
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Home");

                    }
                }
            }
            return View(elvm);
        }

        /// <summary>
        /// This particular Register method gets called once people press Create Account on the register page
        /// </summary>
        /// <param name="rvm">rvm is a View Model that captures the user input</param>
        /// <returns>Login page</returns>
        [HttpPost]
        [AllowAnonymous]
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
                    Birthday = rvm.Birthday
                };

                Cart cart = new Cart();
                cart.UserTag = user.Id;

                var result = await _userManager.CreateAsync(user, rvm.Password);
                if (result.Succeeded)
                {
                    Claim nameClaim = new Claim("Name", $"{user.FirstName} {user.LastName}");
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
                    await _userManager.AddToRoleAsync(user, ApplicationRoles.Member);
                    SendEmail(user.Email);

                    return RedirectToAction("Login", "Account");
                }
            }
            return View(rvm);
        }
        /// <summary>
        /// Sends a Welcome to our Site email
        /// </summary>
        /// <param name="email">The signed in user's email</param>
        [AllowAnonymous]
        public async void SendEmail(string email)
        {
            await _emailSender.SendEmailAsync(email, "Welcome to Potpourri-R-Us", "" +
                "<h1>Thank you for registering with Potpourri-R-Us!</h1>" +
                "<br/>" +
                "<p>We here at Potpourri-R-Us are about experiences. We are passionate about our products. The aroma of calming lavender? The nostalgic feeling of vanilla? We have it! " +
                "<a href='https://puffyamiyumiapp.azurewebsites.net'> Come on in!</a>" +
                "</p>");
        }
        /// <summary>
        /// Captures the user input on the login page and determines whether they have an account with us
        /// </summary>
        /// <param name="model">A View Model that captures user input from login screen</param>
        /// <returns>A Home page, Login Page, or a Admin page</returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(
                model.Email,
                model.Password,
                false,
                lockoutOnFailure: false);

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (await _userManager.IsInRoleAsync(user, ApplicationRoles.Admin))
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        /// <summary>
        /// Logs the user out
        /// </summary>
        /// <returns>Home page</returns>
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData["LoggedOut"] = "User Logged Out";

            return RedirectToAction("Index", "Home");
        }
    }
}