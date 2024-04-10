#nullable disable

namespace ShoppingSystem.Product.Domain.Contracts;

public abstract class FullBaseEntity<TId> : IDeletableEntity, IAuditableEntity
{
    public TId Id { get; set; }

    public DateTime? ModifiedAt { get; set; }
    public long? ModifiedByUserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public long? CreatedByUserId { get; set; }
    public DateTime? DeletedAt { get; set; }
    public long? DeletedByUserId { get; set; }
    public bool IsDeleted
    {
        get
        {
            if (DeletedAt is not null && DeletedAt != DateTime.MinValue)
                return true;
            else
                return false;
        }
    }

}
