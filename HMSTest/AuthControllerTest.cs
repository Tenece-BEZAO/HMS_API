using AutoMapper;
using HMS.API.Controllers;
using HMS.BLL.Interfaces;
using HMS.DAL.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HMSTest
{
    public class AuthControllerTest
    {
        private readonly AuthenticationController _controller;
       // private readonly IAuthenticationServices _service;
        private readonly IAuthenticationServices _authenticationService; 
        private readonly IUserService _userService;
        public AuthControllerTest()
        {
             _authenticationService = new AuthenticationService();
          /*  var mapper = new Mapper(*//* provide necessary configuration *//*);
            var userManager = new UserManager<AppUser>(*//* provide necessary dependencies *//*);
            var configuration = new ConfigurationBuilder().Build(); // You can customize the configuration setup here
            var signInManager = new SignInManager<AppUser>(*//* provide necessary dependencies *//*);
            var roleManager = new RoleManager<IdentityRole>(*//* provide necessary dependencies *//*);
            var emailService = new EmailService(*//* provide necessary dependencies *//*);
            var httpContextAccessor = new HttpContextAccessor();
            var urlHelperFactory = new UrlHelperFactory(*//* provide necessary dependencies *//*);
            var serviceProvider = new ServiceProvider(*//* provide necessary dependencies *//*);

            _authenticationService = new AuthenticationService(
                mapper,
                userManager,
                configuration,
                signInManager,
                roleManager,
                emailService,
                httpContextAccessor,
                urlHelperFactory,
                serviceProvider
            );*/
            _controller = new AuthenticationController(_authenticationService, _userService);
        }

        [Fact]
        public void Authenticatio_GetUsers_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetUser();
            ;            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Test1()
        {
            //Naming Convention : ClassName_MethodName_ExpectedResult
            //wrap the method in try catch
            //Arrang - go get var, whatever you need , your classes, go getg function
            //Act - Execute this function ie create instance of that class and invoke the method
            //Assert - the output is it the desired output

        }

      
    }
}