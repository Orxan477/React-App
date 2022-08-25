using Education.Core.Entities;
using Education.Core.Interfaces;
using Education.Core.Interfaces.Employee;
using Education.Data.DAL;
using Education.Data.Implementations.Employee;
using Microsoft.AspNetCore.Identity;

namespace Education.Data.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context;
        private UserManager<AppUser> _userManager;
        private EmployeeRepository _employeeRepository;
        private AccountRepository _accountRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public IEmployeeRepository EmployeeRepository => _employeeRepository ?? new EmployeeRepository(_context);

        public IAccountRepository<AppUser> AccountRepository => _accountRepository ?? new AccountRepository(_userManager);

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
