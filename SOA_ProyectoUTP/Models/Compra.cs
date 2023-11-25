using System;
using System.Collections.Generic;

namespace SOA_ProyectoUTP.Models
{
    public partial class Compra
    {
        public int Id { get; set; }
        public int SuscripcionesId { get; set; }
        public int UsuariosId { get; set; }
        public string? Estado { get; set; }
        public int? IdUsuarioRegalo { get; set; }
        public decimal? PrecioFinal { get; set; }
        public string? Comprascol { get; set; }
    }
}
