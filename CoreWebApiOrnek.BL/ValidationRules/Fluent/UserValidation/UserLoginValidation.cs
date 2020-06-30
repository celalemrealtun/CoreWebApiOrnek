using CoreWebApiOrnek.DTO.UserDto;
using FluentValidation;

namespace CoreWebApiOrnek.BL.ValidationRules.Fluent.UserValidation
{
    public class UserLoginValidation : AbstractValidator<DtoUserLogin>
    {
        public UserLoginValidation()
        {
            RuleFor(ce => ce.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez.");
            RuleFor(ce => ce.PassWord).NotEmpty().WithMessage("Şifre Boş Geçilemez.");

        }
    }
}
