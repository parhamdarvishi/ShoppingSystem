namespace ShoppingSystem.Product.Domain.Contracts
{
    internal interface IDeletableEntity : IEntity
    {
        public long? DeletedByUserId { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; }
    }
}
