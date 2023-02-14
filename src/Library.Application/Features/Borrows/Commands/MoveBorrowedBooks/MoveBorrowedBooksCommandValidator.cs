using FluentValidation;

namespace LibraryManagement.Application.Features.Borrows.Commands.MoveBorrowedBooks
{
    public class MoveBorrowedBooksCommandValidator : AbstractValidator<MoveBorrowedBooksCommand>
    {
        public MoveBorrowedBooksCommandValidator()
        {
            RuleFor(c => c.FromStudentId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(c => c.ToStudentId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();
        }
    }
}
