using System;
using System.Collections.Generic;

namespace SOA_ProyectoUTP.Models
{
    public partial class Factura
    {
        public string Id { get; set; } = null!;
        public string? NumFactura { get; set; }
        public int IdUsuario { get; set; }
        public int IdMetodopago { get; set; }
        public int IdCompras { get; set; }
    }
}
