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

    [Authorize(Roles = "Admin")]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(AppDbContext context,IEventService eventService)
        {
            _eventService= eventService;
        }
        [Authorize(Roles = "Admin")]
        // GET: EventController
        public IActionResult Index()
        {
            return View(_eventService.FindAll());
        }
        [Authorize(Roles = "Admin")]
        // GET: EventController/Details/5
        public IActionResult Details(int? id)
        {
            var @event = _eventService.FindBy(id);
            return @event is null ? NotFound() : View(@event);
        }
        [AllowAnonymous]
        [Authorize(Roles = "Admin,User")]
        // GET: EventController/Details/5
        public IActionResult DetailsUser(int? id)
        {
            var @event = _eventService.FindBy(id);
            return @event is null ? NotFound() : View(@event);
        }
        [Authorize(Roles = "Admin")]
        // GET: EventController/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        // POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("EventId,EventName,Description,DateOfEvent,TypeOfEvent,TicketPrice,PlaceId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _eventService.Save(@event);
                return RedirectToAction("Index");
            }
            return View(@event);
        }


        [Authorize(Roles = "Admin")]
        // GET: EventController/Edit/5
        public IActionResult Edit(int? id)
        {
            var @event = _eventService.FindBy(@id);
            return @event is null ? NotFound() : View(@event);
        }


        [Authorize(Roles = "Admin")]
        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("EventId,EventName,Description,DateOfEvent,TypeOfEvent,TicketPrice,PlaceId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _eventService.Update(@event);
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        [Authorize(Roles = "Admin")]
        // GET: EventController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var @event = _eventService.FindBy(id);
            return @event is null ? NotFound() : View(@event);
        }

        [Authorize(Roles = "Admin")]
        // POST: EventController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (_eventService.Delete(id))
            {
                return RedirectToAction(nameof(Index));
            }
            return Problem("Event doesn't exist,can't delete");
        }

    }
}
