using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LuxHom.Models;
using Microsoft.AspNetCore.Authorization;

namespace LuxHom.Controllers
{
    public class PedidoController : Controller
    {
        private readonly LuxHom1Context _context;

        public PedidoController(LuxHom1Context context)
        {
            _context = context;
        }

        [Authorize]
        // GET: Pedidoes
        public async Task<IActionResult> Index()
        {
            var pedidos = await Functions.APIService.PedidoGetList();
            return View(pedidos.ToList());
        }

        // GET: Pedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Persona)
                .Include(p => p.Producto)
                .FirstOrDefaultAsync(m => m.Correlativo == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidoes/Create
        public IActionResult Create()
        {
            ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "Id");
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Id");
            return View();
        }

        // POST: Pedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Correlativo,PersonaId,ProductoId,Cantidad,FechaPedido")] LuxHom.Models.Pedido pedido)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(pedido);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "Id", pedido.PersonaId);
            //ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Id", pedido.ProductoId);
            //return View(pedido);
            var pedidos = await Functions.APIService.PedidoSet(pedido);
            return RedirectToAction(nameof(Index));
        }

        // GET: Pedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "Id", pedido.PersonaId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Id", pedido.ProductoId);
            return View(pedido);
        }

        // POST: Pedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Correlativo,PersonaId,ProductoId,Cantidad,FechaPedido")] LuxHom.Models.Pedido pedido)
        {
            //if (id != pedido.Correlativo)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(pedido);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!PedidoExists(pedido.Correlativo))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "Id", pedido.PersonaId);
            //ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Id", pedido.ProductoId);
            //return View(pedido);
            var pedidos = await Functions.APIService.PedidoUpdate(pedido);
            return RedirectToAction(nameof(Index));
        }

        // GET: Pedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Persona)
                .Include(p => p.Producto)
                .FirstOrDefaultAsync(m => m.Correlativo == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedidos = await Functions.APIService.PedidoDelete(Convert.ToInt32(id));
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return (_context.Pedidos?.Any(e => e.Correlativo == id)).GetValueOrDefault();
        }
    }
}
