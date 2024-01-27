namespace ShoppingSystem.Product.Domain.Contracts
{
    public interface IAuditableEntity : IEntity
    {
        public long? CreatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public long? ModifiedByUserId { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
