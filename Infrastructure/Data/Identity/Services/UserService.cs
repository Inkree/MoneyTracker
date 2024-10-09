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

        public string? GetUserId(ClaimsPrincipal principal)
        {
           return _userManager.GetUserId(principal);
        }

        public Task<string> GetUserNameAsync(ClaimsPrincipal principal)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> AddLoginAsync(UserDto userDto,CustomExternalLoginInfo info)
        {
          
          var loginInfo = new UserLoginInfo(info.LoginProvider, info.ProviderKey, info.DisplayName);
            var user = await _userManager.FindByEmailAsync(userDto.Email);
          var result = await _userManager.AddLoginAsync(user,loginInfo);
          return result.ToApplicationResult();
        }
    }
}
