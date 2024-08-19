using Application.DTOs.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        public Task SignInAsync(SignInRequest signInRequest);
        public Task<Result> SignUpAsync(SignUpRequest signUpRequest);
        public Task SignOutAsync();
        public Task<UserDto?> GetCurentUserAsync(ClaimsPrincipal principal);
        public Task<AuthenticationResponse> ChangePasswordAsync(ClaimsPrincipal claimsPrincipal,string curentPassword, string newPassword);
        public Task<AuthenticationResponse> ResetPasswordAsync(ResetPasswordRequest resetPasswordRequest);
        public Task<bool> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent,bool bypassTwoFactor);
        public Task<CustomExternalLoginInfo?> GetExternalLoginInfoAsync();
        public Task<IEnumerable<CustomAutenticationScheme>> GetExternalAuthenticationSchemesAsync();
        public ExternalAuthPropertiesDto ConfigureExternalAuthenticationProperties(string provider, string returnUrl);


    }
}
