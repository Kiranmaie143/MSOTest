using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSOTestSolution.Data;
using MSOTestSolution.Models;

namespace MSOTestSolution.Controllers
{
    public class CockpitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CockpitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cockpits
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cockpits.ToListAsync());
        }

        // GET: Cockpits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cockpit = await _context.Cockpits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cockpit == null)
            {
                return NotFound();
            }

            return View(cockpit);
        }

        // GET: Cockpits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cockpits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Responsible,Date,Description,Progress,Status")] Cockpit cockpit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cockpit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cockpit);
        }

        // GET: Cockpits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cockpit = await _context.Cockpits.FindAsync(id);
            if (cockpit == null)
            {
                return NotFound();
            }
            return View(cockpit);
        }

        // POST: Cockpits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Responsible,Date,Description,Progress,Status")] Cockpit cockpit)
        {
            if (id != cockpit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cockpit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CockpitExists(cockpit.Id))
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
            return View(cockpit);
        }

        // GET: Cockpits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cockpit = await _context.Cockpits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cockpit == null)
            {
                return NotFound();
            }

            return View(cockpit);
        }

        // POST: Cockpits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cockpit = await _context.Cockpits.FindAsync(id);
            if (cockpit != null)
            {
                _context.Cockpits.Remove(cockpit);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CockpitExists(int id)
        {
            return _context.Cockpits.Any(e => e.Id == id);
        }
    }
}
