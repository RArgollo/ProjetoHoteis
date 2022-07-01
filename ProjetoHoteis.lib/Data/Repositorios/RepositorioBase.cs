using Microsoft.EntityFrameworkCore;
using ProjetoHoteis.lib.Models;

namespace ProjetoHoteis.lib.Data.Repositorios
{
    public class RepositorioBase<T> where T : ModelBase
    {
        private readonly HoteisContext _context;
        private readonly DbSet<T> _dbset;
        public RepositorioBase(HoteisContext context, DbSet<T> dbset)
        {
            _context = context;
            _dbset = dbset;
        }

        public async Task<List<T>> BuscarTodosAsync()
        {
            return await _dbset.AsNoTracking().ToListAsync();
        }

        public async Task<T> BuscarPorIdAsync(int id)
        {
            return await _dbset.AsNoTracking().FirstAsync(x => x.Id == id);
        }

        public async Task AdicionarAsync(T item)
        {
            _dbset.AddAsync(item);
            _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(int id)
        {
            var item = await _dbset.FindAsync(id);
            _dbset.Remove(item);
            _context.SaveChangesAsync();
        }
    }
}