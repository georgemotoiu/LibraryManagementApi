using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Features.Students.Queries.GetStudent
{
    public class GetStudentQueryValidator : AbstractValidator<GetStudentQuery>
    {
        public GetStudentQueryValidator()
        {
            RuleFor(s => s.Id)                
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();


        }
    }
}
