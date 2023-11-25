namespace SOA_ProyectoUTP.DTOs
{
    public class CursoDTO
    {
		public int id_curso { get; set; }
		public string curso { get; set; } = null!;
		public decimal? calificacion { get; set; }
		public decimal precio { get; set; }
		public decimal? descuento { get; set; }
		public string? introduccion { get; set; }
		public DateTime fecha_actualizacion { get; set; }
		public byte[]? imagen { get; set; }
		public string? instructor_nombre { get; set; }
	}
}