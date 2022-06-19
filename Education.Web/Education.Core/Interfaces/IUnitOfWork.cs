using Education.Core.Interfaces.Employee;

namespace Education.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; }
        Task SaveChangeAsync();
    }
}
