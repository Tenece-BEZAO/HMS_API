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
            CreateMap<AppUserDto, AppUser>().ReverseMap();

            CreateMap<ProviderDto, Provider>().ReverseMap();

            CreateMap<AppointmentDto, Appointment>().ReverseMap();

            CreateMap<ReportDto, Report>().ReverseMap();

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
            CreateMap<AppUser, UpdateRequest>();

            CreateMap<EnrolleeDto, Enrollee>().ReverseMap();

            CreateMap<PlanDto, Plan>().ReverseMap();

            CreateMap<DrugDto, Drug>().ReverseMap();

        }
    }
}
