using System.ComponentModel.DataAnnotations;

namespace Prova.MarQ.Domain.Entities;

public class Company : Base
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    public string Document { get; set; }
    public bool IsDeleted { get; set; } = false;
}
