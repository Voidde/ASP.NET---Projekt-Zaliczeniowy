using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Projekt.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Projekt.Models
{
    public class TicketServiceEF : ITicketService
    {
        private readonly AppDbContext _context;


        public TicketServiceEF(AppDbContext context)
        {
            _context = context;
        }

        public bool Delete(int? id)
        {
            if (id == null) return false;

            var find = _context.Tickets.Find(id);
            if (find is not null)
            {
                _context.Tickets.Remove(find);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Ticket> FindAll()
        {
            return _context.Tickets.ToList();
        }

        public Ticket? FindBy(int? id)
        {
            return id is null ? null : _context.Tickets.Find(id);
        }

        public int Save(Ticket ticket)
        {
            try
            {
                var entityEntry = _context.Tickets.Add(ticket);
                _context.SaveChanges();
                return entityEntry.Entity.TicketId;
            }
            catch
            {
                return -1;
            }
        }

        public bool Update(Ticket? ticket)
        {
            try
            {
                var find = _context.Tickets.Find(ticket.TicketId);
                if (find is not null)
                {
                    find.UserName = ticket.UserName;
                    find.TicketPrice = ticket.TicketPrice;
                    find.EventId = ticket.EventId;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
