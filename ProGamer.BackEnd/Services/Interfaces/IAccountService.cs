using ProGamer.BackEnd.Models.Request;
using ProGamer.BackEnd.Models.Response;
using System.Threading.Tasks;

namespace ProGamer.BackEnd.Services.Interfaces
{
    public interface IAccountService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request, ApplicationUserManager userManager, string url);
    }
}