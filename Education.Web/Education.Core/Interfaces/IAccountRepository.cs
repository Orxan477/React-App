namespace Education.Core.Interfaces
{
    public interface IAccountRepository<TEntity>
    {
        Task Register(TEntity entity);
        Task<bool> Login(TEntity entity);
        Task<string> CreateRole();
    }
}
