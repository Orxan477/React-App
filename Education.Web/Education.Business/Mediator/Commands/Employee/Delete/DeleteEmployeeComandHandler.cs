using AutoMapper;
using Education.Business.Interfaces.Employee;
using Education.Business.ViewModels.Employee;
using Education.Core.Interfaces;
using MediatR;

namespace Education.Business.Mediator.Commands.Employee.Delete
{
    public class DeleteEmployeeComandHandler : IRequestHandler<DeleteEmployeeComand, EmployeeVM>
    {
        private IEmployeeService _employeeService;
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public DeleteEmployeeComandHandler(IEmployeeService employeeService, AutoMapper.IMapper mapper,IUnitOfWork unitOfWork)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<EmployeeVM> Handle(DeleteEmployeeComand request, CancellationToken cancellationToken)
        {
            Core.Entities.Employee employee = await _employeeService.Get(request.Id);
            employee.IsDeleted = true;
            //duzeldecem
            await _unitOfWork.SaveChangeAsync();
            //await _employeeService.Delete(employee);
            EmployeeVM employeeVM = _mapper.Map<EmployeeVM>(employee);
            return employeeVM;
        }
    }
}
