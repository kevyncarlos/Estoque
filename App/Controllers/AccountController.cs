using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.Models.Account;
using App.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDBContext _context;

        public AccountController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            //Verificação da consistência dos dados
            if (ModelState.IsValid)
            {
                //Inicialização da viewmodel com o contexto de banco de dados
                model.Init(_context);

                //Validando se os dados digitados são válidos
                if (model.IsValid())
                {
                    //Realização do login do usuário
                    await Authenticate.Login(model.ToUsuario(), HttpContext);
                }
            }

            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            //Logout do usuário
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return View();
        }

        [HttpGet]
        public IActionResult Denied()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}