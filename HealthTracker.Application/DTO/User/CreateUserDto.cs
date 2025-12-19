using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracker.Application.DTO.User
{
    public class CreateUserDto
    {
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
    }
    public class CreateUserValidatior : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidatior()
        {
            RuleFor(x => x.Name)
             .NotEmpty().WithMessage("Name is required")
             .MinimumLength(2).WithMessage("Name must be at least 2 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Enter a valid email address");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must contain at least 6 characters");

            RuleFor(x => x.Age)
                .InclusiveBetween(5, 120).WithMessage("Enter a valid age");
        }
    }
}
