using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Dtos.Requests
{
    public class UpdateRequestValidator : AbstractValidator<UpdateRequest>
    {
        public UpdateRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().Length(3, 50);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }

}
