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
    public class UsuariosController : Controller
    {
        private readonly LuxHom1Context _context;

        public UsuariosController(LuxHom1Context context)
        {
            _context = context;
        }

        // GET: Usuarios
        [Route("GetList")]
        [HttpPost]
        public async Task<IEnumerable<LuxHomAPI.Models.Usuario>> GetList() /*Evita bloqueos, agiliza las respuesta*/
        {
            //LuxHom1Context _moviesContext = new MoviesContext();
            IEnumerable<LuxHomAPI.Models.Usuario> usuarios = await _context.Usuarios.Select(s =>
            new LuxHomAPI.Models.Usuario
            {
                Usuario1 = s.Usuario1,
                Email = s.Email,
                Password = s.Password,
                FechaTransac = s.FechaTransac,
                UsuarioElimina = s.UsuarioElimina,
                FechaTransacElimina = s.FechaTransacElimina,
                Vigente = s.Vigente
            }
            ).ToListAsync();
            return usuarios;
        }

        [Route("Set")]
        [HttpPost]
        public async Task<LuxHomModel.GeneralResult> Set(LuxHomAPI.Models.Usuario usuario)
        {
            LuxHomModel.GeneralResult generalResult = new LuxHomModel.GeneralResult
            {
                Result = false
            };
            try
            {
                Models.Usuario usuario1 = new Models.Usuario
                {
                    Usuario1 = usuario.Usuario1,
                    Email = usuario.Email,
                    Password = usuario.Password,
                    FechaTransac = usuario.FechaTransac,
                    UsuarioElimina = null,
                    FechaTransacElimina = null,
                    Vigente = 1
                };
                _context.Usuarios.Add(usuario1);
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
        public async Task<LuxHomModel.GeneralResult> Update(LuxHomAPI.Models.Usuario usuario)
        {
            LuxHomModel.GeneralResult generalResult = new LuxHomModel.GeneralResult
            {
                Result = false
            };
            try
            {
                Models.Usuario usuario1 = new Models.Usuario
                {
                    Usuario1 = usuario.Usuario1,
                    Email = usuario.Email,
                    Password = usuario.Password,
                    FechaTransac = DateTime.Now,
                    UsuarioElimina = usuario.UsuarioElimina,
                    FechaTransacElimina = usuario.FechaTransacElimina,
                    Vigente = usuario.Vigente
                };
                _context.Usuarios.Update(usuario1);
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

        [Route("Check")]
        [HttpPost]
        public async Task<bool> Check([FromBody] LuxHomAPI.Models.Usuario usuario1)
        {
            LuxHomModel.GeneralResult generalResult = new LuxHomModel.GeneralResult
            {
                Result = false
            };
            try
            {
                LuxHomAPI.Models.Usuario usuario = await _context.Usuarios.Select(s =>
                new LuxHomAPI.Models.Usuario
                {
                    Usuario1 = s.Usuario1,
                    Email = s.Email,
                    Password = s.Password,
                    FechaTransac = s.FechaTransac,
                    UsuarioElimina = s.UsuarioElimina,
                    FechaTransacElimina = s.FechaTransacElimina,
                    Vigente = s.Vigente
                }
                ).FirstOrDefaultAsync(s => s.Usuario1 == usuario1.Usuario1 && s.Password == usuario1.Password);
                generalResult.Result = true;
            }
            catch (Exception ex)
            {
                generalResult.Result = false;
                generalResult.ErrorMessage = ex.Message;
            }
            return generalResult.Result;
        }

        [Route("Delete")]
        [HttpPost]
        public async Task<LuxHomModel.GeneralResult> Delete([FromBody] string usuario1)
        {
            LuxHomModel.GeneralResult generalResult = new LuxHomModel.GeneralResult
            {
                Result = false
            };
            try
            {
                LuxHomAPI.Models.Usuario usuario = await _context.Usuarios.Select(s =>
                new LuxHomAPI.Models.Usuario
                {
                    Usuario1 = s.Usuario1,
                    Email = s.Email,
                    Password = s.Password,
                    FechaTransac = s.FechaTransac,
                    UsuarioElimina = s.UsuarioElimina,
                    FechaTransacElimina = s.FechaTransacElimina,
                    Vigente = s.Vigente
                }
                ).FirstOrDefaultAsync(s => s.Usuario1 == usuario1);
                _context.Usuarios.Remove(usuario);
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
