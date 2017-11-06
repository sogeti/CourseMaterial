using System;
using System.Security.Claims;
using System.Threading;

namespace WebShop.BusinessLogicLayer.UseCases
{
    public static class CurrentUser
    {
        public static int CustomerId
        {
            get
            {
                if (!Thread.CurrentPrincipal.Identity.IsAuthenticated) return -1;
                int id;
                var customerId = GetClaimValue(ClaimTypes.UserData);
                if (!String.IsNullOrEmpty(customerId) && Int32.TryParse(customerId, out id))
                {
                    return id;
                }
                return -1;
            }
        }

        private static Claim GetClaim(string claimType)
        {
            var principal = Thread.CurrentPrincipal as ClaimsPrincipal;
            if (principal == null) return null;
            return principal.FindFirst(claimType);
        }

        private static string GetClaimValue(string claimType)
        {
            var claim = GetClaim(claimType);
            if (claim == null) return null;
            return claim.Value;
        }
    }
}
