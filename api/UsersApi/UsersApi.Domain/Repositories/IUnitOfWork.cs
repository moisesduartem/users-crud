namespace UsersApi.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task Commit();
    }
}
