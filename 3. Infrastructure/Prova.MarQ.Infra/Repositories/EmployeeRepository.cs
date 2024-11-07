using System.Security.Cryptography;
using System.Text;
using Prova.MarQ.Domain.Entities;
using Prova.MarQ.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Prova.MarQ.Infra.Helpers;

namespace Prova.MarQ.Infra.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly MarqDbContext _context;

    public EmployeeRepository(MarqDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Employee entity)
    {
        if (await ExistsByDocumentAsync(entity.Document))
        {
            throw new InvalidOperationException("Employee com este documento já existe.");
        }

        if (!string.IsNullOrWhiteSpace(entity.Pin))
        {
            (entity.PinHash, entity.PinSalt) = PinHelper.HashPin(entity.Pin);
            entity.Pin = null;
        }
        else
        {
            throw new InvalidOperationException("O PIN é obrigatório para o cadastro do Employee.");
        }

        await _context.Employees.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Employee entity)
    {
        var existingEmployee = await _context.Employees
            .FirstOrDefaultAsync(e => e.Id == entity.Id && !e.IsDeleted);
        if (existingEmployee == null)
        {
            throw new KeyNotFoundException("Employee não encontrado.");
        }

        existingEmployee.Name = entity.Name;
        existingEmployee.Document = entity.Document;
        existingEmployee.UpdatedAt = DateTimeOffset.UtcNow;

        _context.Employees.Update(existingEmployee);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string name)
    {
        var employee = await _context.Employees
            .FirstOrDefaultAsync(e => e.Name == name && !e.IsDeleted);
        if (employee == null)
        {
            throw new KeyNotFoundException("Employee não encontrado.");
        }

        employee.IsDeleted = true;
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _context.Employees
            .Where(e => !e.IsDeleted)
            .ToListAsync();
    }

    public async Task<Employee> GetByIdAsync(Guid id)
    {
        return await _context.Employees
            .FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
    }

    public async Task<Employee> GetByNameAsync(string name)
    {
        return await _context.Employees
            .FirstOrDefaultAsync(e => e.Name == name && !e.IsDeleted);
    }

    public async Task<Employee> GetByDocumentAsync(string document)
    {
        return await _context.Employees
            .FirstOrDefaultAsync(e => e.Document == document && !e.IsDeleted);
    }


    public async Task<bool> ExistsByDocumentAsync(string document)
    {
        return await _context.Employees.AnyAsync(e => e.Document == document && !e.IsDeleted);
    }

    public bool VerifyPin(Employee employee, string pin)
    {
        return PinHelper.VerifyPin(employee.PinHash, employee.PinSalt, pin);
    }
}
