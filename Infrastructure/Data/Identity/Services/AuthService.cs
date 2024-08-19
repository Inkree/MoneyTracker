using Application.DTOs.Identity;
using Application.Interfaces;
using AutoMapper;
using Azure.Core;
using Infrastructure.Data.Identity.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AuthService(IMapper mapper,UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public Task<AuthenticationResponse> ChangePasswordAsync(ClaimsPrincipal claimsPrincipal, string curentPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent,bool bypassTwoFactor)
        {
           var result = await _signInManager.ExternalLoginSignInAsync(loginProvider,providerKey,isPersistent,bypassTwoFactor);
           return result.Succeeded;
        }

        public async Task<UserDto?> GetCurentUserAsync(ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                return null;
            }

            var userId = _userManager.GetUserId(principal);
            if (string.IsNullOrEmpty(userId))
            {
                return null;
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return null;
            }

            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<CustomAutenticationScheme>> GetExternalAuthenticationSchemesAsync()
        {       
          var schemes =  await _signInManager.GetExternalAuthenticationSchemesAsync();
            return schemes.Select(s => new CustomAutenticationScheme(s.Name, s.DisplayName));
        }

        public async Task<CustomExternalLoginInfo?> GetExternalLoginInfoAsync()
        {
           var loginInfo = await _signInManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return null;
            }
            return new CustomExternalLoginInfo
            {
                LoginProvider = loginInfo.LoginProvider,
                ProviderKey = loginInfo.ProviderKey,
                DisplayName = loginInfo.ProviderDisplayName ?? string.Empty,
                Email = loginInfo.Principal.FindFirstValue(ClaimTypes.Email) ?? string.Empty
            };
        }

        public Task<AuthenticationResponse> ResetPasswordAsync(ResetPasswordRequest resetPasswordRequest)
        {
            throw new NotImplementedException();
        }

        public async Task SignInAsync(SignInRequest signInRequest)
        {
            var user = new User
            {
                Email = signInRequest.Email,
                UserName = signInRequest.Email
            };
             await _signInManager.SignInAsync(user,true);
            //var signInResult = await _signInManager.PasswordSignInAsync(signInRequest.Email, signInRequest.Password, signInRequest.RememberMe, false);
        }

        public async Task SignOutAsync()
        {
           await _signInManager.SignOutAsync();
        }

        public async Task<Result> SignUpAsync(SignUpRequest signUpRequest)
        {
            var user = new User
            {
                Email = signUpRequest.Email,
                UserName = signUpRequest.Email
            };

            var result = await _userManager.CreateAsync(user);
            return result.ToApplicationResult();
        }


        public ExternalAuthPropertiesDto ConfigureExternalAuthenticationProperties(string provider,string returnUrl)
        {
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, returnUrl);
            var externalAuthPropertiesDto = new ExternalAuthPropertiesDto
            {
                RedirectUri = properties.RedirectUri,
                LoginProvider = provider
            };

            foreach (var item in properties.Items)
            {
                externalAuthPropertiesDto.Items.Add(item.Key, item.Value);
            }

            return externalAuthPropertiesDto;
        }






    }
}
