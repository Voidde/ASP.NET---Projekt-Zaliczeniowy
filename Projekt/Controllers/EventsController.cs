using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projekt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<Event> Get()
        {
            return _eventService.FindAll();
        }

        //GET: api/Events/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Event> Get(int id)
        {
            return _eventService.FindBy(id);
        }

        //POST: api/Events
        [HttpPost]
        public ActionResult Post([FromBody] Event @event)
        {
            _eventService.Save(@event);
            return Created("", @event);
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Event @event)
        {
            @event.EventId = (int)id;
            if (_eventService.Update(@event))
            {
                return BadRequest();
            }
            else
            {
                return NoContent();
            }

        }
        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
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
