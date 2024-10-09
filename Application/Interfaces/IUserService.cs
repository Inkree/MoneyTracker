using Application.DTOs.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.interfaces
{
    public interface IUserService
    {
        Task<UserDto?> FindByIdAsync(string userId);
        Task<UserDto?> FindByEmailAsync(string email);
        string GetUserId(ClaimsPrincipal principal);
        Task<Result> AddLoginAsync(UserDto userDto,CustomExternalLoginInfo info);
    }
}
