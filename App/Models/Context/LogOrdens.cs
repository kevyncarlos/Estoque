using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Context
{
    public class LogOrdens
    {
        public int LogOrdemId { get; set; }
        public int OrdemServicoId { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public int StatusOrdem { get; set; }

        public OrdemServicos OrdemServico { get; set; }
    }
}
