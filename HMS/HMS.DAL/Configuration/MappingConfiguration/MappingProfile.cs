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
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.ConfirmedPassword))
             .ForMember(dest => dest.TwoFactorEnabled, opt => opt.MapFrom(src => src.TwoFactorEnabled));


           // CreateMap<AppUser, LoginDto>();
         

            CreateMap<AppointmentDto, Appointment>();

            CreateMap<Appointment, AppointmentDto>();

            CreateMap<ReportDto, Report>();

            CreateMap<Report, ReportDto>();
            CreateMap<UpdateRequest, AppUser>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    return true;
                }
            ));

            CreateMap<EnrolleeDTO, Enrollee>();

            CreateMap<Enrollee, EnrolleeDTO>();

            CreateMap<PlanDto, Plan>();

            CreateMap<Plan, PlanDto>();

            CreateMap<DrugDto, Drug>();

            CreateMap<Drug, DrugDto>();

        }
    }
}
