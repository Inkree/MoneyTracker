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
        Task<string> GetUserIdAsync(ClaimsPrincipal principal);
        Task<string> GetEmailAsync(ClaimsPrincipal principal);
        Task<string> GetUserNameAsync(ClaimsPrincipal principal);
        Task<string> GetPhoneNumberAsync(ClaimsPrincipal principal);
        Task<AuthenticationResponse> ChangeEmailAsync(ClaimsPrincipal principal, string email, string code);
        Task<AuthenticationResponse> ChangePasswordAsync(ClaimsPrincipal principal, string oldPassword, string newPassword);
        Task<bool> IsEmailConfirmedAsync(string email);
        Task<bool> HasPasswordAsync(ClaimsPrincipal principal);
        Task<AuthenticationResponse> SetPhoneNumberAsync(ClaimsPrincipal principal, string phoneNumber);
        Task<AuthenticationResponse> AddPasswordAsync(ClaimsPrincipal principal, string newPassword);
        Task<Result> AddLoginAsync(UserDto userDto,CustomExternalLoginInfo info);
    }
}
