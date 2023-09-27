using MusicStore.Entities;
using MusicStore.Persistence;

namespace MusicStore.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly MusicStoreDbContext _context;

        public GenreRepository(MusicStoreDbContext context)
        {
            _context = context;
        }

        public List<Genre> List()
        {
            return _context.Genres.ToList();
        }

        public Genre? FindById(int id)
        {
            return _context.Genres.Find(id);
        }

        public void Add(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
        public void Update(int id, Genre genre)
        {
            var registro = FindById(id);
            if (registro is not null)
            {
                registro.Name = genre.Name;
                registro.Status = genre.Status;

                _context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var registro = FindById(id);
            if (registro is not null)
            {
                _context.Genres.Remove(registro);
            }
            else
            {
                throw new InvalidOperationException("No se encontro el registro para eliminar!");
            }
        }
    }
}