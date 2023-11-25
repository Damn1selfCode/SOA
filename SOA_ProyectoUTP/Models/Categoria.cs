using System;
using System.Collections.Generic;

namespace SOA_ProyectoUTP.Models
{
    public partial class Categoria
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }
        public int? Orden { get; set; }
        public int? Nivel { get; set; }
        public int IdCategoria { get; set; }

        
    }
}
