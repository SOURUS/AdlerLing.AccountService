using System;
using System.Data;

namespace AdlerLing.AccountService.Infrustructure.UOF
{
    public interface IUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }
        Guid Id { get; }
        IDbTransaction Transaction { get; }
        void Commit();
        void Rollback();
    }
}
