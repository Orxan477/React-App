using Education.Core.Interfaces;
using Education.Core.Interfaces.Employee;
using Education.Data.DAL;
using Education.Data.Implementations.Employee;

namespace Education.Data.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context;
        private EmployeeRepository _employeeRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public IEmployeeRepository EmployeeRepository => _employeeRepository ?? new EmployeeRepository(_context);

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
