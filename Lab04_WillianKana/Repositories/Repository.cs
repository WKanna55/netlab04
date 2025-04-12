using Lab04_WillianKana.Data;
using Lab04_WillianKana.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Lab04_WillianKana.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<T>> GetAll() => await _context.Set<T>().ToListAsync();
    
    public async Task<T?> GetById(int id) => await _context.Set<T>().FindAsync(id);
    
    public async Task Add(T entity) => await _context.Set<T>().AddAsync(entity);

    public Task Update(T entity)
    { 
        _context.Set<T>().Update(entity);
        return Task.CompletedTask;
    }

    public async Task Delete(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
        }
    }

}