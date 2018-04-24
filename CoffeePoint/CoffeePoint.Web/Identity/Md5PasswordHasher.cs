using Astral.Extensions.Hashing.Abstractions;
using CoffeePoint.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CoffeePoint.Web.Identity
{
    /// <summary>
    /// MD5 Хешер паролей
    /// </summary>
    public class Md5PasswordHasher: IPasswordHasher<User>
    {
        private readonly IHashProvider _hashProvider;

        /// <summary />
        public Md5PasswordHasher(IHashProvider hashProvider)
        {
            _hashProvider = hashProvider;
        }

        /// <summary>
        /// Возвращает хеш пароля
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public string HashPassword(User user, string password)
        {
            return _hashProvider.GetHash(password);
        }

        /// <summary>
        /// Проверяет пароль на валидность
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <param name="hashedPassword">Хешированный пароль</param>
        /// <param name="providedPassword">Переданный пароль</param>
        /// <returns></returns>
        public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
        {
            return _hashProvider.GetHash(providedPassword) == hashedPassword
                ? PasswordVerificationResult.Success
                : PasswordVerificationResult.Failed;
        }
    }
}
