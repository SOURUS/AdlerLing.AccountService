using AdlerLing.AccountService.Core.DTO;
using AdlerLing.AccountService.Infrustructure.DAL.Interfaces;
using Dapper;
using System;
using System.Data;
using System.Threading.Tasks;

namespace AdlerLing.AccountService.Infrustructure.DAL.Implementations
{
    public class UserDAL : BaseDAL, IUserDAL
    {
        public UserDAL(string connectionString) : base(connectionString) { }

        public async Task<int> CheckUserExists(string email)
        {
            try
            {
                return await _uow.Connection.ExecuteScalarAsync<int>("select count(1) from dbo.users where email=@email",
                    new { email },
                    commandType: CommandType.Text, transaction: _uow.Transaction);
            }
            catch(Exception ex)
            {
                throw ex;
            }
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
