using AutoMapper;
using Education.Business.Mediator.Commands.Employee;
using Education.Business.ViewModels.Employee;
using Education.Core.Entities;

namespace Education.Business.Profiles
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Employee, EmployeeVM>().ForMember(x => x.Position, m => m.MapFrom(x => x.Position.Name));
            CreateMap<CreateEmployeeComand, Employee>();
        }
    }
}
