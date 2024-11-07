using Microsoft.EntityFrameworkCore;
using Prova.MarQ.Domain.Entities;

namespace Prova.MarQ.Infra;

public class MarqDbContext : DbContext
{
    public MarqDbContext(DbContextOptions<MarqDbContext> options) : base(options)
    {
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<TimeRecord> TimeRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>()
            .Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<Employee>()
            .Property(e => e.Document)
            .HasMaxLength(11)
            .IsRequired();

        modelBuilder.Entity<Employee>()
            .Property(e => e.Registration)
            .IsRequired();

        modelBuilder.Entity<Employee>()
            .Property(e => e.Pin)
            .HasMaxLength(4)
            .IsRequired();


        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Company)
            .WithMany(c => c.Employees)
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<Employee>()
            .HasMany(e => e.TimeRecords)
            .WithOne(t => t.Employee)
            .HasForeignKey(t => t.EmployeeRegistration)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Company>()
            .Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<Company>()
            .Property(c => c.Document)
            .HasMaxLength(11)
            .IsRequired();

        modelBuilder.Entity<TimeRecord>()
            .Property(t => t.EntryTime)
            .IsRequired();

        modelBuilder.Entity<TimeRecord>()
            .Property(t => t.ExitTime)
            .IsRequired();

        modelBuilder.Entity<TimeRecord>()
            .Property(t => t.WorkedHours)
            .IsRequired();

        modelBuilder.Entity<TimeRecord>()
            .Property(t => t.OvertimeHours)
            .IsRequired();

        modelBuilder.Entity<TimeRecord>()
            .Property(t => t.TotalHours)
            .IsRequired();

        modelBuilder.Entity<Employee>()
            .HasQueryFilter(e => !e.IsDeleted);

        modelBuilder.Entity<Company>()
            .HasQueryFilter(c => !c.IsDeleted);

        modelBuilder.Entity<TimeRecord>()
            .HasQueryFilter(t => !t.IsDeleted);

        modelBuilder.Entity<TimeRecord>()
            .HasOne(tr => tr.Employee)
            .WithMany(e => e.TimeRecords)
            .HasForeignKey(tr => tr.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}