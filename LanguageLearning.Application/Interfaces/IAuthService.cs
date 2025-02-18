using System.Threading.Tasks;

namespace LanguageLearning.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> Register(string email, string password);
        Task<string> Login(string email, string password);
    }
}
