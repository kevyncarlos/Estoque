using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Context
{
    public class Usuarios
    {
        public int UsuarioId { get; set; }
        public int TipoUsuarioId { get; set; }
        public int EmpresaId { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public DateTime DataCad { get; set; }
        public DateTime UltimoAcesso { get; set; }
        public bool Ativo { get; set; }

        public TipoUsuarios TipoUsuario { get; set; }
        public Empresas Empresa { get; set; }

        public ICollection<OrdemServicos> OrdemServicos { get; set; }
    }
}
