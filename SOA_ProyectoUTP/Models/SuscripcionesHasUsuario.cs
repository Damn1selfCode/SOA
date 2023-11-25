using System;
using System.Collections.Generic;

namespace SOA_ProyectoUTP.Models
{
    public partial class SuscripcionesHasUsuario
    {
        public int SuscripcionesId { get; set; }
        public int UsuariosId { get; set; }
        public string? FechaSubscripcion { get; set; }
        public string? FechaExpiracion { get; set; }
        public string? Estado { get; set; }
    }
}
