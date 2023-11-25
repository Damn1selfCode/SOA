using System;
using System.Collections.Generic;

namespace SOA_ProyectoUTP.Models
{
    public partial class Filtro
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public int? Orden { get; set; }
    }
}
