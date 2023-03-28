using AutoMapper;
using HMS.DAL.Dtos.Requests;
using HMS.DAL.Entities;
using static HMS.DAL.Dtos.Requests.AuthenticationRequest;


namespace HMS.DAL.Configuration.MappingConfiguration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDto, AppUser>()
             .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
             .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.ConfirmedPassword));


            CreateMap<AppointmentDto, Appointment>();

            CreateMap<Appointment, AppointmentDto>();

            CreateMap<ReportDto, Report>();

            CreateMap<Report, ReportDto>();

            CreateMap<EnrolleeDTO, Enrollee>();

            CreateMap<Enrollee, EnrolleeDTO>();

            CreateMap<PlanDto, Plan>();

            CreateMap<Plan, PlanDto>();

            CreateMap<DrugDto, Drug>();

            CreateMap<Drug, DrugDto>();

        }
    }
}
