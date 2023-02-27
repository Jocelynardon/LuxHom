using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LuxHom.Models;

namespace LuxHom.Controllers
{
    public class PublicacionController : Controller
    {
        private readonly LuxHom1Context _context;

        public PublicacionController(LuxHom1Context context)
        {
            _context = context;
        }

        // GET: Publicacion
        public async Task<IActionResult> Index()
        {
              return _context.Publicacions != null ? 
                          View(await _context.Publicacions.ToListAsync()) :
                          Problem("Entity set 'LuxHom1Context.Publicacions'  is null.");
        }

        // GET: Publicacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Publicacions == null)
            {
                return NotFound();
            }

            var publicacion = await _context.Publicacions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publicacion == null)
            {
                return NotFound();
            }

            return View(publicacion);
        }

        // GET: Publicacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Publicacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion")] Publicacion publicacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publicacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(publicacion);
        }

        // GET: Publicacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Publicacions == null)
            {
                return NotFound();
            }

            var publicacion = await _context.Publicacions.FindAsync(id);
            if (publicacion == null)
            {
                return NotFound();
            }
            return View(publicacion);
        }

        // POST: Publicacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion")] Publicacion publicacion)
        {
            if (id != publicacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publicacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicacionExists(publicacion.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(publicacion);
        }

        // GET: Publicacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Publicacions == null)
            {
                return NotFound();
            }

            var publicacion = await _context.Publicacions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publicacion == null)
            {
                return NotFound();
            }

            return View(publicacion);
        }

        // POST: Publicacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Publicacions == null)
            {
                return Problem("Entity set 'LuxHom1Context.Publicacions'  is null.");
            }
            var publicacion = await _context.Publicacions.FindAsync(id);
            if (publicacion != null)
            {
                _context.Publicacions.Remove(publicacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublicacionExists(int id)
        {
          return (_context.Publicacions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
