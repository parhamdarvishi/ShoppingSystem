using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoppingSystem.Product.Infrastructure.Persistence.EntityConfigurations;

public class ProductConfig : IEntityTypeConfiguration<Domain.Entities.Product>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Product> builder)
    {
        //builder.ToTable(t => t.HasComment("information about system menus"));


    }
}
