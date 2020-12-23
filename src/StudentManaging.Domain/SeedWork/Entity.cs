namespace StudentManaging.Domain.SeedWork
{
    public abstract class Entity<T>
    {
        public T Id { get; protected set; }
    }
}
