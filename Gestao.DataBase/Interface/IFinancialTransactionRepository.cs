using Gestao.Client.Libraries.Utilities;
using Gestao.Domain;
using Gestao.Domain.Enums;

namespace Gestao.Database.Interface
{

    public interface IFinancialTransactionRepository : IRepository<FinancialTransaction>
    {
        Task<PaginatedList<FinancialTransaction>> GetAll(int companyId, TypeFinancialTransaction type, int pageIndex, int pageSize, string searchWord);
        Task<List<FinancialTransaction>> GetTransactionsSameGroup(int Id);
        Task<int> GetCountTransactionsSameGroup(int Id);
    }
}

