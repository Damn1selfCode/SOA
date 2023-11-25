using System;
using System.Collections.Generic;

namespace SOA_ProyectoUTP.Models
{
    public partial class FiltrosDetalle
    {
        public int IdFiltro { get; set; }
        public int IdOrden { get; set; }
        public string Opcion { get; set; } = null!;
    }
}
