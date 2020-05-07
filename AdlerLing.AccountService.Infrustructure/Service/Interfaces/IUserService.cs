using AdlerLing.AccountService.Core.DTO;
using System.Threading.Tasks;

namespace AdlerLing.AccountService.Infrustructure.Service.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUser(CreateUserDTO user);
        
    }
}
