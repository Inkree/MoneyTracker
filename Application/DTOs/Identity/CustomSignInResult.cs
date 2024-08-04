using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Identity
{
    public class CustomSignInResult
    {
        public bool Succeeded { get; private set; }
        public bool RequiresTwoFactor { get; private set; }
        public bool IsLockedOut { get; private set; }
        public bool IsNotAllowed { get; private set; }
        public string? Error { get; private set; }

        public static CustomSignInResult Success()
        {
            return new CustomSignInResult { Succeeded = true };
        }

        public static CustomSignInResult TwoFactorRequired()
        {
            return new CustomSignInResult { RequiresTwoFactor = true };
        }

        public static CustomSignInResult LockedOut()
        {
            return new CustomSignInResult { IsLockedOut = true };
        }

        public static CustomSignInResult NotAllowed()
        {
            return new CustomSignInResult { IsNotAllowed = true };
        }

        public static CustomSignInResult Failed(string error)
        {
            return new CustomSignInResult { Error = error };
        }
    }
}

