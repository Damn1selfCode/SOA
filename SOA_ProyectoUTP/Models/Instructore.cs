using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOA_ProyectoUTP.Models
{
    public partial class Instructore
	{
		Random random = new Random();
		
		public Instructore()
		{

		}
		public Instructore(int idusuario)
		{
			Id = random.Next(100, 1000);
			IdUsuario = idusuario;
		}
		public int Id { get; set; }
		public int IdUsuario { get; set; }
        public decimal? Calificacion { get; set; }
        public int? CantValoraciones { get; set; }
        public int? NroCursos { get; set; }
        public long? NroEstudiantes { get; set; }
        public byte[]? Imagen { get; set; }
        public string? Url { get; set; }

        //public virtual ICollection<Curso> Cursos{ get; set; }
        
        //public virtual Usuario Usuario { get; set; }

	}
}
