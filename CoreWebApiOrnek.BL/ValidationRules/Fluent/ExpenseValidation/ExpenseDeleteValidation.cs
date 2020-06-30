using CoreWebApiOrnek.DTO.ExpenseDto;
using FluentValidation;

namespace CoreWebApiOrnek.BL.ValidationRules.Fluent.ExpenseValidation
{
    public class ExpenseDeleteValidation : AbstractValidator<DtoExpenseDelete>
    {
        public ExpenseDeleteValidation()
        {
            RuleFor(ce => ce.Id).InclusiveBetween(0, int.MaxValue).WithMessage("Id boş geçilemez");
        }
    }
}
