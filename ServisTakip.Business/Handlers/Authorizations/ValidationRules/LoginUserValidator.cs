using FluentValidation;
using ServisTakip.Business.Handlers.Authorizations.Queries;

namespace ServisTakip.Business.Handlers.Authorizations.ValidationRules
{
    public class LoginUserValidator : AbstractValidator<LoginUserQuery>
    {
        public LoginUserValidator()
        {
            RuleFor(m => m.LoginModel.Password).NotNull().WithMessage("Şifre boş olamaz");
            RuleFor(m => m.LoginModel.Email).NotNull().WithMessage("Kullanıcı adı boş olamaz");
        }
    }
}
