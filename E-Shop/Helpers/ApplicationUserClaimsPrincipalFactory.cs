using E_Shop.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace E_Shop.Helpers
{
       
    public class ApplicationUserClaimsPrincipalFactory :UserClaimsPrincipalFactory<User,IdentityRole>
    {
        public static  string UserId { get; set; }
        public ApplicationUserClaimsPrincipalFactory(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options):base(userManager, roleManager, options)
        {

        }
        protected  override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var identity = await base.GenerateClaimsAsync(user);
                identity.AddClaim(new Claim("UserId", user.Id ?? ""));
                identity.AddClaim(new Claim("UserFirstName", user.FirstName ?? ""));
                identity.AddClaim(new Claim("UserLastName", user.LastName ?? ""));
                 UserId = user.Id;
            return identity;
        }
    }
}
