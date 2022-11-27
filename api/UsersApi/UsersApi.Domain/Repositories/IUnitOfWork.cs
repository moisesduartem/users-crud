namespace UsersApi.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
