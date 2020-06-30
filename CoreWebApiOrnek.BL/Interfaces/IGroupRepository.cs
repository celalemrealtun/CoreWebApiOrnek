using CoreWebApiOrnek.BL.Concerete.EfCore.Generic;
using CoreWebApiOrnek.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreWebApiOrnek.BL.Interfaces
{
    public interface IGroupRepository : IGenericRepository<Group>
    {
        Task<List<Group>> GetGroupWithExpenses(int? id);
    }
}
