using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Context
{
    public class Empresas
    {
        public int EmpresaId { get; set; }
        public string Empresa { get; set; }
        public string Cidade { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
        public ICollection<Compras> Compras { get; set; }
    }
}
