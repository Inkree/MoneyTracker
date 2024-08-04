using Application.DTOs.Identity;
using Microsoft.AspNetCore.Authentication;

namespace Money_tracker.ViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool rememberMe { get; set; }
        public string ReturnUrl { get; set; }
        public IList<CustomAutenticationScheme>? ExternalLogins { get; set; }
    }
}
