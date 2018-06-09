using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Interfaces
{
    public interface IUser
    {
        int Id { get; }
        string Nome { get; }
        string Email { get; }
        int Matricula { get; }
        int EmpresaId { get; }
        int TipoUsuarioId { get; }
        List<int> Permissoes { get; }
    }
}
