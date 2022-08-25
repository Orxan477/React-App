using Education.Core.Entities;
using Education.Core.Interfaces.Employee;

namespace Education.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; }
        public IAccountRepository<AppUser> AccountRepository { get; }
        Task SaveChangeAsync();
    }
}
