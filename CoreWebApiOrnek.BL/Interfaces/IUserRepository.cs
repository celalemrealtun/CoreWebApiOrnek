using CoreWebApiOrnek.BL.Concerete.EfCore.Generic;
using CoreWebApiOrnek.DTO.UserDto;
using CoreWebApiOrnek.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreWebApiOrnek.BL.Interfaces
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<User> CheckUserAsync(DtoUserLogin appUserLoginDto);
  
    }
}
