using AdlerLing.AccountService.Core.DTO;
using AdlerLing.AccountService.DB.Enitites;
using AdlerLing.AccountService.Infrustructure.Interfaces;
using System;
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

        public void Create(CreateUserDTO user)
        {
            const string sql = "INSERT INTO dbo.users (email, password) VALUES (@Email, @Password);";
            using (var connection = new NpgsqlConnection(DatabaseConnString))
            {
                var result = connection.Execute(sql, new
                {
                    user.Email,
                    user.Password
                });
            }
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
