namespace Education.Core.Interfaces
{
    public interface IAccountRepository<TEntity>
    {
        Task Register(TEntity entity,string password);
        Task Login(string email, string password);
        Task CreateRole(string role);
    }
}
