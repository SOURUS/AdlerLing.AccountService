using AdlerLing.AccountService.Infrustructure.UOF;
using Npgsql;
using System.Threading.Tasks;

namespace AdlerLing.AccountService.Infrustructure.DAL.Implementations
{
    public class BaseDAL
    {
        private readonly string _databaseConnString;
        internal readonly IUnitOfWork _uow;

        public int _executeCounter;

        public BaseDAL(string connectionString)
        {
            _databaseConnString = connectionString;

            var connection = new NpgsqlConnection(_databaseConnString);
            connection.Open();
            _uow = new UnitOfWork(connection);
        }

        public Task<int> CommitAsync()
        {
            try
            {
                var count = _executeCounter;
                _executeCounter = 0;
                _uow.Commit();
                return Task.FromResult(count);
            }
            catch
            {
                //TODO: ADD LOGGER
            }

            return Task.FromResult(0);
        }

        public void Rollback()
        {
            _uow.Rollback();
        }

        public void Dispose()
        {
            if (_uow != null)
            {
                _uow.Dispose();
            }
        }
    }
}
