using CoreWebApiOrnek.DTO.ExpenseDto;
using CoreWebApiOrnek.Helper;
using FluentValidation;

namespace CoreWebApiOrnek.BL.ValidationRules.Fluent.ExpenseValidation
{
    public class ExpenseUpdateValidation : AbstractValidator<DtoExpenseUpdate>
    {
        public ExpenseUpdateValidation()
        {
            RuleFor(ce => ce.Id).InclusiveBetween(0, int.MaxValue).WithMessage("Id boş geçilemez");
            RuleFor(ce => ce.ExpenseDate).Must(General.BeAValidDate).WithMessage("Grup adı boş geçilemez.");
            RuleFor(ce => ce.GroupId).InclusiveBetween(0, int.MaxValue).WithMessage("Grup boş geçilemez");
            RuleFor(ce => ce.UserId).InclusiveBetween(0, int.MaxValue).WithMessage("Kullanıcı boş geçilemez");
            RuleFor(ce => ce.Amount).GreaterThan(0).WithMessage("Tutar 0 dan büyük olmalı.");
            RuleFor(ce => ce.Description).NotEmpty().WithMessage("Açıklama boş geçilemez.");
        }
    }
}
