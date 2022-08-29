namespace Education.Core.Interfaces
{
    public interface IAccountRepository<TEntity>
    {
        Task Register(TEntity entity,string password);
        Task<bool> Login(TEntity entity);
    }
}
