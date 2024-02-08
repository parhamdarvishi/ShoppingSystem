using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ShoppingSystem.Product.Infrastructure.Persistence.Configurations;

internal class ProductConfig : IEntityTypeConfiguration<Domain.Entities.Product>
{
     const string TableName = "Products";
    public void Configure(EntityTypeBuilder<Domain.Entities.Product> builder)
    {
        builder.ToTable(t => t.HasComment($"This is {TableName} Table"));

        builder
            .HasKey(t => t.Id)
            .IsClustered()
            .HasName($"PK_{TableName}");

        builder
            .Property(t => t.Name)
            .HasMaxLength(300)
            .IsUnicode(true);

        builder
            .Property(t => t.Description)
            .HasMaxLength(1000)
            .IsUnicode(true);

        builder
            .Property(t => t.Price)
            .HasDefaultValue(0);
    }
}
