using AutoMapper;
using Azure.Core;
using HMS.DAL.Configuration.MappingConfiguration;
using HMS.DAL.Dtos.Reponses;
using HMS.DAL.Dtos.Requests;
using HMS.DAL.Entities;
using HMS.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BLL.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IRepository<AppUser> _userRepo;

        public AuthenticationService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _userRepo = _unitOfWork.GetRepository<AppUser>();
        }
       
        public async Task<IdentityResult> RegisterUser(RegisterDto register)
        {
            AppUser UserExist = await _userManager.FindByEmailAsync(register.Email);
            if (UserExist != null)
            {
                return null;
            

            }
/*            var newUser = new RegisterDto()
            {
                Email = register.Email,
                FullName = register.FullName,
                UserName = register.FullName,
                Password = register.Password,
                ConfirmedPassword = register.Password,
                PhoneNumber = register.PhoneNumber,
                Roles = register.Roles,
            };*/
           // var newUser = _mapper.Map<AppUser>(register);
            var newUser = _mapper.Map(register, UserExist);
            var result = await _userManager.CreateAsync(newUser, register.Password);
            if (result.Succeeded)
                await _userManager.AddToRolesAsync(newUser, register.Roles);
            return result;
        }

  /*      public async Task<AuthenticationResponse> UserLogin(LoginDto loginDto)
        {
            var existingUser = await _userManager.FindByEmailAsync(loginDto.Email);
            if (existingUser == null)
            {
                throw new InvalidOperationException("Invalid username or password");
            }
            bool isCorrectPassword = await _userManager.CheckPasswordAsync(existingUser, loginDto.Password);
            if (!isCorrectPassword)
            {
                throw new InvalidOperationException("Invalid username or password");
            }
            *//*          var jwtToken = GenerateToken(existingUser); return Ok(new AuthResult()
                      {
                          Token = jwtToken,
                          Result = true
                      });*//*
            return new AuthenticationResponse { UserType = userType, FullName = fullName, UserId = user.Id, TwoFactor = true };

        }*/

       

    }
}
