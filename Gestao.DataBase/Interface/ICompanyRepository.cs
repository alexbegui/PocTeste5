using Gestao.Client.Libraries.Utilities;
using Gestao.Domain;

namespace Gestao.Database.Interface
{
    public interface ICompanyRepository : IRepository<Company>
    {
     Task<PaginatedList<Company>> GetAll(Guid applicationUserId, int pageIndex, int pageSize, string searchWord);
       
    }
}