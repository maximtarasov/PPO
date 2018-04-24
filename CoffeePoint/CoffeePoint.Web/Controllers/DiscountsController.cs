using System;
using System.Threading.Tasks;
using CoffeePoint.Domain.Entities;
using CoffeePoint.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeePoint.Web.Controllers
{
    [Authorize]
    public class DiscountsController : Controller
    {
        private readonly DiscountsService _discountsService;

        public DiscountsController(DiscountsService productsService)
        {
            _discountsService = productsService;
        }
        
        public async Task<IActionResult> Index()
        {
            var products = await _discountsService.GetDiscounts();
            return View(products);
            
        }
        public async Task<IActionResult> Discount(Guid? discountGuid)
        {
            
            if (discountGuid.HasValue)
            {
                var product = await _discountsService.GetDiscount(discountGuid.Value);
                return View(product);
            }
            return View(new Discount());
            
        }

        public async Task<IActionResult> Create(Discount discount)
        {
            await _discountsService.Create(discount);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(Discount discount)
        {
            await _discountsService.Update(discount);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid discountGuid)
        {
            await _discountsService.Delete(discountGuid);
            return RedirectToAction("Index");
        }
    }
}