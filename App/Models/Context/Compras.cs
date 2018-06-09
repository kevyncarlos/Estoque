using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Context
{
    public class Compras
    {
        public int CompraId { get; set; }
        public int EmpresaId { get; set; }
        public int FornecedorId { get; set; }
        public DateTime DataCompra { get; set; }
        public decimal Total { get; set; }

        public Empresas Empresa { get; set; }
        public Fornecedores Fornecedor { get; set; }

        public ICollection<CompraProdutos> CompraProdutos { get; set; }
    }
}
