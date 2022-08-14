using System;
using AutoMapper;
using Reports.BLL.Resources;
using Reports.DAL.Entities;

namespace Reports.BLL.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveEmployeeResource, Employee>()
                .ForMember(src => src.TypeOfEmployee,
                    opt =>
                        opt.MapFrom(src => Enum.Parse<TypeOfEmployee>(src.TypeOfEmployee)));
            CreateMap<UpgradeEmployeeResource, Employee>()
                .ForMember(src => src.TypeOfEmployee,
                    opt =>
                        opt.MapFrom(src => Enum.Parse<TypeOfEmployee>(src.TypeOfEmployee)));

            CreateMap<SaveProblemResource, Problem>();
            CreateMap<UpgradeProblemResource, Problem>()
                .ForMember(src => src.ProblemStatus,
                    opt =>
                        opt.MapFrom(src => Enum.Parse<ProblemStatus>(src.ProblemStatus)));

            CreateMap<SaveReportResource, Report>();
            CreateMap<UpgradeReportResource, Report>();
        }
    }
}