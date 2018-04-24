using System;
using System.Threading.Tasks;
using CoffeePoint.Domain.Entities;
using CoffeePoint.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeePoint.Web.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        private readonly AccountsService _accountsService;

        public AccountsController(AccountsService shiftsService)
        {
            _accountsService = shiftsService;
        }
        
        public async Task<IActionResult> Index()
        {
            var accounts = await _accountsService.GetAccounts();
            return View(accounts);
            
        }
        public async Task<IActionResult> Account(Guid? accountGuid)
        {
            
            if (accountGuid.HasValue)
            {
                var product = await _accountsService.GetAccount(accountGuid.Value);
                return View(product);
            }
            return View(new Account());
            
        }

        public async Task<IActionResult> Create(Account product)
        {
            await _accountsService.Create(product);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(Account product)
        {
            await _accountsService.Update(product);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid accountGuid)
        {
            await _accountsService.Delete(accountGuid);
            return RedirectToAction("Index");
        }

    }
}