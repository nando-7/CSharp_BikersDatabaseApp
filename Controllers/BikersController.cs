using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp1.Data;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class BikersController : Controller
    {
        private readonly WebApp1Context _context;

        public BikersController(WebApp1Context context)
        {
            _context = context;
        }

        // GET: Bikers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bikers.ToListAsync());
        }

        // GET: Bikers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bikers = await _context.Bikers
                .SingleOrDefaultAsync(m => m.ID == id);
            if (bikers == null)
            {
                return NotFound();
            }

            return View(bikers);
        }

        // GET: Bikers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bikers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BikerName,BikerSponsor,BikerCarreerWinnings,BikerLink")] Bikers bikers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bikers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bikers);
        }

        // GET: Bikers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bikers = await _context.Bikers.SingleOrDefaultAsync(m => m.ID == id);
            if (bikers == null)
            {
                return NotFound();
            }
            return View(bikers);
        }

        // POST: Bikers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BikerName,BikerSponsor,BikerCarreerWinnings,BikerLink")] Bikers bikers)
        {
            if (id != bikers.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bikers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BikersExists(bikers.ID))
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
            return View(bikers);
        }

        // GET: Bikers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bikers = await _context.Bikers
                .SingleOrDefaultAsync(m => m.ID == id);
            if (bikers == null)
            {
                return NotFound();
            }

            return View(bikers);
        }

        // POST: Bikers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bikers = await _context.Bikers.SingleOrDefaultAsync(m => m.ID == id);
            _context.Bikers.Remove(bikers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BikersExists(int id)
        {
            return _context.Bikers.Any(e => e.ID == id);
        }
    }
}
