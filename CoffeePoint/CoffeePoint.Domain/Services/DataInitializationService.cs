using System.Threading.Tasks;
using Astral.Extensions.Hashing.Abstractions;
using CoffeePoint.Database;
using CoffeePoint.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeePoint.Domain.Services
{
    public class DataInitializationService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IHashProvider _hashProvider;

        public DataInitializationService(DatabaseContext databaseContext,IHashProvider hashProvider)
        {
            _databaseContext = databaseContext;
            _hashProvider = hashProvider;
        }
        
        public async Task SeedAll()
        {
            if (!await _databaseContext.Users.AnyAsync(a => a.UserName == "admin"))
            {
                var user = new User("admin", "", "", _hashProvider.GetHash("123123"));
                _databaseContext.Users.Add(user);

                await _databaseContext.SaveChangesAsync();
            }
            
            if (!await _databaseContext.AccountTypes.AnyAsync())
            {
                var acc1 = new AccountType(AccountTypeOption.BankAccount,"Банковский счет");
                _databaseContext.AccountTypes.Add(acc1);
                
                var acc2 = new AccountType(AccountTypeOption.Cash,"Наличный расчет");
                _databaseContext.AccountTypes.Add(acc2);
                
                
                await _databaseContext.SaveChangesAsync();
            }
        }
        
    }
}