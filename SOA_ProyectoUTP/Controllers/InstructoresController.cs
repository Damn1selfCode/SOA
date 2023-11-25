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
    public class InstructoresController : ControllerBase
    {
        private readonly UDEMYContext _context;

        public InstructoresController(UDEMYContext context)
        {
            _context = context;
        }

        [HttpPost("registro/instructor")]
        [SwaggerOperation(Summary = "Registro de Instructor", Description = "Registra un instructor.")]
        [SwaggerResponse(200, "OK", typeof(bool))]
        [SwaggerResponse(409, "Conflicto")]
        public async Task<ActionResult<bool>> ConversionAInstructor(string correo_electronico)
        {
	        if (_context.Instructores == null)
	        {
		        return Problem("Entity set 'UDEMYContext.Instructor' is null.");
	        }


		        Usuario usuario = _context.Usuarios.FirstOrDefault(e => e.Correo == correo_electronico);

		        if (InstructoreExists(usuario.Id))
		        {
			        return Problem("El usuario ya es instructor");
				}
		        else
		        {
			        var instructor = new Instructore(usuario.Id);

					_context.Instructores.Add(instructor);
					return true;
		        }
		        try
		        {
			        await _context.SaveChangesAsync();
			        return true;
		        }
		        catch (DbUpdateException)
		        {
			        return false;

		        }
		}


		//// GET: api/Instructores
		//[HttpGet]
  //      public async Task<ActionResult<IEnumerable<Instructore>>> GetInstructores()
  //      {
  //        if (_context.Instructores == null)
  //        {
  //            return NotFound();
  //        }
  //          return await _context.Instructores.ToListAsync();
  //      }

  //      // GET: api/Instructores/5
  //      [HttpGet("{id}")]
  //      public async Task<ActionResult<Instructore>> GetInstructore(int id)
  //      {
  //        if (_context.Instructores == null)
  //        {
  //            return NotFound();
  //        }
  //          var instructore = await _context.Instructores.FindAsync(id);

  //          if (instructore == null)
  //          {
  //              return NotFound();
  //          }

  //          return instructore;
  //      }

  //      // PUT: api/Instructores/5
  //      // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  //      [HttpPut("{id}")]
  //      public async Task<IActionResult> PutInstructore(int id, Instructore instructore)
  //      {
  //          if (id != instructore.Id)
  //          {
  //              return BadRequest();
  //          }

  //          _context.Entry(instructore).State = EntityState.Modified;

  //          try
  //          {
  //              await _context.SaveChangesAsync();
  //          }
  //          catch (DbUpdateConcurrencyException)
  //          {
  //              if (!InstructoreExists(id))
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

  //      // POST: api/Instructores
  //      // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  //      [HttpPost]
  //      public async Task<ActionResult<Instructore>> PostInstructore(Instructore instructore)
  //      {
  //        if (_context.Instructores == null)
  //        {
  //            return Problem("Entity set 'UDEMYContext.Instructores'  is null.");
  //        }
  //          _context.Instructores.Add(instructore);
  //          try
  //          {
  //              await _context.SaveChangesAsync();
  //          }
  //          catch (DbUpdateException)
  //          {
  //              if (InstructoreExists(instructore.Id))
  //              {
  //                  return Conflict();
  //              }
  //              else
  //              {
  //                  throw;
  //              }
  //          }

  //          return CreatedAtAction("GetInstructore", new { id = instructore.Id }, instructore);
  //      }

  //      // DELETE: api/Instructores/5
  //      [HttpDelete("{id}")]
  //      public async Task<IActionResult> DeleteInstructore(int id)
  //      {
  //          if (_context.Instructores == null)
  //          {
  //              return NotFound();
  //          }
  //          var instructore = await _context.Instructores.FindAsync(id);
  //          if (instructore == null)
  //          {
  //              return NotFound();
  //          }

  //          _context.Instructores.Remove(instructore);
  //          await _context.SaveChangesAsync();

  //          return NoContent();
  //      }

        private bool InstructoreExists(int id)
        {
            return (_context.Instructores?.Any(e => e.Id == id)).GetValueOrDefault();
        }

	}
}
