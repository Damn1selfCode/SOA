using System;
using System.Collections.Generic;

namespace SOA_ProyectoUTP.Models
{
    public partial class Curso
    {
        public int Id { get; set; }
        public string Curso1 { get; set; } = null!;
        public decimal Precio { get; set; }
        public decimal? Calificacion { get; set; }
        public string? Introduccion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public byte[]? Imagen { get; set; }
        public string Estado { get; set; } = null!;
		public int IdInstructor { get; set; }
        public int IdCategorias { get; set; }
        public int IdSubcategorias { get; set; }
        public string? Url { get; set; }
        public decimal? Duracion { get; set; }
        public int? NroClases { get; set; }
        public string? Nivel { get; set; }
        public string? NivelSubscripcion { get; set; }
        public string? Subtitulo { get; set; }
        public string? Descripcion { get; set; }
        public int Adquisiciones { get; set; }
        public int nro_venta { get; set; }
		//public virtual Instructore Instructor { get; set; }

	}
}
