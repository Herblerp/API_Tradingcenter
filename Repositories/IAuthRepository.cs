using System.Threading.Tasks;
using API_Tradingcenter.Models;

namespace API_Tradingcenter.Repositories
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);
         Task<User> Login(string username, string password);
         Task<bool> UserExists(string username);
         bool IsValidEmail(string email);
    }
}