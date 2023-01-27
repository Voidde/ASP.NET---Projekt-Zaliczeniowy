using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Models;

namespace xUnitTests
{
    internal class TestEventService : IEventService
    {
        private Dictionary<int,Event?> _events;
        private int counter = 1;
        private int UniqId()
        {
            return counter++;
        }

        public TestEventService()
        {
            _events = new Dictionary<int, Event?>();
        }
        public bool Delete(int? id)
        {
            if (id == null) return false;
            return _events.Remove(id ?? 1);
        }

        public IEnumerable<Event> FindAll()
        {
            return _events.Values;
        }

        public Event? FindBy(int? id)
        {
            if(id == null) return null;
            return _events.TryGetValue(id??1,out var @event) ? @event : null;
        }

        public Event? Save(Event? @event)
        {
            @event.EventId = UniqId();
            _events.Add(@event.EventId, @event);
            return @event;

        }

        public bool Update(Event? @event)
        {
            if (_events.ContainsKey(@event.EventId))
            {
                _events[@event.EventId] = @event;
                return true;
            }
            return false;

        }
    }
}
