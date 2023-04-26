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
    public class PedidosController : Controller
    {
        private readonly LuxHom1Context _context;

        public PedidosController(LuxHom1Context context)
        {
            _context = context;
        }

        // GET: Pedidos
        [Route("GetList")]
        [HttpPost]
        public async Task<IEnumerable<LuxHomAPI.Models.Pedido>> GetList() /*Evita bloqueos, agiliza las respuesta*/
        {
            //LuxHom1Context _moviesContext = new MoviesContext();
            IEnumerable<LuxHomAPI.Models.Pedido> pedidos = await _context.Pedidos.Select(s =>
            new LuxHomAPI.Models.Pedido
            {
                Correlativo = s.Correlativo,
                PersonaId = s.PersonaId,
                ProductoId = s.ProductoId,
                Cantidad = s.Cantidad,
                FechaPedido = s.FechaPedido
            }
            ).ToListAsync();
            return pedidos;
        }

        // GET: Pedidoes/Create
        [Route("Set")]
        [HttpPost]
        public async Task<LuxHomModel.GeneralResult> Set(LuxHomAPI.Models.Pedido pedido)
        {
            LuxHomModel.GeneralResult generalResult = new LuxHomModel.GeneralResult
            {
                Result = false
            };
            try
            {
                Models.Pedido pedido1 = new Models.Pedido
                {
                    Correlativo = pedido.Correlativo,
                    PersonaId = pedido.PersonaId,
                    ProductoId = pedido.ProductoId,
                    Cantidad = pedido.Cantidad,
                    FechaPedido = pedido.FechaPedido
                };
                _context.Pedidos.Add(pedido1);
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
        public async Task<LuxHomModel.GeneralResult> Update(LuxHomAPI.Models.Pedido pedido)
        {
            LuxHomModel.GeneralResult generalResult = new LuxHomModel.GeneralResult
            {
                Result = false
            };
            try
            {
                Models.Pedido pedido1 = new Models.Pedido
                {
                    Correlativo = pedido.Correlativo,
                    PersonaId = pedido.PersonaId,
                    ProductoId = pedido.ProductoId,
                    Cantidad = pedido.Cantidad,
                    FechaPedido = pedido.FechaPedido
                };
                _context.Pedidos.Update(pedido1);
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

        // POST: Pedidoes/Delete/5
        [Route("Delete")]
        [HttpPost]
        public async Task<LuxHomModel.GeneralResult> Delete([FromBody] int correlativo)
        {
            LuxHomModel.GeneralResult generalResult = new LuxHomModel.GeneralResult
            {
                Result = false
            };
            try
            {
                LuxHomAPI.Models.Pedido pedido = await _context.Pedidos.Select(s =>
                new LuxHomAPI.Models.Pedido
                {
                    Correlativo = s.Correlativo,
                    PersonaId = s.PersonaId,
                    ProductoId = s.ProductoId,
                    Cantidad = s.Cantidad,
                    FechaPedido = s.FechaPedido
                }
                ).FirstOrDefaultAsync(s => s.Correlativo == correlativo);
                _context.Pedidos.Remove(pedido);
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

        private bool PedidoExists(int id)
        {
            return (_context.Pedidos?.Any(e => e.Correlativo == id)).GetValueOrDefault();
        }
    }
}
