using System;
using System.Collections.Generic;

namespace SOA_ProyectoUTP.Models
{
    public partial class Suscripcione
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string? Empresa { get; set; }
        public string? CorreoEmpresa { get; set; }
        public string? NumContacto { get; set; }
        public string? Puesto { get; set; }
        public string? NroSubs { get; set; }
        public string? Subdominio { get; set; }
    }
}
