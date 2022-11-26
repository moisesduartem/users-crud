namespace UsersApi.Domain.Entities
{
    public abstract class Entity
    {
        public bool IsValid { get; protected set; } = true;
        public abstract void Validate();
    }
}
