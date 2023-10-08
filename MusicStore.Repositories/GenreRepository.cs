using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Genre>> List()
        {
            return await _context.Set<Genre>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Genre?> FindById(int id)
        {
            return await _context.Set<Genre>().FindAsync(id);
        }

        public async Task Add(Genre genre)
        {
            await _context.Set<Genre>().AddAsync(genre);
            await _context.SaveChangesAsync();
        }
        public async Task Update(int id, Genre genre)
        {
            var registro = await FindById(id);
            if (registro is not null)
            {
                registro.Name = genre.Name;
                registro.Status = genre.Status;

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"No se encontro el registro con el ID {id}");
            }
        }
        public async Task Delete(int id)
        {
            var registro = await FindById(id);
            if (registro is not null)
            {
                _context.Set<Genre>().Remove(registro);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("No se encontro el registro para eliminar!");
            }
        }
    }
}