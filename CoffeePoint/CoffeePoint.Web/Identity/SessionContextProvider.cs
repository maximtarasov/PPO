using System.Linq;
using CoffeePoint.Database;
using CoffeePoint.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace CoffeePoint.Web.Identity
{
    /// <summary>
    /// Провайдер контекста сессии
    /// </summary>
    public class SessionContextProvider
    {
        private readonly DatabaseContext _databaseContext;
        private readonly HttpContext _httpContext;

        /// <summary />
        public SessionContextProvider(DatabaseContext databaseContext, IHttpContextAccessor httpContext)
        {
            _databaseContext = databaseContext;
            _httpContext = httpContext?.HttpContext;
        }

        /// <summary>
        /// Получает контекст сессии
        /// </summary>
        /// <returns></returns>
        public SessionContext GetSessionContext()
        {
            var name = _httpContext?.User?.Identity.Name;
            var ipAddres = GetSessionIp();
            if (string.IsNullOrEmpty(name))
            {
                return new SessionContext();
            }

            return GetContext(name);
        }

        #region Private

        private SessionContext GetContext(string userName)
        {
            var user = _databaseContext.Users.SingleOrDefault(a => a.UserName.ToUpper() == userName.ToUpper());
            return user == null ? new SessionContext() : new SessionContext(user);
        }

        private string GetSessionIp()
        {
            return _httpContext.Connection.RemoteIpAddress.ToString();
        }

        #endregion
    }
}
