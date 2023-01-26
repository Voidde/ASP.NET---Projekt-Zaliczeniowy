namespace Projekt.Models
{
    public interface ITicketService
    {
        public int Save(Ticket? artist);

        public bool Delete(int? id);

        public bool Update(Ticket? artist);

        public Ticket? FindBy(int? id);

        public IEnumerable<Ticket> FindAll();
    }
}
