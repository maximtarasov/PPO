using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeePoint.Database;
using CoffeePoint.Domain.Entities;
using CoffeePoint.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeePoint.Domain.Services
{
    public class DiscountsService
    {
        private readonly DatabaseContext _databaseContext;

        public DiscountsService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Guid> Create(Discount model)
        {
            model.DiscountGuid = Guid.NewGuid();
            
            _databaseContext.Discounts.Add(model);

            await _databaseContext.SaveChangesAsync();

            return model.DiscountGuid;
        }

        public async Task Update(Discount model)
        {
            var product = await _databaseContext.Discounts.FindAsync(model.DiscountGuid);

            product.Name = model.Name;
            product.Percetage = model.Percetage;
            
            

            await _databaseContext.SaveChangesAsync();
        }

        public async Task Delete(Guid discountGuid)
        {
            var user = await _databaseContext.Discounts.FindAsync(discountGuid);
            _databaseContext.Discounts.Remove(user);

            await _databaseContext.SaveChangesAsync();
        }

        public async Task<List<Discount>> GetDiscounts()
        {
            return await _databaseContext.Discounts.ToListAsync();
        }
        
        
        public async Task<Discount> GetDiscount(Guid discountGuid)
        {
            return await _databaseContext.Discounts.SingleAsync(a=>a.DiscountGuid==discountGuid);
        }
    }}