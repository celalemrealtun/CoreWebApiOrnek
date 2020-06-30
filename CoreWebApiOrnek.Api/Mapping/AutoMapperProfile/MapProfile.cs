using AutoMapper;
using CoreWebApiOrnek.DTO.ExpenseDto;
using CoreWebApiOrnek.DTO.GroupDto;
using CoreWebApiOrnek.DTO.UserDto;
using CoreWebApiOrnek.Entities.Concrete;

namespace CoreWebApiOrnek.Api.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile//AutoMapper.Extensions.Microsoft.DependencyInjection 
    {
        public MapProfile()
        {
            #region User
            CreateMap<DtoUser, User>();
            CreateMap<User, DtoUser>();

            CreateMap<DtoUserLogin, User>();
            CreateMap<User, DtoUserLogin>();
            #endregion

            #region Group
            CreateMap<DtoGroupAdd, Group>();
            CreateMap<Group, DtoGroupAdd>();

            CreateMap<DtoGroupUpdate, Group>();
            CreateMap<Group, DtoGroupUpdate>();

            CreateMap<DtoGroupDelete, Group>();
            CreateMap<Group, DtoGroupDelete>();

            CreateMap<DtoGroupList, Group>();
            CreateMap<Group, DtoGroupList>();

            CreateMap<DtoGroupListWithExpenses, Group>();
            CreateMap<Group, DtoGroupListWithExpenses>();

            #endregion

            #region Expense
            CreateMap<DtoExpenseAdd, Expense>();
            CreateMap<Expense, DtoExpenseAdd>();

            CreateMap<DtoExpenseUpdate, Expense>();
            CreateMap<Expense, DtoExpenseUpdate>();

            CreateMap<DtoExpenseDelete, Expense>();
            CreateMap<Expense, DtoExpenseDelete>();

            CreateMap<DtoExpenseList, Expense>();
            CreateMap<Expense, DtoExpenseList>();
            #endregion


        }
    }
}
