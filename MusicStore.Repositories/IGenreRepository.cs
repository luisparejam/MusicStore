using MusicStore.Entities;

namespace MusicStore.Repositories
{
    public interface IGenreRepository
    {
        Task<List<Genre>> List();
        Task<Genre?> FindById(int id);
        Task Add(Genre genre);
        Task Update(int id, Genre genre);
        Task Delete(int id);
    }
}