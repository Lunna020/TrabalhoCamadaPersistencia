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
    public class Racas1Controller : Controller
    {
        private readonly Contexto _context;

        public Racas1Controller(Contexto context)
        {
            _context = context;
        }

        // GET: Racas1
        public async Task<IActionResult> Index()
        {
              return View(await _context.Racas.ToListAsync());
        }

        // GET: Racas1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Racas == null)
            {
                return NotFound();
            }

            var racas1 = await _context.Racas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (racas1 == null)
            {
                return NotFound();
            }

            return View(racas1);
        }

        // GET: Racas1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Racas1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Raca")] Racas1 racas1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(racas1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(racas1);
        }

        // GET: Racas1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Racas == null)
            {
                return NotFound();
            }

            var racas1 = await _context.Racas.FindAsync(id);
            if (racas1 == null)
            {
                return NotFound();
            }
            return View(racas1);
        }

        // POST: Racas1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Raca")] Racas1 racas1)
        {
            if (id != racas1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(racas1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Racas1Exists(racas1.Id))
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
            return View(racas1);
        }

        // GET: Racas1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Racas == null)
            {
                return NotFound();
            }

            var racas1 = await _context.Racas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (racas1 == null)
            {
                return NotFound();
            }

            return View(racas1);
        }

        // POST: Racas1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Racas == null)
            {
                return Problem("Entity set 'Contexto.Racas'  is null.");
            }
            var racas1 = await _context.Racas.FindAsync(id);
            if (racas1 != null)
            {
                _context.Racas.Remove(racas1);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Racas1Exists(int id)
        {
          return _context.Racas.Any(e => e.Id == id);
        }
    }
}
