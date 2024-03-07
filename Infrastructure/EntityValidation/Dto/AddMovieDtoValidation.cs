using Application.Dto.Movie;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityValidation.Dto
{
    public class AddMovieDtoValidation:AbstractValidator<AddMovieDto>
    {
        public AddMovieDtoValidation()
        {
            RuleFor(p => p.Title).NotNull().WithMessage("عنوان نباید خالی باشد")
                .Length(1, 50).WithMessage("عنوان باید بین 1 تا 50  کارکترباشد  ");

            RuleFor(p => p.Year).NotNull().WithMessage("سال ساخت نباید خالی باشد")
                .InclusiveBetween(1300, 2100).WithMessage("سال ساخت باید بین 1300 تا 2100 باشد");

            RuleFor(p => p.GenreId).NotNull().WithMessage("ایدی ژانر نباید خالی باشد")
                .GreaterThan(0).WithMessage("ایدی ژانر باید بیشتر از 0 باشد");

        }
    }
}
