using Microsoft.AspNetCore.Mvc;

namespace Projekt.Models
    {
        public interface IArtistService
        {
            public int Save(Artist? artist);

            public bool Delete(int? id);

            public bool Update(Artist? artist);

            public Artist? FindBy(int? id);

            public IEnumerable<Artist> FindAll();

        }
    }

