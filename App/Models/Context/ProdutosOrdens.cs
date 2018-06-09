using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Context
{
    public class ProdutosOrdens
    {
        public int ProdutoOrdemId { get; set; }
        public int OrdemServicoId { get; set; }
        public int ProdutoId { get; set; }
        public string Motivo { get; set; }
        public DateTime DataHora { get; set; }

        public OrdemServicos OrdemServico { get; set; }
        public Produtos Produto { get; set; }
    }
}
