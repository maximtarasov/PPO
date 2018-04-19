﻿using System.Threading.Tasks;
using CoffeePoint.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoffeePoint.Web.Controllers
{
    public class AuthorizationController:Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UsersService _usersService;

        public AuthorizationController(SignInManager<User> signInManager,UsersService usersService)
        {
            _signInManager = signInManager;
            _usersService = usersService;
        }
        public ViewResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Authorize(AuthorizationModel model)
        {
            var user = await _usersService.Authorize(model.Username, model.Password);
            if (user==null)
            {
                ModelState.AddModelError("","Неверные имя пользователя или пароль");
                return View("Index");
            }
            await _signInManager.SignInAsync(user,true);
            
            
            return RedirectToAction("Index","Profiles");
        }
        
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            
            
            return RedirectToAction("Index","Authorization");
        }
    }

    public class AuthorizationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
    }
}