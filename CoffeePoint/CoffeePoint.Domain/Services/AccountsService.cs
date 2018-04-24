using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeePoint.Database;
using CoffeePoint.Domain.Entities;
using CoffeePoint.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeePoint.Domain.Services
{
    public class AccountsService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly SessionContext _sessionContext;

        public AccountsService(DatabaseContext databaseContext,SessionContext sessionContext)
        {
            _databaseContext = databaseContext;
            _sessionContext = sessionContext;
        }

        public async Task<Guid> Create(Account account)
        {
            account.AccountGuid = Guid.NewGuid();

            _databaseContext.Accounts.Add(account);

            await _databaseContext.SaveChangesAsync();

            return account.AccountGuid;
        }
        public async Task Update(Account model)
        {
            var account = await _databaseContext.Accounts.FindAsync(model.AccountGuid);

            account.Name = model.Name;
            account.TypeId = model.TypeId;

            await _databaseContext.SaveChangesAsync();

        }
        public async Task Delete(Guid accountGuid)
        {
            var user = await _databaseContext.Accounts.FindAsync(accountGuid);
            _databaseContext.Accounts.Remove(user);

            await _databaseContext.SaveChangesAsync();
        }
        
        public async Task<Account> GetAccount(Guid accountGuid)
        {
            return await _databaseContext.Accounts.FindAsync(accountGuid);
        }
        
        public async Task<List<Account>> GetAccounts()
        {
            return await _databaseContext.Accounts.Include(a=>a.Type).ToListAsync();
        }
        
        
    }
}