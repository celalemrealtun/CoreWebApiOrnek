using CoreWebApiOrnek.DTO.GroupDto;
using FluentValidation;

namespace CoreWebApiOrnek.BL.ValidationRules.Fluent.GroupValidation
{
    public class GroupDeleteValidation :    AbstractValidator<DtoGroupDelete>
    {
        public GroupDeleteValidation()
        {
            RuleFor(ce => ce.Id).InclusiveBetween(0, int.MaxValue).WithMessage("Id boş geçilemez");
        }
    }
}
