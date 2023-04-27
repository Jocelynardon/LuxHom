using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LuxHom.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Authorization;

namespace LuxHom.Controllers
{
    public class PublicacionController : Controller
    {
        private readonly LuxHom1Context _context;

        public PublicacionController(LuxHom1Context context)
        {
            _context = context;
        }

        [Authorize]
        // GET: Publicacions
        public async Task<IActionResult> Index()
        {
            var publicaciones = await Functions.APIService.PublicacionGetList();
            return View(publicaciones.ToList());

        }

        [Authorize]
        // GET: Publicacions/Details/5
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

        [Authorize]
        // GET: Publicacions/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        // POST: Publicacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Contenido,Autor,FechaCreacion,FechaActualizacion,FechaInicio,FechaFin")] LuxHom.Models.Publicacion publicacion)
        {
            var publicaciones = await Functions.APIService.PublicacionSet(publicacion);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        // GET: Publicacions/Edit/5
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

        [Authorize]
        // POST: Publicacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Contenido,Autor,FechaCreacion,FechaActualizacion,FechaInicio,FechaFin")] LuxHom.Models.Publicacion publicacion)
        {
            var publicaciones = await Functions.APIService.PublicacionUpdate(publicacion);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        // GET: Publicacions/Delete/5
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

        [Authorize]
        // POST: Publicacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publicaciones = await Functions.APIService.PublicacionDelete(Convert.ToInt32(id));
            return RedirectToAction(nameof(Index));
        }

        private bool PublicacionExists(int id)
        {
            return (_context.Publicacions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
