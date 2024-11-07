namespace Prova.MarQ.Domain.Services.Interfaces;

public interface IService<T> where T : class
{
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
}