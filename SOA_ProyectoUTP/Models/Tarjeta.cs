using System;
using System.Collections.Generic;

namespace SOA_ProyectoUTP.Models
{
    public partial class Tarjeta
    {
        public int Id { get; set; }
        public string NombreTarjeta { get; set; } = null!;
        public int NumTarjeta { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string CodTarjeta { get; set; } = null!;
        public int MetodoPagosId { get; set; }
    }
}
