using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Context
{
    public class UsuarioPermissoes
    {
        public int UsuarioPermissaoId { get; set; }
        public int PermissaoId { get; set; }
        public int TipoUsuarioId { get; set; }

        public Permissoes Permissao { get; set; }
        public TipoUsuarios TipoUsuario { get; set; }
    }
}
