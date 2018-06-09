using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Context
{
    public class Permissoes
    {
        public int PermissaoId { get; set; }
        public string Permissao { get; set; }
        public bool Ativo { get; set; }

        public ICollection<UsuarioPermissoes> UsuarioPermissoes { get; set; }
    }
}
