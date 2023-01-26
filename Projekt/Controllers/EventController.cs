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
    public class EventController : Controller
    {
        private readonly AppDbContext _context;

        public EventController(AppDbContext context)
        {
            _context = context;
        }
        // GET: EventController
        public async Task<IActionResult> Index()
        {
            return View(await _context.Events.ToListAsync());
        }

        // GET: EventController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }
            var _event = await _context.Events.FirstOrDefaultAsync(a => a.EventId == id);

            if (_event == null)
            {
                return NotFound();
            }
            return View(_event);
        }
        // GET: EventController/Details/5
        public async Task<IActionResult> DetailsUser(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }
            var _event = await _context.Events.FirstOrDefaultAsync(a => a.EventId == id);

            if (_event == null)
            {
                return NotFound();
            }
            return View(_event);
        }

        // GET: EventController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,EventName,Description,DateOfEvent,TypeOfEvent,TicketPrice,PlaceId")] Event Evente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Evente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Evente);
        }



        // GET: EventController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }
            var Evente = await _context.Events.FindAsync(id);

            if (Evente == null)
            {
                return NotFound();
            }
            return View(Evente);
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,EventName,Description,DateOfEvent,TypeOfEvent,TicketPrice,PlaceId")] Event _event)
        {
            if (id != _event.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(_event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(_event.EventId))
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
            return View(_event);
        }
           


        // GET: EventController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }
            var _event = await _context.Events.FirstOrDefaultAsync(a => a.EventId == id);
            if (_event == null)
            {
                return NotFound();
            }
            return View(_event);
        }

        // POST: EventController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Events == null)
            {
                return Problem("Entity Events is null");
            }
            var _event = await _context.Events.FindAsync(id);
            if (_event != null)
            {
                _context.Events.Remove(_event);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.EventId == id);
        }
    }
}
