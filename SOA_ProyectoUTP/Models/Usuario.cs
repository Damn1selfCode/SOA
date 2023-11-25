using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MessagePack;

namespace SOA_ProyectoUTP.Models
{
    public partial class Usuario
    {
	    Random random = new Random();

	    public Usuario()
	    {

	    }
		public Usuario( string nombres, string apellidos, string correo, string clave)
		{
			Id = random.Next(100, 1000) ;
			Nombres = nombres;
			Apellidos = apellidos;
			Correo = correo;
			Clave = clave;
			FechaCreacion = DateTime.Now;
			Estado = "ACTIVO";
		}

		public int Id { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Clave { get; set; } = null!;
        public string? Titulo { get; set; }
        public string? Introduccion { get; set; }
        public byte[]? Imagen { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaCese { get; set; }
        public string Estado { get; set; } = null!;
        public int IdLenguaje { get; set; }

	}
}
