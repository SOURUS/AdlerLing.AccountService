using AdlerLing.AccountService.Core.DTO;
using AdlerLing.AccountService.Infrustructure.DAL.Interfaces;
using Dapper;
using System;
using System.Data;
using System.Threading.Tasks;

namespace AdlerLing.AccountService.Infrustructure.DAL.Implementations
{
    public class RoleDAL : BaseDAL, IRoleDAL
    {
        public RoleDAL(string connectionString) : base(connectionString){ }

        public async Task<bool> CreateRoleAsync(CreateRoleDTO role)
        {
            var sql = "INSERT INTO dbo.roles (name) VALUES (@email)";
            var res = await _uow.Connection.ExecuteAsync(sql, new { email = role.Name },
                commandType: CommandType.Text, transaction: _uow.Transaction);

            bool response = res == 1;

            return response;
        }

        public async Task<int> CheckRoleExists(string name)
        {
            try
            {
                return await _uow.Connection.ExecuteScalarAsync<int>("select count(1) from dbo.roles where name=@name",
                    new { name },
                    commandType: CommandType.Text, transaction: _uow.Transaction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
