using Projekt.Controllers;
using Projekt.Models;
using Microsoft.AspNetCore.Mvc;
using Assert = Xunit.Assert;
  

namespace xUnitTests
{
    public class Tests
    {
        private IEventService service = new TestEventService();
        private EventsController controller;
        
        public Tests()
        {
            controller = new EventsController(service, null);
            service.Save(new Event { EventId = 1, EventName = "Noc z Szotem!", Description = "Ca³onocna zabawa z Szotem!", TypeOfEvent = "Koncert", DateOfEvent = new DateTime(2023, 2, 1, 18, 30, 0), TicketPrice = 40, PlaceId = 3 });
            service.Save(new Event { EventId = 2, EventName = "Romeo i Julia", Description = "Spektakl teatralny ", TypeOfEvent = "Teatr", DateOfEvent = new DateTime(2023, 4, 12, 12, 0, 0), TicketPrice = 30, PlaceId = 1 });
            service.Save(new Event { EventId = 3, EventName = "Opera", Description = "Opera", TypeOfEvent = "Opera", DateOfEvent = new DateTime(2023, 5, 14, 15, 0, 0), TicketPrice = 50, PlaceId = 2 });
            service.Save(new Event { EventId = 4, EventName = "Coœ tam", Description = "Coœ tam", TypeOfEvent = "Coœ tam", DateOfEvent = new DateTime(2024, 5, 14, 15, 0, 0), TicketPrice = 150, PlaceId = 3 });

        }
        [Xunit.Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void TestEventsControllerGet(int id)
        {
            Event createdEvent = new Event() { EventName = "Test", Description = "Test", DateOfEvent = new DateTime(2023, 2, 1, 18, 30, 0), TypeOfEvent = "Test", PlaceId = 2, TicketPrice = 420 };
            var task = controller.GetEvent(id);
            ActionResult<Event> actionResult =Assert.IsType<ActionResult<Event>>(task);
            Event @event =Assert.IsType<Event>(actionResult.Value);
            Assert.Equal(@event.EventId, service.FindBy(@event.EventId).EventId);
        }
        [Fact]
        public void TestEventsControllerDelete() 
        {
            Event createdEvent = new Event() { EventName = "Test", Description = "Test", DateOfEvent = new DateTime(2023, 2, 1, 18, 30, 0), TypeOfEvent = "Test", PlaceId = 2, TicketPrice = 420 };
            var task = controller.DeleteEvent(1);
            NoContentResult noContentResult = Assert.IsType<NoContentResult>(task);
            var @event = service.FindBy(1);
            Assert.Null(@event);
        }
        [Fact]
        public void TestEventsControllerGetAll() 
        {
            var task = controller.GetEvents();
            var result = Assert.IsType<ActionResult<IEnumerable<Event>>>(task);
            var events = Assert.IsAssignableFrom<IEnumerable<Event>>(result.Value);
            Assert.Equal(4,events.Count());
        }
        [Fact]
        public void TestEventsControllerPost() 
        {
            Event createdEvent = new Event() {EventId = 1, EventName = "Test", Description = "Test", DateOfEvent = new DateTime(2023, 2, 1, 18, 30, 0), TypeOfEvent = "Test", PlaceId = 2, TicketPrice = 420 };
            var task = controller.PostEvent(createdEvent);
            Assert.NotNull(service.FindBy(createdEvent.EventId));
        }



    }
}