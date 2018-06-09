using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Context
{
    public class Fornecedores
    {
        public int FornecedorId { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Fornecedor { get; set; }
        public string CNPJ { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Compras> Compras { get; set; }
    }
}
