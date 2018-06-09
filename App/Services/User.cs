using App.Models;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace App.Services
{
    public class User : IUser
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly AppDBContext _context;

        private int _Id, _Matricula, _EmpresaId, _TipoUsuarioId;
        private string _Nome, _Email;

        public User(IHttpContextAccessor accessor, AppDBContext context)
        {
            _accessor = accessor;
            _context = context;
            _Id = Int32.Parse(_accessor.HttpContext.User.FindFirstValue("Id"));
            _Nome = _accessor.HttpContext.User.Identity.Name;
            _Email = _accessor.HttpContext.User.FindFirstValue("Email");
            _Matricula = Int32.Parse(_accessor.HttpContext.User.FindFirstValue("Matricula"));
            _EmpresaId = Int32.Parse(_accessor.HttpContext.User.FindFirstValue("EmpresaId"));
            _TipoUsuarioId = Int32.Parse(_accessor.HttpContext.User.FindFirstValue("TipoUsuarioId"));
        }

        public int Id => _Id;

        public string Nome => _Nome;

        public string Email => _Email;

        public int Matricula => Matricula;

        public int EmpresaId => EmpresaId;

        public int TipoUsuarioId => _TipoUsuarioId;

        public List<int> Permissoes => _context.UsuarioPermissoes.Where(c => c.TipoUsuarioId == _TipoUsuarioId).Select(c => c.UsuarioPermissaoId).ToList();
    }
}
