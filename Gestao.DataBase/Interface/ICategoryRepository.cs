using Gestao.Client.Libraries.Utilities;
using Gestao.Domain;

namespace Gestao.Database.Interface
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<Category>> GetAll(int companyId);
        Task<PaginatedList<Category>> GetAll(int companyId, int pageIndex, int pageSize);



       
    }
}