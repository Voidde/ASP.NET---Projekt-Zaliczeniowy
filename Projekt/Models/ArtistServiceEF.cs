using Microsoft.EntityFrameworkCore;

namespace Projekt.Models
{
    public class ArtistServiceEF : IArtistService
    {
        private readonly AppDbContext _context;
        public ArtistServiceEF(AppDbContext context)
        {
            _context = context;
        }

        public bool Delete(int? id)
        {
            if (id is null)
            {
                return false;
            }
            var find = _context.Artists.Find(id);
            if (find is not null)
            {
                _context.Artists.Remove(find);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Artist> FindAll()
        {
            return _context.Artists.ToList();
        }

        public Artist? FindBy(int? id)
        {
            return id is null? null : _context.Artists.Find(id);
        }

        public int Save(Artist? artist)
        {
            try
            {
                var entityEntry = _context.Artists.Add(artist);
                _context.SaveChanges();
                return entityEntry.Entity.ArtistId;
            }
            catch
            {
                return -1;
            }
        }

        public bool Update(Artist artist)
        {
            try
            {
                var find = _context.Artists.Find(artist.ArtistId);
                if (find is not null)
                {
                    find.Name = artist.Name;
                    find.Surname = artist.Surname;
                    find.Nickname = artist.Nickname;
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
