using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LuxHomAPI.Models;
using Google.Protobuf.WellKnownTypes;

namespace LuxHomAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonasController : Controller
    {
        private readonly LuxHom1Context _context;

        public PersonasController(LuxHom1Context context)
        {
            _context = context;
        }

        // GET: Personas
        [Route("GetList")]
        [HttpPost]
        public async Task<IEnumerable<LuxHomAPI.Models.Persona>> GetList() /*Evita bloqueos, agiliza las respuesta*/
        {
            //LuxHom1Context _moviesContext = new MoviesContext();
            IEnumerable<LuxHomAPI.Models.Persona> personas = await _context.Personas.Select(s =>
            new LuxHomAPI.Models.Persona
            {
                Id = s.Id,
                Usuario = s.Usuario,
                Nombres = s.Nombres,
                Apellidos = s.Apellidos,
                FechaNacimiento = s.FechaNacimiento,
                Genero = s.Genero,
                Telefono = s.Telefono,
                Direccion = s.Direccion
            }
            ).ToListAsync();
            return personas;
        }

        [Route("Set")]
        [HttpPost]
        public async Task<LuxHomModel.GeneralResult> Set(LuxHomAPI.Models.Persona persona)
        {
            LuxHomModel.GeneralResult generalResult = new LuxHomModel.GeneralResult
            {
                Result = false
            };
            try
            {
                Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync();
                Models.Persona persona1 = new Models.Persona
                {
                    Id = persona.Id,
                    Usuario = persona.Usuario,
                    Nombres = persona.Nombres,
                    Apellidos = persona.Apellidos,
                    FechaNacimiento = persona.FechaNacimiento,
                    Genero = persona.Genero,
                    Telefono = persona.Telefono,
                    Direccion = persona.Direccion
                    //UsuarioNavigation = usuario
                };
                _context.Personas.Add(persona1);
                await _context.SaveChangesAsync();
                generalResult.Result = true;
            }
            catch (Exception ex)
            {
                generalResult.Result = false;
                generalResult.ErrorMessage = ex.Message;
            }
            return generalResult;
        }

        [Route("Update")]
        [HttpPost]
        public async Task<LuxHomModel.GeneralResult> Update(LuxHomAPI.Models.Persona persona)
        {
            LuxHomModel.GeneralResult generalResult = new LuxHomModel.GeneralResult
            {
                Result = false
            };
            try
            {
                Models.Persona persona1 = new Models.Persona
                {
                    Id = persona.Id,
                    Usuario = persona.Usuario,
                    Nombres = persona.Nombres,
                    Apellidos = persona.Apellidos,
                    FechaNacimiento = persona.FechaNacimiento,
                    Genero = persona.Genero,
                    Telefono = persona.Telefono,
                    Direccion = persona.Direccion
                };
                _context.Personas.Update(persona1);
                await _context.SaveChangesAsync();
                generalResult.Result = true;
            }
            catch (Exception ex)
            {
                generalResult.Result = false;
                generalResult.ErrorMessage = ex.Message;
            }
            return generalResult;
        }

        [Route("Delete")]
        [HttpPost]
        public async Task<LuxHomModel.GeneralResult> Delete([FromBody] int id)
        {
            LuxHomModel.GeneralResult generalResult = new LuxHomModel.GeneralResult
            {
                Result = false
            };
            try
            {
                LuxHomAPI.Models.Persona persona = await _context.Personas.Select(s =>
                new LuxHomAPI.Models.Persona
                {
                    Id = s.Id,
                    Usuario = s.Usuario,
                    Nombres = s.Nombres,
                    Apellidos = s.Apellidos,
                    FechaNacimiento = s.FechaNacimiento,
                    Genero = s.Genero,
                    Telefono = s.Telefono,
                    Direccion = s.Direccion
                }
                ).FirstOrDefaultAsync(s => s.Id == id);
                _context.Personas.Remove(persona);
                await _context.SaveChangesAsync();
                generalResult.Result = true;
            }
            catch (Exception ex)
            {
                generalResult.Result = false;
                generalResult.ErrorMessage = ex.Message;
            }
            return generalResult;
        }
    }
}
