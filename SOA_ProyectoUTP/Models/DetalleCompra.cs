using System;
using System.Collections.Generic;

namespace SOA_ProyectoUTP.Models
{
    public partial class DetalleCompra
    {
        public int ComprasId { get; set; }
        public int CursosId { get; set; }
        public int CursosIdInstructor { get; set; }
        public int CuponesId { get; set; }
        public decimal? PrecioFinal { get; set; }
        public decimal? Descuentos { get; set; }
    }
}
