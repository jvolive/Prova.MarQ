using Microsoft.EntityFrameworkCore;
using Prova.MarQ.Domain.Repositories.Interfaces;

namespace Prova.MarQ.Infra.Repositories;
public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{
    public readonly MarqDbContext _context;

    public RepositoryBase(MarqDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsByDocumentAsync(string document)
    {
        return await _context.Set<TEntity>().AnyAsync(e => EF.Property<string>(e, "Document") == document);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity> GetByDocumentAsync(string document)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(e => EF.Property<string>(e, "Document") == document);
    }

    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity> GetByNameAsync(string name)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(e => EF.Property<string>(e, "Name") == name);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }
}