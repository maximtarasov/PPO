using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Astral.Extensions.Hashing.Abstractions;
using CoffeePoint.Database;
using CoffeePoint.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeePoint.Domain.Services
{
    public class ProductsService
    {
        private readonly DatabaseContext _databaseContext;

        public ProductsService(DatabaseContext databaseContext,IHashProvider hashProvider)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Guid> Create(Product model)
        {
            model.ProductGuid = Guid.NewGuid();
            
            _databaseContext.Products.Add(model);

            await _databaseContext.SaveChangesAsync();

            return model.ProductGuid;
        }

        public async Task Update(Product model)
        {
            var product = await _databaseContext.Products.FindAsync(model.ProductGuid);

            product.Price = model.Price;
            product.Name = model.Name;
            product.Description = model.Description;
            
            

            await _databaseContext.SaveChangesAsync();
        }

        public async Task Delete(Guid productGuid)
        {
            var user = await _databaseContext.Products.FindAsync(productGuid);
            _databaseContext.Products.Remove(user);

            await _databaseContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _databaseContext.Products.ToListAsync();
        }
        
        
        public async Task<Product> GetProduct(Guid productGuid)
        {
            return await _databaseContext.Products.SingleAsync(a=>a.ProductGuid==productGuid);
        }
    }
}