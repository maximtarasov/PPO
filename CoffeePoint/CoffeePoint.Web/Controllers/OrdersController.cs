using System;
using System.Threading.Tasks;
using CoffeePoint.Domain.Entities;
using CoffeePoint.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeePoint.Web.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly OrdersService _ordersService;

        public OrdersController(OrdersService productsService)
        {
            _ordersService = productsService;
        }
        
        public async Task<IActionResult> Index()
        {
            var orders = await _ordersService.GetOrders();
            return View(orders);
            
        }
        public async Task<IActionResult> Order(Guid? orderGuid)
        {
            
            if (orderGuid.HasValue)
            {
                var product = await _ordersService.GetOrder(orderGuid.Value);
                return View(product);
            }
            return View(new Order());
            
        }

    }
}