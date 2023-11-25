using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SOA_ProyectoUTP.DTOs;
using SOA_ProyectoUTP.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace SOA_ProyectoUTP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly UDEMYContext _context;

        public CursosController(UDEMYContext context)
        {
            _context = context;
        }
        [HttpGet("CursosPopulares/{id_categoria}")]
        [SwaggerOperation(Summary = "Servicio Lista de Cursos Populares", Description = "Se mostrará el top 10 de cursos con mayor adquisición dentro del último trimestre.\u200b\r\n\r\nSe mostrarán solo cursos activos.\u200b")]
        [SwaggerResponse(200, "OK", typeof(IEnumerable<CursoDTO>))]
        [SwaggerResponse(404, "No encontrado")]
        public async Task<ActionResult<IEnumerable<CursoDTO>>> obtenerListaCursosPopulares(int id_categoria)
        {

			var clista = await _context.Cursos
				.Where(c => c.Estado == "ACTIVO" && (c.IdSubcategorias == id_categoria || c.IdCategorias == id_categoria))
				.OrderByDescending(c => c.Adquisiciones) 
				.Take(10)
				//.Include(c => c.Instructor)
				//	.ThenInclude(i => i.Usuario)
				.ToListAsync();

			if (clista == null || clista.Count == 0)
	        {
		        return NotFound();
	        }


	        var categoriasDto = clista.Select(c => new CursoDTO
			{
		        id_curso = c.Id,
		        curso = c.Curso1,
                calificacion = c.Calificacion,
                    precio=c.Precio,
                    descuento = 0,
                    introduccion = c.Introduccion,
                    fecha_actualizacion = c.FechaActualizacion,
                    imagen = c.Imagen, 
                    instructor_nombre = null
					//instructor_nombre = c.Instructor != null ? $"{c.Instructor.IdUsuario} {c.Instructor.Usuario.Apellidos}" : null

			}).ToList();

	        return categoriasDto;
        }


        [HttpGet("CursosXSubCategoria/{id_categoria}")]
        [SwaggerOperation(Summary = "Lista de Cursos x Subcategoría\u200b\r\n", Description = "Se mostrará el top 10 de cursos con mayor calificación , más reciente, más vendido en general de la subcategoría seleccionada.\u200b\r\n\r\nSe mostrarán solo cursos activos.")]
        [SwaggerResponse(200, "OK", typeof(IEnumerable<CursoDTO>))]
        [SwaggerResponse(404, "No encontrado")]
        public async Task<ActionResult<IEnumerable<CursoDTO>>> obtenerListaCursosXSubCategoria(int id_categoria)
        {

	        var clista = await _context.Cursos
		        .Where(c => c.Estado == "ACTIVO" && (c.IdSubcategorias == id_categoria ))
		        .OrderByDescending(c => c.Calificacion)
		        .ThenByDescending(c => c.FechaActualizacion) 
		        .ThenByDescending(c => c.nro_venta)
		        .Take(10)
		        //.Include(c => c.Instructor)
		        //	.ThenInclude(i => i.Usuario)
		        .ToListAsync();

	        if (clista == null || clista.Count == 0)
	        {
		        return NotFound();
	        }


	        var categoriasDto = clista.Select(c => new CursoDTO
	        {
		        id_curso = c.Id,
		        curso = c.Curso1,
		        calificacion = c.Calificacion,
		        precio = c.Precio,
		        descuento = 0,
		        introduccion = c.Introduccion,
		        fecha_actualizacion = c.FechaActualizacion,
		        imagen = c.Imagen,
		        instructor_nombre = null
		        //instructor_nombre = c.Instructor != null ? $"{c.Instructor.IdUsuario} {c.Instructor.Usuario.Apellidos}" : null

	        }).ToList();

	        return categoriasDto;
        }


        [HttpGet("CursosNuevos/{id_categoria}")]
        [SwaggerOperation(Summary = "Lista de Cursos x Subcategoría\u200b\r\n", Description = "Se mostrará el top 20 de nuevos cursos relacionados la categoría seleccionada.\u200b\r\n\r\nSe mostrarán solo categorías activas.\u200b")]
        [SwaggerResponse(200, "OK", typeof(IEnumerable<CursoDTO>))]
        [SwaggerResponse(404, "No encontrado")]
        public async Task<ActionResult<IEnumerable<CursoDTO>>> obtenerListaCursosNuevos(int id_categoria)
        {

	        var clista = await _context.Cursos
		        .Where(c => c.Estado == "ACTIVO" && (c.IdCategorias == id_categoria))
		        .OrderByDescending(c => c.FechaActualizacion)
		        .Take(20)
		        //.Include(c => c.Instructor)
		        //	.ThenInclude(i => i.Usuario)
		        .ToListAsync();

	        if (clista == null || clista.Count == 0)
	        {
		        return NotFound();
	        }


	        var categoriasDto = clista.Select(c => new CursoDTO
	        {
		        id_curso = c.Id,
		        curso = c.Curso1,
		        calificacion = c.Calificacion,
		        precio = c.Precio,
		        descuento = 0,
		        introduccion = c.Introduccion,
		        fecha_actualizacion = c.FechaActualizacion,
		        imagen = c.Imagen,
		        instructor_nombre = null
		        //instructor_nombre = c.Instructor != null ? $"{c.Instructor.IdUsuario} {c.Instructor.Usuario.Apellidos}" : null

	        }).ToList();

	        return categoriasDto;
        }

   

		// GET: api/Cursos




		//[HttpGet]
		//      public async Task<ActionResult<IEnumerable<Curso>>> GetCursos()
		//      {
		//        if (_context.Cursos == null)
		//        {
		//            return NotFound();
		//        }
		//          return await _context.Cursos.ToListAsync();
		//      }

		//      // GET: api/Cursos/5
		//      [HttpGet("{id}")]
		//      public async Task<ActionResult<Curso>> GetCurso(int id)
		//      {
		//        if (_context.Cursos == null)
		//        {
		//            return NotFound();
		//        }
		//          var curso = await _context.Cursos.FindAsync(id);

		//          if (curso == null)
		//          {
		//              return NotFound();
		//          }

		//          return curso;
		//      }

		//      // PUT: api/Cursos/5
		//      // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		//      [HttpPut("{id}")]
		//      public async Task<IActionResult> PutCurso(int id, Curso curso)
		//      {
		//          if (id != curso.Id)
		//          {
		//              return BadRequest();
		//          }

		//          _context.Entry(curso).State = EntityState.Modified;

		//          try
		//          {
		//              await _context.SaveChangesAsync();
		//          }
		//          catch (DbUpdateConcurrencyException)
		//          {
		//              if (!CursoExists(id))
		//              {
		//                  return NotFound();
		//              }
		//              else
		//              {
		//                  throw;
		//              }
		//          }

		//          return NoContent();
		//      }

		//      // POST: api/Cursos
		//      // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		//      [HttpPost]
		//      public async Task<ActionResult<Curso>> PostCurso(Curso curso)
		//      {
		//        if (_context.Cursos == null)
		//        {
		//            return Problem("Entity set 'UDEMYContext.Cursos'  is null.");
		//        }
		//          _context.Cursos.Add(curso);
		//          try
		//          {
		//              await _context.SaveChangesAsync();
		//          }
		//          catch (DbUpdateException)
		//          {
		//              if (CursoExists(curso.Id))
		//              {
		//                  return Conflict();
		//              }
		//              else
		//              {
		//                  throw;
		//              }
		//          }

		//          return CreatedAtAction("GetCurso", new { id = curso.Id }, curso);
		//      }

		//      // DELETE: api/Cursos/5
		//      [HttpDelete("{id}")]
		//      public async Task<IActionResult> DeleteCurso(int id)
		//      {
		//          if (_context.Cursos == null)
		//          {
		//              return NotFound();
		//          }
		//          var curso = await _context.Cursos.FindAsync(id);
		//          if (curso == null)
		//          {
		//              return NotFound();
		//          }

		//          _context.Cursos.Remove(curso);
		//          await _context.SaveChangesAsync();

		//          return NoContent();
		//      }

		//      private bool CursoExists(int id)
		//      {
		//          return (_context.Cursos?.Any(e => e.Id == id)).GetValueOrDefault();
		//      }
	}
}
