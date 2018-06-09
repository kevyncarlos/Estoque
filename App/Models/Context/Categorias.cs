using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Context
{
    public class Categorias
    {
        public int CategoriaId { get; set; }
        public int TipoProdutoId { get; set; }
        public string Categoria { get; set; }
        public bool Ativo { get; set; }

        public TipoProdutos TipoProduto { get; set; }

        public ICollection<Prateleiras> Prateleiras { get; set; }
    }
}
