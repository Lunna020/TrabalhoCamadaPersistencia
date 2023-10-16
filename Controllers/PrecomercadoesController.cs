using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabalhoCamadaPersistencia.Models;

namespace TrabalhoCamadaPersistencia.Controllers
{
    public class PrecomercadoesController : Controller
    {
        private readonly Contexto _context;

        public PrecomercadoesController(Contexto context)
        {
            _context = context;
        }

        // GET: Precomercadoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Precosmercado.ToListAsync());
        }

        // GET: Precomercadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Precosmercado == null)
            {
                return NotFound();
            }

            var precomercado = await _context.Precosmercado
                .FirstOrDefaultAsync(m => m.id == id);
            if (precomercado == null)
            {
                return NotFound();
            }

            return View(precomercado);
        }

        // GET: Precomercadoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Precomercadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,preco,animal")] Precomercado precomercado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(precomercado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(precomercado);
        }

        // GET: Precomercadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Precosmercado == null)
            {
                return NotFound();
            }

            var precomercado = await _context.Precosmercado.FindAsync(id);
            if (precomercado == null)
            {
                return NotFound();
            }
            return View(precomercado);
        }

        // POST: Precomercadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,preco,animal")] Precomercado precomercado)
        {
            if (id != precomercado.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(precomercado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrecomercadoExists(precomercado.id))
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
            return View(precomercado);
        }

        // GET: Precomercadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Precosmercado == null)
            {
                return NotFound();
            }

            var precomercado = await _context.Precosmercado
                .FirstOrDefaultAsync(m => m.id == id);
            if (precomercado == null)
            {
                return NotFound();
            }

            return View(precomercado);
        }

        // POST: Precomercadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Precosmercado == null)
            {
                return Problem("Entity set 'Contexto.Precosmercado'  is null.");
            }
            var precomercado = await _context.Precosmercado.FindAsync(id);
            if (precomercado != null)
            {
                _context.Precosmercado.Remove(precomercado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrecomercadoExists(int id)
        {
          return _context.Precosmercado.Any(e => e.id == id);
        }
    }
}
