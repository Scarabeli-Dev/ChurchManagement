using Microsoft.EntityFrameworkCore;
using Shared.Repositories.Interfaces;

namespace Shared.Repositories;

public class GeneralRepository<TContext> : IGeneralRepository
        where TContext : DbContext
{
    protected readonly TContext _context;

    public GeneralRepository(TContext context)
    {
        _context = context;
    }

    public void Add<T>(T entity) where T : class
    {
        _context.Add(entity);
    }

    public void Update<T>(T entity) where T : class
    {
        _context.Update(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
        _context.Remove(entity);
    }

    public void DeleteRange<T>(T[] entityArray) where T : class
    {
        _context.RemoveRange(entityArray);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<T> GetByIdAsync<T>(Guid id) where T : class
    {
        var entity = await _context.FindAsync<T>(id);
        if (entity == null)
            throw new KeyNotFoundException($"Entity of type {typeof(T).Name} with ID {id} not found.");
        return entity;
    }


    public async Task<List<T>> GetAllAsync<T>() where T : class
    {
        return await _context.Set<T>().ToListAsync();
    }
}