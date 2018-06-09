using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Context
{
    public class CompraProdutos
    {
        public int CompraProdutoId { get; set; }
        public int CompraId { get; set; }
        public int ProdutoId { get; set; }
        public int QtdProduto { get; set; }
        public decimal Metro { get; set; }
        public int Unidade { get; set; }
        public decimal Valor { get; set; }

        public Compras Compra { get; set; }
        public Produtos Produto { get; set; }
    }
}
