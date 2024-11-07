namespace Prova.MarQ.API.DTOs;

public class EmployeeDTO
{
    public string Name { get; set; }
    public string Document { get; set; }
    public int Registration { get; set; }
    public string Pin { get; set; }
    public bool IsDeleted { get; set; }
    public Guid CompanyId { get; set; }
}