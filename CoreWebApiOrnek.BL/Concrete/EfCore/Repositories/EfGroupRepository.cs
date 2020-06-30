using CoreWebApiOrnek.BL.Concerete.EfCore.Generic;
using CoreWebApiOrnek.BL.Interfaces;
using CoreWebApiOrnek.DAL.Concerete.EfCore.Context;
using CoreWebApiOrnek.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApiOrnek.BL.Concerete.EfCore.Repositories
{
    public class EfGroupRepository : EfGenericRepository<Group>, IGroupRepository
    {
        public EfGroupRepository(ApiContext context) : base(context)
        {
        }

        public ApiContext ApiContext
        {
            get { return _context as ApiContext; }
        }

        public async Task<List<Group>> GetGroupWithExpenses(int? id)
        {
            if (id>0)
            {
                return await ApiContext.Groups.Where(ce=> ce.Id==id).Include(ce => ce.Expenses).ToListAsync();
            }
            else
            {
                return await ApiContext.Groups.Include(ce => ce.Expenses).ToListAsync();
            }
        }
    }
}
