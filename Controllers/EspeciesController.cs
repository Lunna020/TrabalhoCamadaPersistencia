﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabalhoCamadaPersistencia.Models;

namespace TrabalhoCamadaPersistencia.Controllers
{
    public class EspeciesController : Controller
    {
        private readonly Contexto _context;

        public EspeciesController(Contexto context)
        {
            _context = context;
        }

        // GET: Especies
        public async Task<IActionResult> Index()
        {
              return View(await _context.Especies.ToListAsync());
        }

        // GET: Especies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Especies == null)
            {
                return NotFound();
            }

            var especie = await _context.Especies
                .FirstOrDefaultAsync(m => m.id == id);
            if (especie == null)
            {
                return NotFound();
            }

            return View(especie);
        }

        // GET: Especies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Especies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,descricao")] Especie especie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especie);
        }

        // GET: Especies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Especies == null)
            {
                return NotFound();
            }

            var especie = await _context.Especies.FindAsync(id);
            if (especie == null)
            {
                return NotFound();
            }
            return View(especie);
        }

        // POST: Especies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,descricao")] Especie especie)
        {
            if (id != especie.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecieExists(especie.id))
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
            return View(especie);
        }

        // GET: Especies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Especies == null)
            {
                return NotFound();
            }

            var especie = await _context.Especies
                .FirstOrDefaultAsync(m => m.id == id);
            if (especie == null)
            {
                return NotFound();
            }

            return View(especie);
        }

        // POST: Especies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Especies == null)
            {
                return Problem("Entity set 'Contexto.Especies'  is null.");
            }
            var especie = await _context.Especies.FindAsync(id);
            if (especie != null)
            {
                _context.Especies.Remove(especie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspecieExists(int id)
        {
          return _context.Especies.Any(e => e.id == id);
        }
    }
}
