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
    public class UsuarioController : Controller
    {
        private readonly LuxHom1Context _context;

        public UsuarioController(LuxHom1Context context)
        {
            _context = context;
        }

        [Authorize]
        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var usuarios = await Functions.APIService.UsuarioGetList();
            return View(usuarios.ToList());
        }

        [Authorize]
        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Usuario1 == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [Authorize]
        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Usuario1,Email,Password,FechaTransac,UsuarioElimina,FechaTransacElimina,Vigente")] LuxHom.Models.Usuario usuario)
        {
            var usuarios = await Functions.APIService.UsuarioSet(usuario);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [Authorize]
        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Usuario1,Email,Password,FechaTransac,UsuarioElimina,FechaTransacElimina,Vigente")] LuxHom.Models.Usuario usuario)
        {
            var usuarios = await Functions.APIService.UsuarioUpdate(usuario);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Usuario1 == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [Authorize]
        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string usuario1)
        {
            var usuarios = await Functions.APIService.UsuarioDelete(usuario1);
            return RedirectToAction(nameof(Index));
        }
    }
}
