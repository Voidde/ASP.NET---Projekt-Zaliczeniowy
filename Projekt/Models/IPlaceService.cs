namespace Projekt.Models
{
    public interface IPlaceService
    {
        public int Save(Place? place);

        public bool Delete(int? id);

        public bool Update(Place? place);

        public Place? FindBy(int? id);

        public IEnumerable<Place> FindAll();
    }
}
