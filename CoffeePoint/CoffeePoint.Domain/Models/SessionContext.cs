using System;
using CoffeePoint.Domain.Entities;

namespace CoffeePoint.Domain.Models
{
    public class SessionContext
    {
        public bool Authorized { get; set; }
        public string UserName { get; set; }
        public Guid UserGuid { get; set; }

        public SessionContext()
        {
            Authorized = false;
        }

        public SessionContext(User user)
        {
            Authorized = true;
            UserName = user.UserName;
            UserGuid = user.UserGuid;
        }
    }
}