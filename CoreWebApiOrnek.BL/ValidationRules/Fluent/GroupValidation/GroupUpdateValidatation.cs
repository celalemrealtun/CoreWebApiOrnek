using CoreWebApiOrnek.DTO.GroupDto;
using FluentValidation;

namespace CoreWebApiOrnek.BL.ValidationRules.Fluent.GroupValidation
{
    public class GroupUpdateValidatation : AbstractValidator<DtoGroupUpdate>
    {
        public GroupUpdateValidatation()
        {
            RuleFor(ce => ce.Id).InclusiveBetween(0, int.MaxValue).WithMessage("Id boş geçilemez");
            RuleFor(ce => ce.GroupName).NotEmpty().WithMessage("Grup adı boş geçilemez.");
        }
    }
}
