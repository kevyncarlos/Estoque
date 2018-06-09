using App.Models.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace App.Services
{
    public static class Authenticate
    {
        public static async Task Login(Usuarios Usuario, HttpContext HttpContext)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", Usuario.UsuarioId.ToString()),
                new Claim(ClaimTypes.Name, Usuario.Nome),
                new Claim("Email", Usuario.Email),
                new Claim("Matricula", Usuario.Matricula),
                new Claim("TipoUsuario", Usuario.TipoUsuarioId.ToString()),
                new Claim("Empresa", Usuario.EmpresaId.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            //Propriedades de configuração do login
            var authProperties = new AuthenticationProperties
            {
                //Tempo para expirar o login
                ExpiresUtc = DateTime.UtcNow.AddMinutes(60),
                AllowRefresh = true
            };

            //Efetivação do login do usuário
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);
        }
    }
}
