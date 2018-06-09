using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Context
{
    public class OrdemServicos
    {
        public int OrdemServicoId { get; set; }
        public int TipoOrdemServicoId { get; set; }
        public int UsuarioId { get; set; }
        public string Descricao { get; set; }
        public string Cliente { get; set; }
        public int Status { get; set; }

        public TipoOrdemServicos TipoOrdemServico { get; set; }
        public Usuarios Usuario { get; set; }

        public ICollection<ProdutosOrdens> ProdutosOrdens { get; set; }
        public ICollection<LogOrdens> LogOrdens { get; set; }
    }
}
