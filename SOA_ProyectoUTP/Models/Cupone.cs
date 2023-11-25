using System;
using System.Collections.Generic;

namespace SOA_ProyectoUTP.Models
{
    public partial class Cupone
    {
        public int Id { get; set; }
        public string? Cupon { get; set; }
        public string? TipoCupon { get; set; }
        public decimal? Descuento { get; set; }
        public DateTime? FechaExpiracion { get; set; }
        public string? FechaActivacion { get; set; }
        public int CursosId { get; set; }
        public int CursosIdInstructor { get; set; }
        public string? Estado { get; set; }
        public int? NumCupones { get; set; }
        public decimal? PrecioFinal { get; set; }
    }
}
