using FluentValidation;

namespace LibraryManagement.Application.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidator()
        {
            RuleFor(c => c.Model).NotNull();

            RuleFor(c => c.Model.FirstName)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(c => c.Model.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(c => c.Model.Birthdate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
