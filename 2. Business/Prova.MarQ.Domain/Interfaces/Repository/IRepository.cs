namespace Prova.MarQ.Domain.Repositories.Interfaces;

public interface IRepositoryBase<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task<T> GetByNameAsync(string name);
    Task<T> GetByDocumentAsync(string document);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsByDocumentAsync(string document);
}
