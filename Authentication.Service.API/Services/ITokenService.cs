using Authentication.Service.API.Models;

namespace Authentication.Service.API.Services
{
    public interface ITokenService<T> 
    {
        public  string GenerateToken(T userInfo);
    }
}
