using Education.Core.Interfaces.Employee;

namespace Education.Core.Interfaces
{
    internal interface IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; }
        Task SaveChangeAsync();
    }
}
