using System;
using System.Collections.Generic;

namespace SOA_ProyectoUTP.Models
{
    public partial class DetalleFactura
    {
        public int FacturaIdUsuario { get; set; }
        public int FacturaIdMetodopago { get; set; }
        public string FacturaId { get; set; } = null!;
        public string? PrecioFinal { get; set; }
    }
}
