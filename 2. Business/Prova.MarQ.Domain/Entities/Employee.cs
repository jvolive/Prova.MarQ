using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prova.MarQ.Domain.Entities;

public class Employee : Base
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    [MaxLength(11)]
    public string Document { get; set; }
    [Required]
    [Range(1, 999)]
    public int Registration { get; set; }
    [Required]
    [MaxLength(4)]
    [NotMapped]
    public string Pin { get; set; }
    public string PinHash { get; set; }
    public string PinSalt { get; set; }
    public bool IsDeleted { get; set; } = false;
    public Guid CompanyId { get; set; }
    public Company Company { get; set; }
    public ICollection<TimeRecord> TimeRecords { get; set; }
}