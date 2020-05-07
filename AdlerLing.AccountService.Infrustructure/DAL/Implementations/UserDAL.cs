using AdlerLing.AccountService.Core.DTO;
using AdlerLing.AccountService.Infrustructure.DAL.Interfaces;
using AdlerLing.AccountService.Infrustructure.UOF;
using Dapper;
using Npgsql;
using System.Data;
using System.Threading.Tasks;

namespace AdlerLing.AccountService.Infrustructure.DAL.Implementations
{
    public class UserDAL : IUserDAL
    {
        private readonly string _databaseConnString;
        internal readonly IUnitOfWork _uow;

        private int _executeCounter;

        public UserDAL(string connectionString)
        {
            _databaseConnString = connectionString;

            var connection = new NpgsqlConnection(_databaseConnString);
            connection.Open();
            _uow = new UnitOfWork(connection);
        }

        public async Task<bool> CheckUserExists(string email)
        {
            try
            {
                return await _uow.Connection.ExecuteScalarAsync<bool>("select count(1) from dbo.users where email=@email",
                    new { email },
                    commandType: CommandType.Text, transaction: _uow.Transaction);
            }
            catch
            {

            }

            return false;
        }

        public async Task<bool> CreateUserAsync(CreateUserDTO user)
        {
            try
            {
                await _uow.Connection.ExecuteAsync("call dbo.sp_insert_user(@email, @password)",
                        new { email = user.Email, password = user.Password },
                        commandType: CommandType.Text, transaction: _uow.Transaction);
                
                _executeCounter++;

                return true;
            }
            catch
            {

            }

            return false;
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
