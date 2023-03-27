using HMS.DAL.Dtos.Requests;
using AutoMapper;
using HMS.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static HMS.DAL.Dtos.Requests.AuthenticationRequest;

namespace HMS.DAL.Configuration.MappingConfiguration
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
           /* CreateMap<RegisterDto, AppUser>()
                .ForMember(r => r.FullName,
         opt => opt.MapFrom(x => string.Join(' ', x.FirstName, x.LastName)));*/


           CreateMap<RegisterDto, AppUser>()
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.ConfirmedPassword));

        }
    }
   
}
