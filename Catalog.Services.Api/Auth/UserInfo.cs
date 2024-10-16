using System.Security.Claims;
namespace Authentication.Service.API.Models.Auth
{
    public class UserInfoContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserInfoContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int? GetCurrentUser()
        {
            var identity = _httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;
            return (int.TryParse(identity?.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value, out int userId))==true? userId:null;
        }
    }

}
