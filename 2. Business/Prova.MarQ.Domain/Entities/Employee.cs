namespace Prova.MarQ.Domain.Entities;

public class Employee : Base
{
    public string Name { get; set; }
    public string Document { get; set; }
    public string PinHash { get; set; }
    public string PinSalt { get; set; }
    public bool IsDeleted { get; set; } = false;
}