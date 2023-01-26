using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Projekt.Models;

namespace Projekt.Controllers
{
    public class PlaceController : Controller
    {
        private readonly AppDbContext _context;
        public PlaceController(AppDbContext context)
        {
            _context = context;
        }
        // GET: PlaceController
        public async Task<IActionResult> Index()
        {
            return View(await _context.Places.ToListAsync());
        }

        // GET: PlaceController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null || _context.Places == null)
            {
                return NotFound();
            }

            var place = await _context.Places
                .FirstOrDefaultAsync(m => m.PlaceId == id);
            if (place == null)
            {
                return NotFound();
            }

            return View(place);
        }

        // GET: PlaceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlaceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlaceId,PlaceName,City,PostalCode,Address,AddressNr,PlaceDescription")] Place place)
        {
            if (ModelState.IsValid)
            {
                _context.Add(place);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(place);
        }

        // GET: PlaceController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Places == null)
            {
                return NotFound();
            }

            var place = await _context.Places.FindAsync(id);
            if (place == null)
            {
                return NotFound();
            }
            return View(place);
        }

        // POST: PlaceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlaceName,City,PostalCode,Address,AddressNr,PlaceDescription")] Place place)
        {
            if (id != place.PlaceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(place);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaceExists(place.PlaceId))
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
            return View(place);
        }

        // GET: PlaceController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.Places == null)
            {
                return NotFound();
            }

            var place = await _context.Places
                .FirstOrDefaultAsync(m => m.PlaceId == id);
            if (place == null)
            {
                return NotFound();
            }

            return View(place);
        }

        // POST: PlaceController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfrimed(int id)
        {
            if (_context.Places == null)
            {
                return Problem("Entity set 'AppDbContext.Places'  is null.");
            }
            var place = await _context.Places.FindAsync(id);
            if (place != null)
            {
                _context.Places.Remove(place);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool PlaceExists(int id)
        {
            return _context.Places.Any(e => e.PlaceId == id);
        }
    }
}
