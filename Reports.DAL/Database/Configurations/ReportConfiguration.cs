using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reports.DAL.Entities;

namespace Reports.DAL.Database.Configurations
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("Reports");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(r => r.Description).IsRequired();
            builder.Property(r => r.Name).IsRequired();
            builder.Property(r => r.EmployeeId).IsRequired();
            builder.Property(r => r.DateOfReport).IsRequired();
        }
    }
}