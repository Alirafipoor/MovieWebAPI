using Domain.Entitties.UserEntity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructure.EntityValidation.Entity
{
    public  class UserValidation:AbstractValidator<User>
    {
        public UserValidation() {

            RuleFor(p => p.PhoneNumber).Matches(new Regex("^09(1[0-9]|3[1-9]|2[1-9])-?[0-9]{3}-?[0-9]{4}")).WithMessage("لطفا یک شماره موبایل واقعی وارد کنید")
                .NotNull().WithMessage("شماره  موبایل نمیتواند خالی باشد");
            
        }

    }
}
