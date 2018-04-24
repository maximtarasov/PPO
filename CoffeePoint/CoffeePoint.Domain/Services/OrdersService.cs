using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePoint.Database;
using CoffeePoint.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeePoint.Domain.Services
{
    public class OrdersService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly ShiftsService _shiftsService;

        public OrdersService(DatabaseContext databaseContext, ShiftsService shiftsService)
        {
            _databaseContext = databaseContext;
            _shiftsService = shiftsService;
        }

        public async Task Create()
        {
            var shift = await _shiftsService.GetCurrent();

            if (shift == null)
            {
                throw new InvalidOperationException("Кассовая смена не открыта");
            }

            var order = new Order(shift.ShiftGuid);
            _databaseContext.Orders.Add(order);

            await _databaseContext.SaveChangesAsync();
        }

        public async Task AddOriderItem(OrderItem item)
        {
            item.ItemGuid = Guid.NewGuid();
            
            _databaseContext.OrderItems.Add(item);

            await _databaseContext.SaveChangesAsync();
        }

        public async Task CloseOrder(Guid orderGuid)
        {
            
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _databaseContext.Orders
                .Include(a=>a.Account)
                .ToListAsync();
        }
        
        
        public async Task<Order> GetOrder(Guid orderGuid)
        {
            return await _databaseContext.Orders
                .Include(a=>a.Account)
                .SingleAsync(a=>a.OrderGuid ==orderGuid);
        }
    }
}