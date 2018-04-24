using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeePoint.Database;
using CoffeePoint.Domain.Entities;
using CoffeePoint.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeePoint.Domain.Services
{
    public class ShiftsService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly SessionContext _sessionContext;

        public ShiftsService(DatabaseContext databaseContext,SessionContext sessionContext)
        {
            _databaseContext = databaseContext;
            _sessionContext = sessionContext;
        }

        public async Task<CashierShift> GetCurrent()
        {
            return await _databaseContext.CashierShifts.SingleOrDefaultAsync(a => a.EndDate.HasValue);
        }
        
        public async Task<Guid> OpenShift()
        {
            if (await _databaseContext.CashierShifts.AnyAsync(a => a.EndDate == null))
            {
                return Guid.Empty;
            }
            var shift = new CashierShift(_sessionContext.UserGuid);
            _databaseContext.CashierShifts.Add(shift);

            await _databaseContext.SaveChangesAsync();

            return shift.ShiftGuid;
        }

        public async Task CloseShift()
        {
            var shift = await _databaseContext.CashierShifts.SingleAsync(a => a.EndDate == null);

            shift.EndDate = DateTimeOffset.Now;
            shift.ClosedByUserGuid = _sessionContext.UserGuid;        

            await _databaseContext.SaveChangesAsync();
        }

        public async Task<List<CashierShift>> GetShifts()
        {
            return await _databaseContext.CashierShifts.Include(a=>a.ClosedByUser).Include(a=>a.OpenedByUser).ToListAsync();
        }
        
        
    }
}