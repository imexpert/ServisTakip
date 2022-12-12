using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServisTakip.Business.Handlers.Authorizations.Queries;

namespace ServisTakip.Business.Handlers.Authorizations.ValidationRules
{
    public class LoginUserValidator : AbstractValidator<LoginUserQuery>
    {
        public LoginUserValidator()
        {
            RuleFor(m => m.LoginModel.Password).NotNull().WithMessage("Şifre boş olamaz");
            RuleFor(m => m.LoginModel.Username).NotNull().WithMessage("Kullanıcı adı boş olamaz");
        }
    }
}
