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
            //Lista contendo as informações do usuário acessíveis a aplicação
            var claims = new List<Claim>
            {
                new Claim("Id", Usuario.UsuarioId.ToString()),
                new Claim(ClaimTypes.Name, Usuario.Nome),
                new Claim("Email", Usuario.Email),
                new Claim("Matricula", Usuario.Matricula),
                new Claim("TipoUsuario", Usuario.TipoUsuarioId.ToString()),
                new Claim("Empresa", Usuario.EmpresaId.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            //Efetivação do login do usuário
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }
    }
}
