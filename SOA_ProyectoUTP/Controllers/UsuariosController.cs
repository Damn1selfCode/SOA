using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp.Formats.Jpeg;
using SOA_ProyectoUTP.DTOs;
using SOA_ProyectoUTP.Models;
using Swashbuckle.AspNetCore.Annotations;
using Image = System.Drawing.Image;
using Size = SixLabors.ImageSharp.Size;

namespace SOA_ProyectoUTP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UDEMYContext _context;

        public UsuariosController(UDEMYContext context)
        {
            _context = context;
        }

		//// GET: api/Usuarios
		//[HttpGet]
		//public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
		//{
		//  if (_context.Usuarios == null)
		//  {
		//      return NotFound();
		//  }
		//    return await _context.Usuarios.ToListAsync();
		//}

		//// GET: api/Usuarios/5
		//[HttpGet("{id}")]
		//public async Task<ActionResult<Usuario>> GetUsuario(int id)
		//{
		//  if (_context.Usuarios == null)
		//  {
		//      return NotFound();
		//  }
		//    var usuario = await _context.Usuarios.FindAsync(id);

		//    if (usuario == null)
		//    {
		//        return NotFound();
		//    }

		//    return usuario;
		//}

		//// PUT: api/Usuarios/5
		//// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		//[HttpPut("{id}")]
		//public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
		//{
		//    if (id != usuario.Id)
		//    {
		//        return BadRequest();
		//    }

		//    _context.Entry(usuario).State = EntityState.Modified;

		//    try
		//    {
		//        await _context.SaveChangesAsync();
		//    }
		//    catch (DbUpdateConcurrencyException)
		//    {
		//        if (!UsuarioExists(usuario.Correo))
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

		[HttpPut("editar/fotoperfil")]
		[SwaggerOperation(Summary = "Servicio Editar Foto de Perfil",
			Description = "Edita la foto de perfil del usuario, redimensionándola a 1200x1200.",
			Tags = new[] { "Perfil" })]
		[SwaggerResponse(StatusCodes.Status200OK, "OK", Type = typeof(bool))]
		[SwaggerResponse(StatusCodes.Status400BadRequest, "Solicitud incorrecta")]
		[SwaggerResponse(StatusCodes.Status500InternalServerError, "Error interno del servidor")]
		public async Task<IActionResult> EditarFotoPerfil(IFormFile imagen, int idUsuario)
		{
			try
			{
				if (imagen == null || imagen.Length == 0)
				{
					return BadRequest("La imagen no fue proporcionada.");
				}

				byte[] imagenRedimensionada = RedimensionarImagen(imagen);

				var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Id == idUsuario);
				usuario.Imagen = imagenRedimensionada;

				await _context.SaveChangesAsync();

				return Ok(true);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, $"Error al editar la foto de perfil: {ex.Message}");
			}
		}

		[HttpPost("registro/correoelectronico")]
		[SwaggerOperation(Summary = "Registro de Correo Electrónico", Description = "Registra un nuevo usuario por correo electrónico.")]
		[SwaggerResponse(200, "OK", typeof(bool))]
		[SwaggerResponse(409, "Conflicto")]
		public async Task<ActionResult<bool>> RegistroCorreoElectronico(RegistroUsuarioDTO u)
		{
			if (_context.Usuarios == null)
			{
				return Problem("Entity set 'UDEMYContext.Usuarios' is null.");
			}

			if (UsuarioExists(u.correo))
			{
				return Problem("Usuario ya se registro.");
			}

			var usuario = new Usuario(u.nombre_completo, u.nombre_completo, u.correo, u.clave);

			_context.Usuarios.Add(usuario);
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
  //      POST: api/Usuarios
  //      To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		//[HttpPost]
  //      public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
  //      {
  //          if (_context.Usuarios == null)
  //          {
  //              return Problem("Entity set 'UDEMYContext.Usuarios'  is null.");
  //          }
  //          _context.Usuarios.Add(usuario);
  //          try
  //          {
  //              await _context.SaveChangesAsync();
  //          }
  //          catch (DbUpdateException)
  //          {
  //              if (UsuarioExists(usuario.Correo))
  //              {
  //                  return Conflict();
  //              }
  //              else
  //              {
  //                  throw;
  //              }
  //          }

  //          return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
  //      }

  //      DELETE: api/Usuarios/5
  //      [HttpDelete("{id}")]
  //      public async Task<IActionResult> DeleteUsuario(int id)
  //      {
  //          if (_context.Usuarios == null)
  //          {
  //              return NotFound();
  //          }
  //          var usuario = await _context.Usuarios.FindAsync(id);
  //          if (usuario == null)
  //          {
  //              return NotFound();
  //          }

  //          _context.Usuarios.Remove(usuario);
  //          await _context.SaveChangesAsync();

  //          return NoContent();
  //      }

        private bool UsuarioExists(String correo)
        {
            return (_context.Usuarios?.Any(e => e.Correo==correo)).GetValueOrDefault();
        }
        private byte[] RedimensionarImagen(IFormFile imagen)
        {
	        using (var stream = new MemoryStream())
	        {
		        // Copiar la imagen al flujo de memoria
		        imagen.CopyTo(stream);

		        // Cargar la imagen con ImageSharp
		        using (var image = SixLabors.ImageSharp.Image.Load(stream.GetBuffer()))
		        {
			        // Redimensionar la imagen
			        image.Mutate(x => x.Resize(new ResizeOptions
			        {
				        Size = new Size(1200, 1200),
				        Mode = ResizeMode.Max
			        }));

			        // Guardar la imagen redimensionada en un nuevo flujo de memoria
			        using (var resizedStream = new MemoryStream())
			        {
				        image.Save(resizedStream, new JpegEncoder());

				        // Devolver el array de bytes de la imagen redimensionada
				        return resizedStream.ToArray();
			        }
		        }
	        }
        }
	}
	
}
