
using CoreWebApiOrnek.BL.Concerete.EfCore.Generic;
using CoreWebApiOrnek.BL.Interfaces;
using CoreWebApiOrnek.DAL.Concerete.EfCore.Context;
using CoreWebApiOrnek.DTO.UserDto;
using CoreWebApiOrnek.Entities.Concrete;
using CoreWebApiOrnek.Helper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreWebApiOrnek.BL.Concerete.EfCore.Repositories
{
    public class EfUserRepository : EfGenericRepository<User>, IUserRepository
    {
        public EfUserRepository(ApiContext context) : base(context)
        {
        }

        public ApiContext ApiContext
        {
            get { return _context as ApiContext; }
        }

        public async Task<User> CheckUserAsync(DtoUserLogin user)
        {
            return await GetAsync(ce => ce.UserName == user.UserName && ce.PassWord == Converter.ToHashMd5(user.PassWord));
        }

      
    }
}
