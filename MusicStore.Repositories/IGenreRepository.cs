using MusicStore.Entities;

namespace MusicStore.Repositories
{
    public interface IGenreRepository
    {
        void Add(Genre genre);
        void Delete(int id);
        Genre? FindById(int id);
        List<Genre> List();
        void Update(int id, Genre genre);
    }
}