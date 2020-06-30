using CoreWebApiOrnek.BL.ValidationRules.Fluent.ExpenseValidation;
using CoreWebApiOrnek.BL.ValidationRules.Fluent.GroupValidation;
using CoreWebApiOrnek.BL.ValidationRules.Fluent.UserValidation;
using CoreWebApiOrnek.DTO.ExpenseDto;
using CoreWebApiOrnek.DTO.GroupDto;
using CoreWebApiOrnek.DTO.UserDto;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CoreWebApiOrnek.BL.Containers.MicrosoftIoC
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddTransient<IValidator<DtoUserLogin>, UserLoginValidation>();
            services.AddTransient<IValidator<DtoExpenseAdd>, ExpenseAddValidation>();
            services.AddTransient<IValidator<DtoExpenseDelete>, ExpenseDeleteValidation>();
            services.AddTransient<IValidator<DtoExpenseUpdate>, ExpenseUpdateValidation>();
            services.AddTransient<IValidator<DtoGroupAdd>, GroupAddValidation>();
            services.AddTransient<IValidator<DtoGroupDelete>, GroupDeleteValidation>();
            services.AddTransient<IValidator<DtoGroupUpdate>, GroupUpdateValidatation>();

        }
    }
}
