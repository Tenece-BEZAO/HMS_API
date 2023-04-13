using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HMS.DAL.Entities.ErrorModel
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public override string ToString() => JsonSerializer.Serialize(this);
    }
    public abstract class NotFoundException : Exception
    {
        protected NotFoundException(string message)
        : base(message)
        { }
    }

    public sealed class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(AppUser user)
        : base($"The User with id: {user.Email} doesn't exist in the database.")
        {
        }
    }

    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message) { }
    }

}
