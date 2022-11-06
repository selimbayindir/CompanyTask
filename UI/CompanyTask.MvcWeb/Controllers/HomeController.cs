using Application.Service;
using CompanyTask.MvcWeb.Models;
using Entity.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CompanyTask.MvcWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            RegisterDto registerDto = new()
            {
                Email = "byndr28@gmail.com",
                Password = "Tbyndr.420",
                UserName = "byndr28"
            };
            await _userService.CreateUser(registerDto);
            registerDto = new()
            {
                Email = "dw@gmail.com",
                Password = "Tbyndr.420",
                UserName = "dw"
            };
            await _userService.CreateUser(registerDto);
            registerDto = new()
            {
                Email = "co@gmail.com",
                Password = "Tbyndr.420",
                UserName = "co"
            };
            await _userService.CreateUser(registerDto);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}