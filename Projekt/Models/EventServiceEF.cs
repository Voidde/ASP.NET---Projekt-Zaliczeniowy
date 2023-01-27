﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Projekt.Models
{
    public class EventServiceEF : IEventService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<EventServiceEF> _logger;
        public EventServiceEF(AppDbContext context, ILogger<EventServiceEF> logger)
        {
            _context = context;
            _logger = logger;
        }
        public Event? Save(Event? @event)
        {
            try
            {
                var entityEntry = _context.Events.Add(@event);
                _context.SaveChanges();
                return entityEntry.Entity;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }
        public bool Delete(int? id)
        {
            if (id is null)
            {
                return false;
            }
            var find = _context.Events.Find(id);
            if (find is not null)
            {
                _context.Events.Remove(find);
                return true;
            }
            return false;
        }
        public bool Update(Event? @event)
        {
            try
            {
                var find = _context.Events.Find(@event.EventId);
                if (find is not null)
                {
                    find.EventName = @event.EventName;
                    find.DateOfEvent = @event.DateOfEvent;
                    find.TypeOfEvent = @event.TypeOfEvent;
                    find.TicketPrice = @event.TicketPrice;
                    find.Description = @event.Description;
                    find.PlaceId = @event.PlaceId;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public IEnumerable<Event> FindAll()
        {
            return _context.Events.ToList();
        }

        public Event? FindBy(int? id)
        {
            return id is null ? null : _context.Events.Find(id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }


    }
}
