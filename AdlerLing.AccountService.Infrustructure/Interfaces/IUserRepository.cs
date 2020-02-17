using AdlerLing.AccountService.Core.DTO;
using AdlerLing.AccountService.DB.Enitites;
using System;
using System.Threading.Tasks;

namespace AdlerLing.AccountService.Infrustructure.Interfaces
{
    public interface IUserRepository
    {
        Task<User> FindById(Guid id);
        void Create(CreateUserDTO user);
        User Update(User user);
        void Remove(Guid id);
    }
}
