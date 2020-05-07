using AdlerLing.AccountService.Core.DTO;
using System;
using System.Threading.Tasks;

namespace AdlerLing.AccountService.Infrustructure.DAL.Interfaces
{
    public interface IUserDAL : IDisposable
    {
        Task<bool> CreateUserAsync(CreateUserDTO user);
        Task<bool> CheckUserExists(string email);
        Task<int> CommitAsync();
        void Rollback();
    }
}
