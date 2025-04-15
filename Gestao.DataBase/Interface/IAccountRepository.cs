using Gestao.Client.Libraries.Utilities;
using Gestao.Domain;

namespace Gestao.Database.Interface
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<PaginatedList<Account>> GetAll(int companyId, int pageIndex, int pageSize, string searchWord = "");
        Task<List<Account>> GetAll(int companyId);
    }
}

