using AutoMapper;
using Reports.BLL.Extensions;
using Reports.BLL.Resources;
using Reports.DAL.Entities;

namespace Reports.BLL.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Employee, EmployeeResource>()
                .ForMember(src => src.TypeOfEmployee,
                    opt =>
                        opt.MapFrom(src => src.TypeOfEmployee.ToDescriptionString()));
            CreateMap<Problem, ProblemResource>()
                .ForMember(src => src.ProblemStatus,
                    opt =>
                        opt.MapFrom(src => src.ProblemStatus.ToDescriptionString()));

            CreateMap<Report, ReportResource>();
        }
    }
}