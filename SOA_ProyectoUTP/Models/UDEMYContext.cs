using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SQLitePCL;

namespace SOA_ProyectoUTP.Models
{
    public partial class UDEMYContext : DbContext
    {

        public UDEMYContext()
        {
        }

        public UDEMYContext(DbContextOptions<UDEMYContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; } = null!;
        public virtual DbSet<Compra> Compras { get; set; } = null!;
        public virtual DbSet<Cupone> Cupones { get; set; } = null!;
        public virtual DbSet<Curso> Cursos { get; set; } = null!;
        public virtual DbSet<CursosTema> CursosTemas { get; set; } = null!;
        public virtual DbSet<DetalleCompra> DetalleCompras { get; set; } = null!;
        public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<Filtro> Filtros { get; set; } = null!;
        public virtual DbSet<FiltrosDetalle> FiltrosDetalles { get; set; } = null!;
        public virtual DbSet<Instructore> Instructores { get; set; } = null!;
        public virtual DbSet<Lenguaje> Lenguajes { get; set; } = null!;
        public virtual DbSet<MetodoPago> MetodoPagos { get; set; } = null!;
        public virtual DbSet<Pagina> Paginas { get; set; } = null!;
        public virtual DbSet<PaginasHasUsuario> PaginasHasUsuarios { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RolesHasUsuario> RolesHasUsuarios { get; set; } = null!;
        public virtual DbSet<Suscripcione> Suscripciones { get; set; } = null!;
        public virtual DbSet<SuscripcionesHasUsuario> SuscripcionesHasUsuarios { get; set; } = null!;
        public virtual DbSet<Tarjeta> Tarjetas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<UsuariosHasMetodoPago> UsuariosHasMetodoPagos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DAMN\\MSSQLSERVER2019;Initial Catalog=UDEMY;User ID=sa;Password=sql;Integrated Security=False;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("CATEGORIAS");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.IdCategoria).HasColumnName("id_CATEGORIA");

                entity.Property(e => e.Nivel).HasColumnName("nivel");

                entity.Property(e => e.Orden).HasColumnName("orden");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.ToTable("COMPRAS");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Comprascol)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("COMPRAScol");

                entity.Property(e => e.Estado)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.IdUsuarioRegalo).HasColumnName("id_USUARIO_REGALO");

                entity.Property(e => e.PrecioFinal)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("precio_final");

                entity.Property(e => e.SuscripcionesId).HasColumnName("SUSCRIPCIONES_id");

                entity.Property(e => e.UsuariosId).HasColumnName("USUARIOS_id");
            });

            modelBuilder.Entity<Cupone>(entity =>
            {
                entity.ToTable("CUPONES");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Cupon)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("cupon");

                entity.Property(e => e.CursosId).HasColumnName("CURSOS_id");

                entity.Property(e => e.CursosIdInstructor).HasColumnName("CURSOS_id_INSTRUCTOR");

                entity.Property(e => e.Descuento)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("descuento");

                entity.Property(e => e.Estado)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.FechaActivacion)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("fecha_activacion");

                entity.Property(e => e.FechaExpiracion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_expiracion");

                entity.Property(e => e.NumCupones).HasColumnName("num_cupones");

                entity.Property(e => e.PrecioFinal)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("precio_final");

                entity.Property(e => e.TipoCupon)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("tipo_cupon");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.IdInstructor })
                    .HasName("PK__CURSOS__56CC1F792FDBEBD1");

                entity.ToTable("CURSOS");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdInstructor).HasColumnName("id_INSTRUCTOR");

                entity.Property(e => e.Calificacion)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("calificacion");

                entity.Property(e => e.Curso1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("curso");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Duracion)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("duracion");

                entity.Property(e => e.Estado)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_actualizacion");

                entity.Property(e => e.IdCategorias).HasColumnName("id_CATEGORIAS");

                entity.Property(e => e.IdSubcategorias).HasColumnName("id_SUBCATEGORIAS");

                entity.Property(e => e.Imagen).HasColumnName("imagen");

                entity.Property(e => e.Introduccion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("introduccion");

                entity.Property(e => e.Nivel)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nivel");

                entity.Property(e => e.NivelSubscripcion)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nivel_subscripcion");

                entity.Property(e => e.NroClases).HasColumnName("nro_clases");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("precio");

                entity.Property(e => e.Subtitulo)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("subtitulo");

                entity.Property(e => e.Url)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("url");

            });

            modelBuilder.Entity<CursosTema>(entity =>
            {
                entity.HasKey(e => new { e.CursosId, e.CursosIdInstructor, e.CategoriasId })
                    .HasName("PK__CURSOS_T__97DB66DFD54D62FD");

                entity.ToTable("CURSOS_TEMAS");

                entity.Property(e => e.CursosId).HasColumnName("CURSOS_id");

                entity.Property(e => e.CursosIdInstructor).HasColumnName("CURSOS_id_INSTRUCTOR");

                entity.Property(e => e.CategoriasId).HasColumnName("CATEGORIAS_id");
            });

            modelBuilder.Entity<DetalleCompra>(entity =>
            {
                entity.HasKey(e => new { e.ComprasId, e.CursosId, e.CursosIdInstructor })
                    .HasName("PK__DETALLE___1A2D10A1FF3F0A95");

                entity.ToTable("DETALLE_COMPRA");

                entity.Property(e => e.ComprasId).HasColumnName("COMPRAS_id");

                entity.Property(e => e.CursosId).HasColumnName("CURSOS_id");

                entity.Property(e => e.CursosIdInstructor).HasColumnName("CURSOS_id_INSTRUCTOR");

                entity.Property(e => e.CuponesId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CUPONES_id");

                entity.Property(e => e.Descuentos)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("descuentos");

                entity.Property(e => e.PrecioFinal)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("precio_final");
            });

            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DETALLE_FACTURA");

                entity.Property(e => e.FacturaId)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("FACTURA_id");

                entity.Property(e => e.FacturaIdMetodopago).HasColumnName("FACTURA_id_METODOPAGO");

                entity.Property(e => e.FacturaIdUsuario).HasColumnName("FACTURA_id_USUARIO");

                entity.Property(e => e.PrecioFinal)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("precio_final");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.IdMetodopago, e.Id })
                    .HasName("PK__FACTURA__DF9C6862E51FA00B");

                entity.ToTable("FACTURA");

                entity.Property(e => e.IdUsuario).HasColumnName("id_USUARIO");

                entity.Property(e => e.IdMetodopago).HasColumnName("id_METODOPAGO");

                entity.Property(e => e.Id)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.IdCompras).HasColumnName("id_COMPRAS");

                entity.Property(e => e.NumFactura)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("num_factura");
            });

            modelBuilder.Entity<Filtro>(entity =>
            {
                entity.ToTable("FILTROS");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Orden).HasColumnName("orden");
            });

            modelBuilder.Entity<FiltrosDetalle>(entity =>
            {
                entity.HasKey(e => new { e.IdFiltro, e.IdOrden })
                    .HasName("PK__FILTROS___EC9D0A954341B76E");

                entity.ToTable("FILTROS_DETALLE");

                entity.Property(e => e.IdFiltro).HasColumnName("id_FILTRO");

                entity.Property(e => e.IdOrden).HasColumnName("id_ORDEN");

                entity.Property(e => e.Opcion)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("opcion");
            });

            modelBuilder.Entity<Instructore>(entity =>
            {
                entity.ToTable("INSTRUCTORES");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Calificacion)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("calificacion");

                entity.Property(e => e.CantValoraciones).HasColumnName("cant_valoraciones");

                entity.Property(e => e.IdUsuario).HasColumnName("id_USUARIO");

                entity.Property(e => e.Imagen).HasColumnName("imagen");

                entity.Property(e => e.NroCursos).HasColumnName("nro_cursos");

                entity.Property(e => e.NroEstudiantes).HasColumnName("nro_estudiantes");

                entity.Property(e => e.Url)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<Lenguaje>(entity =>
            {
                entity.ToTable("LENGUAJES");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Lenguaje1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("lenguaje");
            });

            modelBuilder.Entity<MetodoPago>(entity =>
            {
                entity.ToTable("METODO_PAGOS");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Pagina>(entity =>
            {
                entity.ToTable("PAGINAS");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Pagina1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("pagina");
            });

            modelBuilder.Entity<PaginasHasUsuario>(entity =>
            {
                entity.HasKey(e => new { e.IdPagina, e.IdUsuario })
                    .HasName("PK__PAGINAS___D10F01D54CFA9B6E");

                entity.ToTable("PAGINAS_has_USUARIOS");

                entity.Property(e => e.IdPagina).HasColumnName("id_PAGINA");

                entity.Property(e => e.IdUsuario).HasColumnName("id_USUARIO");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLES");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Rol)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("rol");
            });

            modelBuilder.Entity<RolesHasUsuario>(entity =>
            {
                entity.HasKey(e => new { e.IdRol, e.IdUsuario })
                    .HasName("PK__ROLES_ha__058E1C755ED4B2D8");

                entity.ToTable("ROLES_has_USUARIOS");

                entity.Property(e => e.IdRol).HasColumnName("id_ROL");

                entity.Property(e => e.IdUsuario).HasColumnName("id_USUARIO");
            });

            modelBuilder.Entity<Suscripcione>(entity =>
            {
                entity.ToTable("SUSCRIPCIONES");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CorreoEmpresa)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("correo_empresa");

                entity.Property(e => e.Empresa)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("empresa");

                entity.Property(e => e.IdUsuario).HasColumnName("id_USUARIO");

                entity.Property(e => e.NroSubs)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nro_subs");

                entity.Property(e => e.NumContacto)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("num_contacto");

                entity.Property(e => e.Puesto)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("puesto");

                entity.Property(e => e.Subdominio)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("subdominio");
            });

            modelBuilder.Entity<SuscripcionesHasUsuario>(entity =>
            {
                entity.HasKey(e => new { e.SuscripcionesId, e.UsuariosId })
                    .HasName("PK__SUSCRIPC__0832DDB45876646E");

                entity.ToTable("SUSCRIPCIONES_has_USUARIOS");

                entity.Property(e => e.SuscripcionesId).HasColumnName("SUSCRIPCIONES_id");

                entity.Property(e => e.UsuariosId).HasColumnName("USUARIOS_id");

                entity.Property(e => e.Estado)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.FechaExpiracion)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("fecha_expiracion");

                entity.Property(e => e.FechaSubscripcion)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("fecha_subscripcion");
            });

            modelBuilder.Entity<Tarjeta>(entity =>
            {
                entity.ToTable("TARJETAS");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CodTarjeta)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("cod_tarjeta");

                entity.Property(e => e.FechaVencimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_vencimiento");

                entity.Property(e => e.MetodoPagosId).HasColumnName("METODO_PAGOS_id");

                entity.Property(e => e.NombreTarjeta)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre_tarjeta");

                entity.Property(e => e.NumTarjeta).HasColumnName("num_tarjeta");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("USUARIOS");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Clave)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("clave");

                entity.Property(e => e.Correo)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Estado)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.FechaCese)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_cese");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.IdLenguaje).HasColumnName("id_lenguaje");

                entity.Property(e => e.Imagen).HasColumnName("imagen");

                entity.Property(e => e.Introduccion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("introduccion");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombres");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("titulo");
            });

            modelBuilder.Entity<UsuariosHasMetodoPago>(entity =>
            {
                entity.HasKey(e => new { e.UsuariosId, e.MetodoPagosId })
                    .HasName("PK__USUARIOS__E1896C9406B01DFE");

                entity.ToTable("USUARIOS_has_METODO_PAGOS");

                entity.Property(e => e.UsuariosId).HasColumnName("USUARIOS_id");

                entity.Property(e => e.MetodoPagosId).HasColumnName("METODO_PAGOS_id");
            });


			OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
