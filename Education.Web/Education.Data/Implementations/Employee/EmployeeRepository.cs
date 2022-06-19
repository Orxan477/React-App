using Education.Data.DAL;

namespace Education.Data.Implementations.Employee
{
    internal class EmployeeRepository : Repository<Core.Entities.Employee>, Core.Interfaces.Employee.IEmployeeRepository
    {
        private AppDbContext _context;
        public EmployeeRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
