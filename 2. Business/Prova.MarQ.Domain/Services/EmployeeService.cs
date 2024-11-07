using Prova.MarQ.Domain.Entities;
using Prova.MarQ.Domain.Interfaces.Helpers;
using Prova.MarQ.Domain.Repositories.Interfaces;
using Prova.MarQ.Domain.Services.Interfaces;

namespace Prova.MarQ.Domain.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IPinHelper _pinHelper;
    private readonly IRegistrationHelper _registrationHelper;

    public EmployeeService(IEmployeeRepository employeeRepository, IPinHelper pinHelper, IRegistrationHelper registrationHelper)
    {
        _employeeRepository = employeeRepository;
        _pinHelper = pinHelper;
        _registrationHelper = registrationHelper;
    }

    public async Task AddAsync(Employee entity)
    {
        if (await _employeeRepository.ExistsByDocumentAsync(entity.Document))
        {
            throw new InvalidOperationException("Funcionário com este documento já existe.");
        }

        if (string.IsNullOrWhiteSpace(entity.Pin))
        {
            throw new InvalidOperationException("O PIN é obrigatório para o cadastro do Funcionário.");
        }

        (entity.PinHash, entity.PinSalt) = _pinHelper.HashPin(entity.Pin);
        entity.Pin = null;
        entity.Registration = await _registrationHelper.GenerateRegistrationAsync(entity);
        entity.CreatedAt = DateTimeOffset.UtcNow;
        await _employeeRepository.AddAsync(entity);
    }

    public async Task UpdateAsync(Employee entity)
    {
        var existingEmployee = await _employeeRepository.GetByDocumentAsync(entity.Document);
        if (existingEmployee != null && existingEmployee.Id != entity.Id)
        {
            throw new InvalidOperationException("Já existe um funcionário com este documento.");
        }

        entity.UpdatedAt = DateTimeOffset.UtcNow;
        await _employeeRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);
        if (employee == null || employee.IsDeleted)
        {
            throw new KeyNotFoundException("Funcionário não encontrado.");
        }

        employee.IsDeleted = true;
        await _employeeRepository.UpdateAsync(employee);
    }

    public Task<bool> VerifyEmployeePinAsync(Employee employee, string pin)
    {
        return Task.FromResult(_pinHelper.VerifyPin(employee.PinHash, employee.PinSalt, pin));
    }
}
