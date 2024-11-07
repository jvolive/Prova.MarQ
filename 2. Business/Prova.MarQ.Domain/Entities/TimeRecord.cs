namespace Prova.MarQ.Domain.Entities;

public class TimeRecord
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public DateTime EntryTime { get; set; }
    public DateTime ExitTime { get; set; }
    public DateTime Date { get; set; }
    public double WorkedHours { get; set; }
    public double OvertimeHours { get; set; }
    public double TotalHours { get; set; }
    public string PinUsed { get; set; }
    public bool IsDeleted { get; set; } = false;
}