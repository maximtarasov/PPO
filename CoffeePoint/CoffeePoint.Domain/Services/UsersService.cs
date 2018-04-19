using System;
using System.Threading.Tasks;
using CoffeePoint.Database;
using CoffeePoint.Domain.Entities;

namespace CoffeePoint.Domain.Services
{
    public class UsersService
    {
        private readonly DatabaseContext _dbContext;

        public UsersService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<Guid> Create(User user)
        {
            _dbContext.Users.Add(user);

            await _dbContext.SaveChangesAsync();

            return user.UserGuid;
        }
    }
}