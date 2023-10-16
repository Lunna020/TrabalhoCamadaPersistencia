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
    public class TutoresController : Controller
    {
        private readonly Contexto _context;

        public TutoresController(Contexto context)
        {
            _context = context;
        }

        // GET: Tutores
        public async Task<IActionResult> Index()
        {
              return View(await _context.Tutores.ToListAsync());
        }

        // GET: Tutores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tutores == null)
            {
                return NotFound();
            }

            var tutor = await _context.Tutores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tutor == null)
            {
                return NotFound();
            }

            return View(tutor);
        }

        // GET: Tutores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tutores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,cpf,cidade,telefone,estado")] Tutor tutor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tutor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tutor);
        }

        // GET: Tutores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tutores == null)
            {
                return NotFound();
            }

            var tutor = await _context.Tutores.FindAsync(id);
            if (tutor == null)
            {
                return NotFound();
            }
            return View(tutor);
        }

        // POST: Tutores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,cpf,cidade,telefone,estado")] Tutor tutor)
        {
            if (id != tutor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tutor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TutorExists(tutor.Id))
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
            return View(tutor);
        }

        // GET: Tutores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tutores == null)
            {
                return NotFound();
            }

            var tutor = await _context.Tutores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tutor == null)
            {
                return NotFound();
            }

            return View(tutor);
        }

        // POST: Tutores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tutores == null)
            {
                return Problem("Entity set 'Contexto.Tutores'  is null.");
            }
            var tutor = await _context.Tutores.FindAsync(id);
            if (tutor != null)
            {
                _context.Tutores.Remove(tutor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TutorExists(int id)
        {
          return _context.Tutores.Any(e => e.Id == id);
        }
    }
}
