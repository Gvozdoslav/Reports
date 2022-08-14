using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reports.DAL.Entities;

namespace Reports.DAL.Database.Configurations
{
    public class ProblemConfiguration : IEntityTypeConfiguration<Problem>
    {
        public void Configure(EntityTypeBuilder<Problem> builder)
        {
            builder.ToTable("Problems");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.ProblemStatus).IsRequired();
            builder.Property(p => p.Touched).IsRequired();
            builder.Property(p => p.EmployeeId).IsRequired();
            builder.Property(p => p.CreationTime).IsRequired();
            builder.Property(p => p.LastChangingTime).IsRequired();
        }
    }
}