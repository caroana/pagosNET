using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pagos.Models;

namespace pagos.Controllers
{
    public class ComerciosController : Controller
    {
        private readonly PagosContext _context;

        public ComerciosController(PagosContext context)
        {
            _context = context;
        }

        // GET: Comercios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Comercios.ToListAsync());
        }

        // GET: Comercios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comercio = await _context.Comercios
                .FirstOrDefaultAsync(m => m.CodigoComercio == id);
            if (comercio == null)
            {
                return NotFound();
            }

            return View(comercio);
        }

        // GET: Comercios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comercios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoComercio,Nombre,Nit,Direccion")] Comercio comercio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comercio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comercio);
        }

        // GET: Comercios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comercio = await _context.Comercios.FindAsync(id);
            if (comercio == null)
            {
                return NotFound();
            }
            return View(comercio);
        }

        // POST: Comercios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoComercio,Nombre,Nit,Direccion")] Comercio comercio)
        {
            if (id != comercio.CodigoComercio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comercio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComercioExists(comercio.CodigoComercio))
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
            return View(comercio);
        }

        // GET: Comercios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comercio = await _context.Comercios
                .FirstOrDefaultAsync(m => m.CodigoComercio == id);
            if (comercio == null)
            {
                return NotFound();
            }

            return View(comercio);
        }

        // POST: Comercios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comercio = await _context.Comercios.FindAsync(id);
            if (comercio != null)
            {
                _context.Comercios.Remove(comercio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComercioExists(int id)
        {
            return _context.Comercios.Any(e => e.CodigoComercio == id);
        }
    }
}
