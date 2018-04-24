using System.Threading.Tasks;
using Astral.Extensions.Hashing.Abstractions;
using CoffeePoint.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CoffeePoint.Web.Identity
{
    /// <summary>
    /// Валидатор паролей на MD5
    /// </summary>
    public class Md5PasswordValidator : IPasswordValidator<User>
    {
        private readonly IHashProvider _hashProvider;
        
        /// <summary />
        public Md5PasswordValidator(IHashProvider hashProvider)
        {
            _hashProvider = hashProvider;
        }

        /// <summary>
        /// Проверяет пароль на валидность
        /// </summary>
        /// <param name="manager">Менеджер пользователей</param>
        /// <param name="user">Пользователь</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        Task<IdentityResult> IPasswordValidator<User>.ValidateAsync(UserManager<User> manager, User user, string password)
        {
            var hash = _hashProvider.GetHash(password);
     
            if (hash == user.PasswordHash)
            {
                return Task.FromResult(IdentityResult.Success);
            }
            else
            {
                return Task.FromResult(IdentityResult.Failed());
            }
        }


    }
}
