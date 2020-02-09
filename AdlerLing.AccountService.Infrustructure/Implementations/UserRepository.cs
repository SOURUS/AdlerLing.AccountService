using AdlerLing.AccountService.DB.Enitites;
using AdlerLing.AccountService.Infrustructure.Interfaces;
using Npgsql;
using System;
using System.Data;
using System.Threading.Tasks;

namespace AdlerLing.AccountService.Infrustructure.Implementations
{
    public class UserRepository : IUserRepository
    {
        private IDbConnection db;

        public UserRepository(string connectionString)
        {
            db = new NpgsqlConnection(connectionString);
        }

        public void Create(User user)
        {
            throw new NotImplementedException();
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

        public string Check()
        {
            return db.ConnectionString;
        }
    }
}
