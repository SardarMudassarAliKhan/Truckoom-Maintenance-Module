using AutoMapper;
using Truckoom_Maintenance.DTOS;
using Truckoom_Maintenance_DAL.Model;

namespace Truckoom_Maintenance.MappingProfile
{
    public class TruckoomMappingProfile : Profile
    {
        public TruckoomMappingProfile()
        {
            CreateMap<MaintenanceActivity, MaintenanceActivityDto>().ReverseMap();
            CreateMap<MaintenanceActivity, MaintenanceActivityEditDto>().ReverseMap();
            CreateMap<MaintenanceActivity, MaintenanceActivityDeleteDto>().ReverseMap();
        }
    }
}
