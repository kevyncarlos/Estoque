using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Context
{
    public class Produtos
    {
        public int ProdutoId { get; set; }
        public int PrateleiraId { get; set; }
        public string Produto { get; set; }
        public bool Ativo { get; set; }

        public Prateleiras Prateleira { get; set; }

        public ICollection<CompraProdutos> CompraProdutos { get; set; }
        public ICollection<ProdutosOrdens> ProdutosOrdens { get; set; }
    }
}
