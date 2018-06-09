using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Context
{
    public class TipoProdutos
    {
        public int TipoProdutoId { get; set; }
        public string Tipo { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Categorias> Categorias { get; set; }
    }
}
