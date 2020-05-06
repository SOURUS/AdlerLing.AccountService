using AdlerLing.AccountService.Core.DTO;
using AdlerLing.AccountService.DB.Enitites;
using AdlerLing.AccountService.Infrustructure.Interfaces;
using AdlerLing.AccountService.Core.ObjectValue;
using System;
using System.Data;
using Dapper;
using System.Threading.Tasks;
using Npgsql;

namespace AdlerLing.AccountService.Infrustructure.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly string DatabaseConnString;

        public UserRepository(string connectionString)
        {
            DatabaseConnString = connectionString;
        }

        public async Task<bool> Create(CreateUserDTO user)
        {
            using (var connection = new NpgsqlConnection(DatabaseConnString))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand("call dbo.sp_insert_user(@email, @password)", connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@password", user.Password);

                    await cmd.ExecuteReaderAsync();
                }
            }

            return true;
        }

        public Task<User> FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public User Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
