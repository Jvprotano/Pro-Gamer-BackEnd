using ProGamer.BackEnd.Helpers;
using ProGamer.BackEnd.Models;
using ProGamer.BackEnd.Models.Request;
using ProGamer.BackEnd.Models.Response;
using ProGamer.BackEnd.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ProGamer.BackEnd.Services.Implements
{
    public class AccountService : IAccountService
    {
        #region Methods

        #region LoginAsync
        public async Task<LoginResponse> LoginAsync(LoginRequest request, ApplicationUserManager userManager, string url)
        {
            request.ValidateModel();

            var loginResult = new LoginResponse();

            //verifica se o usuário existe na base de dados
            var user = await userManager.FindAsync(request.Email, request.Password);

            if (user == null)
            {
                loginResult.ErrorMessage = "E-mail ou senha inválidos. Corrija e tente novamente";
                return loginResult;
            }

            using (var context = new Entities.Entities())
            {
                var token = await TokenHelper.GenerateAuthUserTokenAsync(request.Email, request.Password, url);

                loginResult.UserData = await context.ListAspNetUsers
                    .Where(u => u.UserName == request.Email && u.Active)
                    .Select(u => new UserResponse
                    {
                        Id = u.Id,
                        Email = u.Email,
                        Name = u.Name,
                        LastName = u.LastName,
                        Active = u.Active,
                        DateBirth = u.DateBirth,
                    })
                    .FirstOrDefaultAsync();

                if (loginResult.UserData.Active)
                {
                    loginResult.ErrorMessage = "Usuário inativo";
                    return loginResult;
                }

                loginResult.Success = true;
            }

            return loginResult;
        }

        #endregion

        #region RegisterUserAsync
        public async Task RegisterUserAsync(RegisterUserRequest request, ApplicationUserManager userManager)
        {
            request.ValidateModel();

            using (var context = new Entities.Entities())
            {
                if (context.ListAspNetUsers.Any(u => u.UserName == request.Email))
                    throw new ValidationException("O e-mail informado já está cadastrado no sistema.");

                var newUser = new ApplicationUser
                {
                    Email = request.Email,
                    UserName = request.Email,
                    LastName = request.LastName,
                    Name = request.Name,
                    DateBirth = request.DateBirth,
                    Active = true
                };

                await userManager.CreateAsync(newUser, request.Password);
            }



        }
        #endregion
        #endregion

    }
}