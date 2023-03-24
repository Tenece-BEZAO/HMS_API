using HMS.DAL.Dtos.Requests;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Interfaces
{
    public interface IAuthenticationService
    {
         Task<IdentityResult> RegisterUser(RegisterDto userForRegistration);
        /*Task<string> UserLogin(LoginDto loginDto);*/
    }
}
