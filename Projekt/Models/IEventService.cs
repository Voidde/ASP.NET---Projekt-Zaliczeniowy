using Microsoft.AspNetCore.Mvc;
namespace Projekt.Models
{
    public interface IEventService
    {
        public int Save(Event? @event);

        public bool Delete(int? id);

        public bool Update(Event? @event);

        public Event? FindBy(int? id);

        public IEnumerable<Event> FindAll();

    }
}
