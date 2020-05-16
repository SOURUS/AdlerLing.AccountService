using AdlerLing.AccountService.Core.DTO;
using AdlerLing.AccountService.Core.ObjectValue;
using AdlerLing.AccountService.DB.Enitites;
using AdlerLing.AccountService.Infrustructure.DAL.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public async Task<int> CheckUserById(Guid userId)
        {
            try
            {
                return await _uow.Connection.ExecuteScalarAsync<int>("select count(1) from dbo.users where user_id=@userId",
                    new { userId },
                    commandType: CommandType.Text, transaction: _uow.Transaction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Guid> CreateUserAsync(UserDTO user)
        {
            try
            {
                var user_id = await _uow.Connection.ExecuteScalarAsync<Guid>($"select dbo.{StoredProcedureVault.func_insert_user}(@email, @password)",
                        new { user.Email, user.Password },
                        commandType: CommandType.Text, transaction: _uow.Transaction);

                foreach (var userRole in user.Roles)
                {
                    await _uow.Connection.ExecuteAsync($"call dbo.{StoredProcedureVault.sp_insert_user_roles}(@user_id, @role_id)",
                        new { user_id, role_id = userRole.RoleId },
                        commandType: CommandType.Text, transaction: _uow.Transaction);
                }
                
                return user_id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetUser(Guid userId)
        {
            try
            {
                var user = await _uow.Connection.QueryFirstOrDefaultAsync<User>
                    ($"select * from dbo.users where user_id = @userId", new { userId });
                
                user.user_info = await _uow.Connection.QueryFirstOrDefaultAsync<UserInfo>
                    ($"select * from dbo.user_info where user_id = @userId", new { userId });

                IEnumerable<int> roleIds = await _uow.Connection.QueryAsync<int>
                    ($"select role_id from dbo.user_roles where user_id = @userId", new { userId });

                user.roles = await _uow.Connection.QueryAsync<Role>
                    ($"select * from dbo.roles where role_id = any (@IDs)", new { IDs = roleIds });

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
