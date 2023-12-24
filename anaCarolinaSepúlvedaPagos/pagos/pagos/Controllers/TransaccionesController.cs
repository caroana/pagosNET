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
    public class TransaccionesController : Controller
    {
        private readonly PagosContext _context;

        public TransaccionesController(PagosContext context)
        {
            _context = context;
        }

        // GET: Transacciones
        public async Task<IActionResult> Index()
        {
            var pagosContext = _context.Transacciones.Include(t => t.CodigoComercioNavigation).Include(t => t.IdusuarioNavigation);
            return View(await pagosContext.ToListAsync());
        }

        // GET: Transacciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaccione = await _context.Transacciones
                .Include(t => t.CodigoComercioNavigation)
                .Include(t => t.IdusuarioNavigation)
                .FirstOrDefaultAsync(m => m.CodigoTransaccion == id);
            if (transaccione == null)
            {
                return NotFound();
            }

            return View(transaccione);
        }

        // GET: Transacciones/Create
        public IActionResult Create()
        {
            ViewData["CodigoComercio"] = new SelectList(_context.Comercios, "CodigoComercio", "CodigoComercio");
            ViewData["Idusuario"] = new SelectList(_context.Usuarios, "Idusuario", "Idusuario");
            return View();
        }

        // POST: Transacciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoTransaccion,CodigoComercio,Idusuario,MedioPago,EstadoTransaccion,Total,Fecha,Concepto")] Transaccione transaccione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaccione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoComercio"] = new SelectList(_context.Comercios, "CodigoComercio", "CodigoComercio", transaccione.CodigoComercio);
            ViewData["Idusuario"] = new SelectList(_context.Usuarios, "Idusuario", "Idusuario", transaccione.Idusuario);
            return View(transaccione);
        }

        // GET: Transacciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaccione = await _context.Transacciones.FindAsync(id);
            if (transaccione == null)
            {
                return NotFound();
            }
            ViewData["CodigoComercio"] = new SelectList(_context.Comercios, "CodigoComercio", "CodigoComercio", transaccione.CodigoComercio);
            ViewData["Idusuario"] = new SelectList(_context.Usuarios, "Idusuario", "Idusuario", transaccione.Idusuario);
            return View(transaccione);
        }

        // POST: Transacciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoTransaccion,CodigoComercio,Idusuario,MedioPago,EstadoTransaccion,Total,Fecha,Concepto")] Transaccione transaccione)
        {
            if (id != transaccione.CodigoTransaccion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaccione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransaccioneExists(transaccione.CodigoTransaccion))
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
            ViewData["CodigoComercio"] = new SelectList(_context.Comercios, "CodigoComercio", "CodigoComercio", transaccione.CodigoComercio);
            ViewData["Idusuario"] = new SelectList(_context.Usuarios, "Idusuario", "Idusuario", transaccione.Idusuario);
            return View(transaccione);
        }

        // GET: Transacciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaccione = await _context.Transacciones
                .Include(t => t.CodigoComercioNavigation)
                .Include(t => t.IdusuarioNavigation)
                .FirstOrDefaultAsync(m => m.CodigoTransaccion == id);
            if (transaccione == null)
            {
                return NotFound();
            }

            return View(transaccione);
        }

        // POST: Transacciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaccione = await _context.Transacciones.FindAsync(id);
            if (transaccione != null)
            {
                _context.Transacciones.Remove(transaccione);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransaccioneExists(int id)
        {
            return _context.Transacciones.Any(e => e.CodigoTransaccion == id);
        }
    }
}
