namespace Prova.MarQ.Domain.Entities;

public class Company : Base
{
    public string Name { get; set; }
    public string Document { get; set; }
    public bool IsDeleted { get; set; } = false;
}
