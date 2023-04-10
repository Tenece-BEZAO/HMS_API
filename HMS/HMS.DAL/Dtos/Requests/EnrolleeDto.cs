﻿using HMS.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace HMS.DAL.Dtos.Requests
{
    public class EnrolleeDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required"), MaxLength(100)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last name is required"), MaxLength(100)]
        public string LastName { get; set; } = null!;

        [MaxLength(100)]
        public string? MiddleName { get; set; }
        public string? Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
    }
}
