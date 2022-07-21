

using Education.Business.ViewModels.Employee;
using MediatR;

namespace Education.Business.Mediator.Commands.Employee
{
    internal class CreateEmployeeComandHandler : IRequestHandler<CreateEmployeeComand, CreateEmployeeVM>
    {
        public Task<CreateEmployeeVM> Handle(CreateEmployeeComand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
