using Microsoft.AspNet.Identity;
using ProGamer.BackEnd.Helpers;
using ProGamer.BackEnd.Models;
using ProGamer.BackEnd.Models.Request;
using ProGamer.BackEnd.Models.Response;
using ProGamer.BackEnd.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ProGamer.BackEnd.Entities;
using System;

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

            using (var context = new ProGamerEntities())
            {
                var token = await TokenHelper.GenerateAuthUserTokenAsync(request.Email, request.Password, url);

                loginResult.UserData = await context.ListUser
                    .Where(u => u.Email == request.Email && u.Active)
                    .Select(u => new UserResponse
                    {
                        Id = u.Id,
                        Email = u.Email,
                        Name = u.Name,
                        LastName = u.LastName,
                        Active = u.Active,
                        DateBirth = u.DateBirth,
                        AccessToken = token.AccessToken,
                        TokenType = token.TokenType,
                        ExpiresIn = token.ExpiresIn,
                        Issued = token.Issued,
                        Expires = token.Expires,
                    })
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                if (!loginResult.UserData.Active)
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

            using (var context = new ProGamerEntities())
            {
                if (context.ListAspNetUsers.AsNoTracking().Any(u => u.UserName == request.Email))
                    throw new ValidationException("O e-mail informado já está cadastrado no sistema.");

                var newUser = new ApplicationUser { Email = request.Email, UserName = request.Email };

                //registra o usuário na base de dados
                IdentityResult result = await userManager.CreateAsync(newUser, request.Password);
              
                if (!result.Succeeded)
                    throw new ValidationException($"{result.Errors.First()}");

                var userModel = new User
                {
                    Name = request.Name,
                    LastName = request.LastName,
                    Email = request.Email,
                    DateBirth = request.DateBirth.Date,                    
                    Active = true,
                    DateUtcInsert = DateTime.UtcNow
                };

                context.Entry(userModel).State = EntityState.Added;
                await context.SaveChangesAsync();
            }
        }
        #endregion

        #endregion
    }
}