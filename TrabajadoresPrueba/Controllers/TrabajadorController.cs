using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrabajadoresPrueba.Data;
using TrabajadoresPrueba.Models;

namespace TrabajadoresPrueba.Controllers
{
    public class TrabajadorController : Controller
    {
        private readonly AppDbContext _context;

        public TrabajadorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Trabajador/
        public async Task<IActionResult> Index(string filtroSexo)
        {
            var trabajadores = from t in _context.Trabajadores
                               select t;

            if (!string.IsNullOrEmpty(filtroSexo))
            {
                trabajadores = trabajadores.Where(t => t.Sexo == filtroSexo);
            }

            ViewBag.FiltroSexo = filtroSexo;
            return View(await trabajadores.ToListAsync());
        }

        // GET: /Trabajador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Trabajador/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trabajador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trabajador);
        }

        // GET: /Trabajador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var trabajador = await _context.Trabajadores.FindAsync(id);
            if (trabajador == null)
                return NotFound();

            return View(trabajador);
        }

        // POST: /Trabajador/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Trabajador trabajador)
        {
            if (id != trabajador.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trabajador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Trabajadores.Any(t => t.Id == id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(trabajador);
        }

        // GET: /Trabajador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var trabajador = await _context.Trabajadores
                .FirstOrDefaultAsync(m => m.Id == id);

            if (trabajador == null)
                return NotFound();

            return View(trabajador);
        }

        // POST: /Trabajador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trabajador = await _context.Trabajadores.FindAsync(id);
            if (trabajador != null)
            {
                _context.Trabajadores.Remove(trabajador);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
