namespace Education.Core.Interfaces
{
    public interface IAccountRepository<TEntity>
    {
        Task<bool> Register(TEntity entity,string password);
        Task<bool> Login(TEntity entity);
    }
}
