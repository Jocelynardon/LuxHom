using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LuxHomAPI.Models;

namespace LuxHomAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PublicacionesController : Controller
    {
        private readonly LuxHom1Context _context;

        public PublicacionesController(LuxHom1Context context)
        {
            _context = context;
        }

        [Route("GetList")]
        [HttpPost]
        public async Task<IEnumerable<LuxHomAPI.Models.Publicacion>> GetList() /*Evita bloqueos, agiliza las respuesta*/
        {
            //LuxHom1Context _moviesContext = new MoviesContext();
            IEnumerable<LuxHomAPI.Models.Publicacion> publicaciones = await _context.Publicacions.Select(s =>
            new LuxHomAPI.Models.Publicacion
            {
                Id = s.Id,
                Nombre = s.Nombre,
                Descripcion = s.Descripcion
            }
            ).ToListAsync();
            return publicaciones;
        }

        [Route("Set")]
        [HttpPost]
        public async Task<LuxHomModel.GeneralResult> Set(LuxHomAPI.Models.Publicacion publicacion)
        {
            LuxHomModel.GeneralResult generalResult = new LuxHomModel.GeneralResult
            {
                Result = false
            };
            try
            {
                Models.Publicacion publicacion1 = new Models.Publicacion
                {
                    Id = publicacion.Id,
                    Nombre = publicacion.Nombre,
                    Descripcion = publicacion.Descripcion
                };

                _context.Publicacions.Add(publicacion1);
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
        public async Task<LuxHomModel.GeneralResult> Update(LuxHomAPI.Models.Publicacion publicacion)
        {
            LuxHomModel.GeneralResult generalResult = new LuxHomModel.GeneralResult
            {
                Result = false
            };
            try
            {
                Models.Publicacion publicacion1 = new Models.Publicacion
                {
                    Id = publicacion.Id,
                    Nombre = publicacion.Nombre,
                    Descripcion = publicacion.Descripcion
                };

                _context.Publicacions.Update(publicacion1);
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
                LuxHomAPI.Models.Publicacion publicacion = await _context.Publicacions.Select(s =>
                new LuxHomAPI.Models.Publicacion
                {
                    Id = s.Id,
                    Nombre = s.Nombre,
                    Descripcion = s.Descripcion
                }
                ).FirstOrDefaultAsync(s => s.Id == id);
                _context.Publicacions.Remove(publicacion);
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
