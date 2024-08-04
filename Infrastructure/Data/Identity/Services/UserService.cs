using Application.DTOs.Identity;
using AutoMapper;
using Core.interfaces;
using Infrastructure.Data.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;


namespace Infrastructure.Data.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private IMapper _mapper;
        public UserService(UserManager<User> userManager,IMapper mapper) 
        {
          _userManager = userManager;
          _mapper = mapper;
        }
        public Task<AuthenticationResponse> AddPasswordAsync(ClaimsPrincipal principal, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<AuthenticationResponse> ChangeEmailAsync(ClaimsPrincipal principal, string email, string code)
        {
            throw new NotImplementedException();
        }

        public Task<AuthenticationResponse> ChangePasswordAsync(ClaimsPrincipal principal, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto?> FindByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return null;
            }
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto?> FindByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if(user == null)
            {
                return null;
            }
            return _mapper.Map<UserDto>(user);   
        }

        public Task<string> GetEmailAsync(ClaimsPrincipal principal)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPhoneNumberAsync(ClaimsPrincipal principal)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(ClaimsPrincipal principal)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserNameAsync(ClaimsPrincipal principal)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(ClaimsPrincipal principal)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsEmailConfirmedAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<AuthenticationResponse> SetPhoneNumberAsync(ClaimsPrincipal principal, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> AddLoginAsync(UserDto userDto,CustomExternalLoginInfo info)
        {
          
          var loginInfo = new UserLoginInfo(info.LoginProvider, info.ProviderKey, info.DisplayName);
            var user = await _userManager.FindByIdAsync(userDto.Id);
          var result = await _userManager.AddLoginAsync(user,loginInfo);
          return result.ToApplicationResult();
        }
    }
}
