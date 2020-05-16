using AdlerLing.AccountService.Core.DTO;
using AdlerLing.AccountService.Core.Transfering;
using System.Threading.Tasks;

namespace AdlerLing.AccountService.Infrustructure.Service.Interfaces
{
    public interface IRoleService
    {
        Task<Result> CreateRole(RoleDTO role);
    }
}
