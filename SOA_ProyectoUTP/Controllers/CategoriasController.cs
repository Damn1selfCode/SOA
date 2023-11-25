using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SOA_ProyectoUTP.Models;
using System.Linq;
using SOA_ProyectoUTP.DTOs;
using Swashbuckle.AspNetCore.Annotations;

namespace SOA_ProyectoUTP.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly UDEMYContext _context;

        public CategoriasController(UDEMYContext context)
        {
            _context = context;
        }

		//// GET: api/Categorias
		//[HttpGet]
		//public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
		//{
		//  if (_context.Categorias == null)
		//  {
		//      return NotFound();
		//  }
		//    return await _context.Categorias.ToListAsync();
		//}

		//// GET: api/Categorias/5
		//[HttpGet("{id}")]
		//public async Task<ActionResult<Categoria>> GetCategoria(int id)
		//{
		//  if (_context.Categorias == null)
		//  {
		//      return NotFound();
		//  }
		//    var categoria = await _context.Categorias.FindAsync(id);

		//    if (categoria == null)
		//    {
		//        return NotFound();
		//    }

		//    return categoria;
		//}

		/// <summary>
		/// Obtiene las categorías por ID superior.
		/// </summary>
		/// <param name="id_categoria">ID de la categoría superior.</param>
		/// <returns>Una lista de categorías.</returns>
		[HttpGet("ListadeCategorizacion/{id_categoria}")]
		[SwaggerOperation(Summary = "Obtener categorías por ID superior", Description = "Devuelve una lista de categorías filtradas por el ID superior.")]
		[SwaggerResponse(200, "OK", typeof(IEnumerable<CategoriaDTO>))]
		[SwaggerResponse(404, "No encontrado")]
		public async Task<ActionResult<IEnumerable<CategoriaDTO>>> obtenerCategorias(int id_categoria)
		{ 
			
			var categorias = await _context.Categorias
				.Where(c => c.Estado == "ACTIVA" && c.IdCategoria == id_categoria)
				.ToListAsync();

			if (categorias == null || categorias.Count == 0)
			{
				return NotFound();
			}

			var categoriasDto = categorias.Select(c => new CategoriaDTO
			{
				id_categoria = c.Id,
				descripcion = c.Descripcion
			}).ToList();

			return categoriasDto;
		}

		//// PUT: api/Categorias/5
		//// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		//[HttpPut("{id}")]
		//public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
		//{
		//    if (id != categoria.Id)
		//    {
		//        return BadRequest();
		//    }

		//    _context.Entry(categoria).State = EntityState.Modified;

		//    try
		//    {
		//        await _context.SaveChangesAsync();
		//    }
		//    catch (DbUpdateConcurrencyException)
		//    {
		//        if (!CategoriaExists(id))
		//        {
		//            return NotFound();
		//        }
		//        else
		//        {
		//            throw;
		//        }
		//    }

		//    return NoContent();
		//}

		//// POST: api/Categorias
		//// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		//[HttpPost]
		//public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
		//{
		//  if (_context.Categorias == null)
		//  {
		//      return Problem("Entity set 'UDEMYContext.Categorias'  is null.");
		//  }
		//    _context.Categorias.Add(categoria);
		//    try
		//    {
		//        await _context.SaveChangesAsync();
		//    }
		//    catch (DbUpdateException)
		//    {
		//        if (CategoriaExists(categoria.Id))
		//        {
		//            return Conflict();
		//        }
		//        else
		//        {
		//            throw;
		//        }
		//    }

		//    return CreatedAtAction("GetCategoria", new { id = categoria.Id }, categoria);
		//}

		//// DELETE: api/Categorias/5
		//[HttpDelete("{id}")]
		//public async Task<IActionResult> DeleteCategoria(int id)
		//{
		//    if (_context.Categorias == null)
		//    {
		//        return NotFound();
		//    }
		//    var categoria = await _context.Categorias.FindAsync(id);
		//    if (categoria == null)
		//    {
		//        return NotFound();
		//    }

		//    _context.Categorias.Remove(categoria);
		//    await _context.SaveChangesAsync();

		//    return NoContent();
		//}

		private bool CategoriaExists(int id)
        {
            return (_context.Categorias?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
