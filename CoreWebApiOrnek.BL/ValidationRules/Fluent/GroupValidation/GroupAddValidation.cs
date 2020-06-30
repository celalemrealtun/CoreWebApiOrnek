using CoreWebApiOrnek.DTO.GroupDto;
using FluentValidation;

namespace CoreWebApiOrnek.BL.ValidationRules.Fluent.GroupValidation
{
    public class GroupAddValidation : AbstractValidator<DtoGroupAdd>
    {
        public GroupAddValidation()
        {
            RuleFor(ce => ce.GroupName).NotEmpty().WithMessage("Grup adı boş geçilemez.");
        }
    }
}
