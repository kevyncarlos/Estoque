using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Context
{
    public class TipoUsuarios
    {
        public int TipoUsarioId { get; set; }
        public string Tipo { get; set; }
        public bool Ativo { get; set; }

        public ICollection<UsuarioPermissoes> UsuarioPermissoes { get; set; }
        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
