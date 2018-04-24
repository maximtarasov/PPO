using System.Threading.Tasks;
using CoffeePoint.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeePoint.Web.Controllers
{
    [Authorize]
    public class ShiftsController : Controller
    {
        private readonly ShiftsService _shiftsService;

        public ShiftsController(ShiftsService shiftsService)
        {
            _shiftsService = shiftsService;
        }
        
        public async Task<IActionResult> Index()
        {
            var products = await _shiftsService.GetShifts();
            return View(products);
            
        }

        public async Task<IActionResult> Open()
        {
            await _shiftsService.OpenShift();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Close()
        {
            await _shiftsService.CloseShift();
            return RedirectToAction("Index");
        }

    }
}