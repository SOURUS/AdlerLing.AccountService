using AdlerLing.AccountService.Core.DTO;
using AdlerLing.AccountService.DB.Enitites;
using System;
using System.Threading.Tasks;

namespace AdlerLing.AccountService.Infrustructure.DAL.Interfaces
{
    public interface IUserDAL : IDAL, IDisposable
    {
        Task<Guid> CreateUserAsync(UserDTO user);
        Task<int> CheckUserExists(string email);
        Task<int> CheckUserById(Guid userId);
        Task<User> GetUser(Guid userId);
    }
}
