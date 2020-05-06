using AdlerLing.AccountService.Core.DTO;
using AdlerLing.AccountService.DB.Enitites;
using System;
using System.Threading.Tasks;

namespace AdlerLing.AccountService.Infrustructure.Interfaces
{
    public interface IUserRepository
    {
        Task<User> FindById(Guid id);
        Task<bool> Create(CreateUserDTO user); //TODO: create response object for internal operations
        User Update(User user);
        void Remove(Guid id);
    }
}
