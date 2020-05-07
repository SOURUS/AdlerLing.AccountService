using System;
using System.Data;

namespace AdlerLing.AccountService.Infrustructure.UOF
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly Guid _id;
        protected readonly IDbConnection _connection;
        protected IDbTransaction _transaction;

        public UnitOfWork(IDbConnection connection)
        {
            _id = Guid.NewGuid();
            _connection = connection;

            if (connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
            _transaction.Dispose();
            _transaction = _connection.BeginTransaction();
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }

            _transaction = null;
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
            _transaction = _connection.BeginTransaction();
        }

        public IDbConnection Connection
        {
            get
            {
                return _connection;
            }
        }

        public Guid Id
        {
            get
            {
                return _id;
            }
        }

        public IDbTransaction Transaction
        {
            get
            {
                return _transaction;
            }
        }
    }
}
