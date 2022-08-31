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
        private SignInManager<AppUser> _signInManager;
        private EmployeeRepository _employeeRepository;
        private AccountRepository _accountRepository;
        private RoleManager<IdentityRole> _identityRole;

        public UnitOfWork(AppDbContext context,UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> identityRole)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _identityRole = identityRole;
        }
        public IEmployeeRepository EmployeeRepository => _employeeRepository ?? new EmployeeRepository(_context);

        public IAccountRepository<AppUser> AccountRepository => _accountRepository ?? new AccountRepository(_userManager,_identityRole, _signInManager);

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
