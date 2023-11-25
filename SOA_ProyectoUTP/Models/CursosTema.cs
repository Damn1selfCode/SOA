using System;
using System.Collections.Generic;

namespace SOA_ProyectoUTP.Models
{
    public partial class CursosTema
    {
        public int CursosId { get; set; }
        public int CursosIdInstructor { get; set; }
        public int CategoriasId { get; set; }
    }
}
