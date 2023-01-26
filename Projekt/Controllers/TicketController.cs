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
    public class TicketController : Controller
    {
        private readonly AppDbContext _context;
        public TicketController(AppDbContext context)
        {
            _context= context;
        }
        // GET: TicketController
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tickets.ToListAsync());
        }

        // GET: TicketController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tickets == null)
            {
                return NotFound();
            }
            var ticket = await _context.Tickets.FirstOrDefaultAsync(a => a.TicketId == id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // GET: TicketController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TicketController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketId,EventId,ClientId,TicketPrice")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: TicketController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
           if (id == null || _context.Tickets == null)
            {
                return NotFound();
            }
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: TicketController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TicketId,EventId,ClientId,TicketPrice")] Ticket ticket)
        {
            if (id != ticket.TicketId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.TicketId))
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
            return View(ticket);
        }

        // GET: TicketController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null || _context.Tickets == null)
            {
                return NotFound();
            }
            var ticket = await _context.Tickets.FirstOrDefaultAsync(a => a.TicketId == id);
            if(ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: TicketController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Tickets == null)
            {
                return Problem("Entity Tickets is empty");
            }
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); 
        }
        private bool TicketExists(int id)
        {
            return _context.Artists.Any(e => e.ArtistId == id);
        }
    }
}
