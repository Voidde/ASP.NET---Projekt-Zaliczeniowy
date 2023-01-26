using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Projekt.Models;

namespace Projekt.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        public TicketController(AppDbContext context,ITicketService ticketService)
        {
            _ticketService= ticketService;
        }

        [Authorize(Roles = "Admin")]
        // GET: TicketController
        public IActionResult Index()
        {
            return View(_ticketService.FindAll());
        }
        [Authorize(Roles = "Admin")]
        // GET: TicketController/Details/5
        public IActionResult Details(int? id)
        {
            var ticket = _ticketService.FindBy(id);
            return ticket is null ? NotFound() : View(ticket);
        }
        [Authorize(Roles = "Admin")]
        // GET: TicketController/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        // POST: TicketController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("TicketId,EventId,UserName,TicketPrice")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _ticketService.Save(ticket);
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }
        [Authorize(Roles = "Admin")]
        // GET: TicketController/Edit/5
        public IActionResult Edit(int? id)
        {
            var ticket = _ticketService.FindBy(id);
            return ticket is null ? NotFound() : View(ticket);
        }
        [Authorize(Roles = "Admin")]
        // POST: TicketController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("TicketId,EventId,UserName,TicketPrice")] Ticket ticket)
        {
            if(ModelState.IsValid)
            {
                _ticketService.Update(ticket);
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }
        [Authorize(Roles = "Admin")]
        // GET: TicketController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ticket = _ticketService.FindBy(id);
            return ticket is null ? NotFound() : View(ticket);
        }
        [Authorize(Roles = "Admin")]
        // POST: TicketController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
           if (_ticketService.Delete(id))
            {
                return RedirectToAction(nameof(Index));
            }
            return Problem("This Ticket doesn't exist, can't delete");
        }

    }
}
