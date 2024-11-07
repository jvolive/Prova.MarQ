using Prova.MarQ.Domain.Entities;

namespace Prova.MarQ.Domain.Interfaces.Helpers;

public interface IRegistrationHelper
{
    Task<int> GenerateRegistrationAsync(Employee employee);
}
