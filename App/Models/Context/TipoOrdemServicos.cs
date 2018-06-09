using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Context
{
    public class TipoOrdemServicos
    {
        public int TipoOrdemServicoId { get; set; }
        public string Tipo { get; set; }
        public bool Ativo { get; set; }

        public ICollection<OrdemServicos> OrdemServicos { get; set; }
    }
}
