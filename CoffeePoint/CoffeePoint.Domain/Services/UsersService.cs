using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeePoint.Database;
using CoffeePoint.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeePoint.Domain.Services
{
    public class UsersService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IHashProvider _hashProvider;

        public UsersService(DatabaseContext databaseContext,IHashProvider hashProvider)
        {
            _databaseContext = databaseContext;
            _hashProvider = hashProvider;
        }

        public async Task<User> Authorize(string userName, string password)
        {
            var user = await _databaseContext.Users.SingleOrDefaultAsync(a => a.UserName == userName);
            if (user == null)
                return null;
            
            var hash = _hashProvider.GetHash(password);
            return hash == user.PasswordHash ? user : null;
        }
        
        public async Task<Guid> CreateUser(User model)
        {
            model.PasswordHash = _hashProvider.GetHash(model.PasswordHash);
            _databaseContext.Users.Add(model);

            await _databaseContext.SaveChangesAsync();

            return model.UserGuid;
        }

        public async Task UpdateUser(User model)
        {
            var user = await _databaseContext.Users.FindAsync(model.UserGuid);
            user.UserName = model.UserName;
            if (user.PasswordHash!=model.PasswordHash)
                user.PasswordHash = _hashProvider.GetHash(model.PasswordHash);

            await _databaseContext.SaveChangesAsync();
        }

        public async Task DeleteUser(Guid userGuid)
        {
            var user = await _databaseContext.Users.FindAsync(userGuid);
            _databaseContext.Users.Remove(user);

            await _databaseContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetUsers()
        {
            return await _databaseContext.Users.ToListAsync();
        }
        
        
        public async Task<User> GetUser(Guid userGuid)
        {
            return await _databaseContext.Users.SingleAsync(a=>a.UserGuid==userGuid);
        }
    }
}