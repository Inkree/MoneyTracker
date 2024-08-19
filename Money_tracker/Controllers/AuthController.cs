using Application.DTOs.Identity;
using Application.Interfaces;
using Core.interfaces;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Money_tracker.ViewModels;
using System.Security.Claims;


namespace Money_tracker.Controllers
{
    [Route("[controller]/[action]")]
    public class AuthController : Controller
    { 
        //private readonly UserManager<User> _userManager;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        public AuthController(IAuthService authService,IUserService userService)
        {
            
            //_userManager = userManager;
            _authService = authService;
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
           
            LoginViewModel model = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _authService.GetExternalAuthenticationSchemesAsync()).ToList(),
            };
            return View(model);
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Auth",
                                    new { ReturnUrl = returnUrl });
            var externalAuthPropertiesDto = _authService.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            var properties = new AuthenticationProperties { RedirectUri = externalAuthPropertiesDto.RedirectUri };
            foreach (var item in externalAuthPropertiesDto.Items)
            {
                properties.Items[item.Key] = item.Value;
            }

            return Challenge(properties, provider);
        }

        //[AllowAnonymous]
        //[HttpGet]
        //public async Task<IActionResult> ExternalLoginCallback(string? returnUrl = null, string? remoteError = null)
        //{           
        //    returnUrl = returnUrl ?? Url.Content("~/");

        //    LoginViewModel loginViewModel = new LoginViewModel
        //    {
        //        ReturnUrl = returnUrl,
        //        ExternalLogins = (await _authService.GetExternalAuthenticationSchemesAsync()).ToList()
        //    };

        //    if (remoteError != null)
        //    {
        //        ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");

        //        return View("Login", loginViewModel);
        //    }
        //    var info = await _authService.GetExternalLoginInfoAsync();
        //    if (info == null)
        //    {
        //        ModelState
        //            .AddModelError(string.Empty, "Error loading external login information.");

        //        return View("Login", loginViewModel);
        //    }
        //    var signInResult = await _authService.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: false);

        //    if (signInResult == true)
        //    {
        //        return LocalRedirect(returnUrl);
        //    }
        //    else
        //    {
        //        var email = info.Email;
        //        if (email != null)
        //        {
        //            var user = await _userService.FindByEmailAsync(email);

        //            if (user == null)
        //            {
        //                var request = new SignUpRequest()
        //                {
        //                    UserName = email,
        //                    Email = email,
        //                };
        //                var result = await _authService.SignUpAsync(request);
        //                if (result.Succeeded)
        //                {
        //                    user = await _userService.FindByEmailAsync(email);
        //                    await _userService.AddLoginAsync(user, info);
        //                    await _authService.SignInAsync(new SignInRequest() { Email = user.Email});
        //                }
        //                return RedirectToAction("Index", "Transaction");
        //            }

        //            else
        //            {
        //                await _userService.AddLoginAsync(user, info);
        //                var signInRequest = new SignInRequest() { Email = user.Email };
        //                await _authService.SignInAsync(signInRequest);
        //                return LocalRedirect(returnUrl);
        //            }
                   
        //        }
        //        ViewBag.ErrorTitle = $"Email claim not received from: {info.LoginProvider}";
        //        ViewBag.ErrorMessage = "Please contact support on Pragim@PragimTech.com";

        //        return View("Error");
        //    }
        //}

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string? returnUrl = null, string? remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            LoginViewModel loginViewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _authService.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");

                return View("Login", loginViewModel);
            }
            var info = await _authService.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState
                    .AddModelError(string.Empty, "Error loading external login information.");

                return View("Login", loginViewModel);
            }

            var signInResult = await _authService.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: false);
            if (signInResult)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                var email = info.Email;
                if (email != null)
                {
                    var user = await _userService.FindByEmailAsync(email);
                    if (user == null) 
                    {
                        var request = new SignUpRequest()
                        {
                            UserName = email,
                            Email = email,
                        };
                        user = new UserDto() { UserName = email, Email = email };
                        await _authService.SignUpAsync(request);
                    }
                    await _userService.AddLoginAsync(user, info);
                    await _authService.SignInAsync(new SignInRequest() { Email = user.Email });

                    return LocalRedirect(returnUrl);
                }
            }
            return View("Error");

        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _authService.SignOutAsync();
            return RedirectToAction("Index", "Transaction");
        }
    }
}
