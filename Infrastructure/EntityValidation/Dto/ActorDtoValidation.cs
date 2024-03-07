using Application.Dto.Movie;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityValidation.Dto
{
    public class ActorDtoValidation:AbstractValidator<ActorDto>
    {
        public ActorDtoValidation() 
        {
            RuleFor(p => p.Name).NotNull().WithMessage("نام نمیتواند خالی باشد")
               .Length(3, 50).WithMessage("نام باید بین 3 تا 50 کارکتر باشد");

            RuleFor(p => p.Age).NotNull().WithMessage("سن نمیتواند خالی باشد")
                .InclusiveBetween(1, 150).WithMessage("سن باید بین 1 تا 150 باشد");

            RuleFor(p => p.Award).NotNull().WithMessage("جوایز نمیتواند خالی باشد")
                 .GreaterThan(0).WithMessage("تعداد جوایز نباید از 0 کمتر باشد");

            RuleFor(p => p.IsMarried).NotEmpty().WithMessage("جنسیت نمیتواند خالی باشد");

            RuleFor(p => p.Birthday).NotNull().WithMessage("تاریخ تولد نباید خالی باشد")
                .Length(1, 100).WithMessage("تاریخ تولد باید بین 1 و 100 کارکتر باشد");

            RuleFor(p => p.Description).NotNull().WithMessage("توضیحات نمیتواند خالی باشد")
                .Length(20, 500).WithMessage("توضیخات باید بین 20 و 500 کارکتر باشد");
        }
    }
}
