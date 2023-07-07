using AutoMapper;
using EmployeeManagement.Client.Models;
using EmployeeManagement.Shared;

namespace EmployeeManagement.Client
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EditEmployeeModel>()
                .ForMember(dest => dest.ConfirmEmail, opt => opt.MapFrom(src => src.Email));


            CreateMap<EditEmployeeModel, Employee>();

        }
    }
}
