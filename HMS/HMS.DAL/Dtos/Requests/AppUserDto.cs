using HMS.DAL.Entities;
using HMS.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Dtos.Requests
{
    public class AppUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
    }
}
