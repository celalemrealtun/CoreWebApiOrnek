using CoreWebApiOrnek.BL.Interfaces;
using System;
using System.Threading.Tasks;

namespace CoreWebApiOrnek.BL.Concrete.EfCore.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IGroupRepository Groups { get; }
        IExpenseRepository Expenses { get; }
        Task SaveChangesAsync();
        

    }
}
