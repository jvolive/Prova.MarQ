using System.ComponentModel.DataAnnotations;

namespace Prova.MarQ.Domain.Entities;

public class Company : Base
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    [MaxLength(11)]
    public string Document { get; set; }
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    public bool IsDeleted { get; set; } = false;
}
