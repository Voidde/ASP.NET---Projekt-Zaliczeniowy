using Microsoft.EntityFrameworkCore;

namespace Projekt.Models
{
    public class PlaceServiceEF : IPlaceService
    {
        private readonly AppDbContext _context;
        public PlaceServiceEF(AppDbContext context)
        {
            _context = context;
        }
        public bool Delete(int? id)
        {
           if(id == null) return false;

            var find = _context.Places.Find(id);
            if (find is not null)
            {
                _context.Places.Remove(find);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Place> FindAll()
        {
            return _context.Places.ToList();
        }

        public Place? FindBy(int? id)
        {
            return id is null ? null : _context.Places.Find(id);
        }

        public int Save(Place place)
        {
            try
            {
                var entityEntry = _context.Places.Add(place);
                _context.SaveChanges();
                return entityEntry.Entity.PlaceId;
            }
            catch
            {
                return -1;
            }
        }

        public bool Update(Place? place)
        {
            try
            {
                var find = _context.Places.Find(place.PlaceId);
                if (find is not null)
                {
                    find.PlaceName = place.PlaceName;
                    find.PlaceDescription = place.PlaceDescription;
                    find.City = place.City;
                    find.Address = place.Address;
                    find.AddressNr = place.AddressNr;
                    find.PostalCode = place.PostalCode;
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
