using System.Security.Claims;

namespace E_Shop.Helpers
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public UserService(IHttpContextAccessor contextAccessor)
        {

            _contextAccessor = contextAccessor;

        }
        public string GetUserId()
        {
           return _contextAccessor.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
