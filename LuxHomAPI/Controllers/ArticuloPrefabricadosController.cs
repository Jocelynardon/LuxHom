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


        // GET: ArticuloPrefabricadoes
        //public async Task<IActionResult> Index()
        //{
        //    return _context.ArticuloPrefabricados != null ?
        //                View(await _context.ArticuloPrefabricados.ToListAsync()) :
        //                Problem("Entity set 'LuxHom1Context.ArticuloPrefabricados'  is null.");
        //}

        //// GET: ArticuloPrefabricadoes/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.ArticuloPrefabricados == null)
        //    {
        //        return NotFound();
        //    }

        //    var articuloPrefabricado = await _context.ArticuloPrefabricados
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (articuloPrefabricado == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(articuloPrefabricado);
        //}

        //// GET: ArticuloPrefabricadoes/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ArticuloPrefabricadoes/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Costo,Precio")] ArticuloPrefabricado articuloPrefabricado)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(articuloPrefabricado);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(articuloPrefabricado);
        //}

        //// GET: ArticuloPrefabricadoes/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.ArticuloPrefabricados == null)
        //    {
        //        return NotFound();
        //    }

        //    var articuloPrefabricado = await _context.ArticuloPrefabricados.FindAsync(id);
        //    if (articuloPrefabricado == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(articuloPrefabricado);
        //}

        //// POST: ArticuloPrefabricadoes/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Costo,Precio")] ArticuloPrefabricado articuloPrefabricado)
        //{
        //    if (id != articuloPrefabricado.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(articuloPrefabricado);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ArticuloPrefabricadoExists(articuloPrefabricado.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(articuloPrefabricado);
        //}

        //// GET: ArticuloPrefabricadoes/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.ArticuloPrefabricados == null)
        //    {
        //        return NotFound();
        //    }

        //    var articuloPrefabricado = await _context.ArticuloPrefabricados
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (articuloPrefabricado == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(articuloPrefabricado);
        //}

        //// POST: ArticuloPrefabricadoes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.ArticuloPrefabricados == null)
        //    {
        //        return Problem("Entity set 'LuxHom1Context.ArticuloPrefabricados'  is null.");
        //    }
        //    var articuloPrefabricado = await _context.ArticuloPrefabricados.FindAsync(id);
        //    if (articuloPrefabricado != null)
        //    {
        //        _context.ArticuloPrefabricados.Remove(articuloPrefabricado);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ArticuloPrefabricadoExists(int id)
        //{
        //    return (_context.ArticuloPrefabricados?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
