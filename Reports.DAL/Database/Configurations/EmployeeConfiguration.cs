using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reports.DAL.Entities;

namespace Reports.DAL.Database.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(e => e.TypeOfEmployee).IsRequired();
            builder.Property(e => e.Name).IsRequired().HasMaxLength(30);
    
            builder
                .HasMany(e => e.Subordinates)
                .WithOne(e => e.Supervisor)
                .HasForeignKey(e => e.SupervisorId);
    
            builder
                .HasMany(e => e.Problems)
                .WithOne(p => p.Employee)
                .HasForeignKey(p => p.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}