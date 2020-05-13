using System.Threading.Tasks;

namespace AdlerLing.AccountService.Infrustructure.DAL.Interfaces
{
    public interface IDAL
    {
        Task<int> CommitAsync();
        void Rollback();
    }
}
