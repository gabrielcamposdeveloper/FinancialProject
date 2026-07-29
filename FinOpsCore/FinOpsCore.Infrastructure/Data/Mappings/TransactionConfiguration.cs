using FinOpsCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinOpsCore.Infrastructure.Data.Mappings;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transactions");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Description)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(t => t.Amount)
            .IsRequired().HasColumnType("decimal(18,2)");
  
        builder.Property(t => t.Status)
            .IsRequired()
            .HasConversion<int>(); 

        builder.Property(t => t.RowVersion)
            .IsRowVersion()
            .IsRequired();
    }
}