using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projekt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Projekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly AppDbContext _context;
        //GET: api/Events
        public EventsController(IEventService eventService,AppDbContext context)
        {
            _eventService= eventService;
            _context= context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Event>> GetEvents()
        {
            return new ActionResult<IEnumerable<Event>>(_eventService.FindAll());
        }

        //GET: api/Events/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Event> GetEvent(int id)
        {
            return _eventService.FindBy(id);
        }

        //POST: api/Events
        [HttpPost]
        public IActionResult PostEvent(Event @event)
        {
            if (_eventService == null)
            {
                return Problem("Entity Events is null");
            }
            if (ModelState.IsValid)
            {
                var saved = _eventService.Save(@event);
                return Created("",saved);
            }
            else
            {
                return BadRequest();
            }
            
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public IActionResult PutEvent(int id, Event @event)
        {
            if(id!= @event.EventId)
            {
                return BadRequest();
            }
            @event.EventId = id;
            _eventService.Update(@event);
            return NoContent();

        }
        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            if (_eventService == null)
            {
                return NotFound();
            }
            var result = _eventService.Delete(id);
            if (result == false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
