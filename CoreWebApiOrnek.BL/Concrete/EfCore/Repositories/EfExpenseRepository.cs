using CoreWebApiOrnek.BL.Concerete.EfCore.Generic;
using CoreWebApiOrnek.BL.Interfaces;
using CoreWebApiOrnek.DAL.Concerete.EfCore.Context;
using CoreWebApiOrnek.Entities.Concrete;

namespace CoreWebApiOrnek.BL.Concerete.EfCore.Repositories
{
    public class EfExpenseRepository : EfGenericRepository<Expense>,IExpenseRepository
    {
        public EfExpenseRepository(ApiContext context) : base(context)
        {
        }

        public ApiContext ApiContext
        {
            get { return _context as ApiContext; }
        }

 
    }
}
