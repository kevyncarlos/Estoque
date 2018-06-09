using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Context
{
    public class Prateleiras
    {
        public int PrateleiraId { get; set; }
        public int CategoriaId { get; set; }
        public string Descricao { get; set; }

        public Categorias Categoria { get; set; }

        public ICollection<Produtos> Produtos { get; set; }
    }
}
