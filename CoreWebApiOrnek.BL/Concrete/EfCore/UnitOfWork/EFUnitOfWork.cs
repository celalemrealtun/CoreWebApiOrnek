using CoreWebApiOrnek.BL.Concerete.EfCore.Repositories;
using CoreWebApiOrnek.BL.Interfaces;
using CoreWebApiOrnek.DAL.Concerete.EfCore.Context;
using System;
using System.Threading.Tasks;

namespace CoreWebApiOrnek.BL.Concrete.EfCore.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly ApiContext dbContext;

        public EFUnitOfWork(ApiContext _dbContext)
        {
            dbContext = _dbContext ?? throw new ArgumentNullException("dbcontext bulunamadi.");
        }
        private IUserRepository _users;
        private IGroupRepository _groups;
        private IExpenseRepository _expenses;
        public IUserRepository Users
        {
            get
            {
                return _users ?? (_users = new EfUserRepository(dbContext));
            }
        }

        public IGroupRepository Groups
        {
            get
            {
                return _groups ?? (_groups = new EfGroupRepository(dbContext));
            }
        }

        public IExpenseRepository Expenses
        {
            get
            {
                return _expenses ?? (_expenses = new EfExpenseRepository(dbContext));
            }
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        

        public async Task SaveChangesAsync()
        {
            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
