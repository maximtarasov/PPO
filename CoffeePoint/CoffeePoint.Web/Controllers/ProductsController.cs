using System;
using System.Threading.Tasks;
using CoffeePoint.Domain.Entities;
using CoffeePoint.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoffeePoint.Web.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ProductsService _productsService;

        public ProductsController(ProductsService productsService)
        {
            _productsService = productsService;
        }
        
        public async Task<IActionResult> Index()
        {
            var products = await _productsService.GetProducts();
            return View(products);
            
        }
        public async Task<IActionResult> Product(Guid? productGuid)
        {
            
            if (productGuid.HasValue)
            {
                var product = await _productsService.GetProduct(productGuid.Value);
                return View(product);
            }
            return View(new Product());
            
        }

        public async Task<IActionResult> Create(Product product)
        {
            await _productsService.Create(product);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(Product product)
        {
            await _productsService.Update(product);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid productGuid)
        {
            await _productsService.Delete(productGuid);
            return RedirectToAction("Index");
        }
    }
}