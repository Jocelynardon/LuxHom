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
    public class ArticuloPrefabricadosController : Controller
    {
        private readonly LuxHom1Context _context;
        public ArticuloPrefabricadosController(LuxHom1Context context)
        {
            _context = context;
        }

        [Route("GetList")]
        [HttpPost]
        public async Task<IEnumerable<LuxHomAPI.Models.ArticuloPrefabricado>> GetList() /*Evita bloqueos, agiliza las respuesta*/
        {
            //LuxHom1Context _moviesContext = new MoviesContext();
            IEnumerable<LuxHomAPI.Models.ArticuloPrefabricado> articuloPrefabricados = await _context.ArticuloPrefabricados.Select(s =>
            new LuxHomAPI.Models.ArticuloPrefabricado
            {
                Id = s.Id,
                Nombre = s.Nombre,
                Descripcion = s.Descripcion,
                Costo = s.Costo,
                Precio = s.Precio
            }
            ).ToListAsync();
            return articuloPrefabricados;
        }

        [Route("Set")]
        [HttpPost]
        public async Task<LuxHomModel.GeneralResult> Set(LuxHomAPI.Models.ArticuloPrefabricado articuloPrefabricado)
        {
            LuxHomModel.GeneralResult generalResult = new LuxHomModel.GeneralResult
            {
                Result = false
            };
            try
            {
                Models.ArticuloPrefabricado articuloPrefabricado1 = new Models.ArticuloPrefabricado
                {
                    Id = articuloPrefabricado.Id,
                    Nombre = articuloPrefabricado.Nombre,
                    Descripcion = articuloPrefabricado.Descripcion,
                    Costo = articuloPrefabricado.Costo,
                    Precio = articuloPrefabricado.Precio
                };

                _context.ArticuloPrefabricados.Add(articuloPrefabricado1);
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
        public async Task<LuxHomModel.GeneralResult> Update(LuxHomAPI.Models.ArticuloPrefabricado articuloPrefabricado)
        {
            LuxHomModel.GeneralResult generalResult = new LuxHomModel.GeneralResult
            {
                Result = false
            };
            try
            {
                Models.ArticuloPrefabricado articuloPrefabricado1 = new Models.ArticuloPrefabricado
                {
                    Id = articuloPrefabricado.Id,
                    Nombre = articuloPrefabricado.Nombre,
                    Descripcion = articuloPrefabricado.Descripcion,
                    Costo = articuloPrefabricado.Costo,
                    Precio = articuloPrefabricado.Precio
                };

                _context.ArticuloPrefabricados.Update(articuloPrefabricado1);
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
                LuxHomAPI.Models.ArticuloPrefabricado articuloPrefabricado = await _context.ArticuloPrefabricados.Select(s =>
                new LuxHomAPI.Models.ArticuloPrefabricado
                {
                    Id = s.Id,
                    Nombre = s.Nombre,
                    Descripcion = s.Descripcion,
                    Costo = s.Costo,
                    Precio = s.Precio
                }
                ).FirstOrDefaultAsync(s => s.Id == id);
                _context.ArticuloPrefabricados.Remove(articuloPrefabricado);
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
