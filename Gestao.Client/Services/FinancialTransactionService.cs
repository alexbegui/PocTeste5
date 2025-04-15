using Gestao.Client.Libraries.Utilities;
using Gestao.Database.Interface;
using Gestao.Domain;
using Gestao.Domain.Enums;
using System.Linq.Expressions;
using System.Net.Http.Json;

namespace Gestao.Client.Services
{
    public class FinancialTransactionService : IFinancialTransactionRepository
    {
        private readonly HttpClient _httpClient;

        public FinancialTransactionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task Add(FinancialTransaction entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<FinancialTransaction>> FindByCondition(Expression<Func<FinancialTransaction, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<List<FinancialTransaction>> FindByConditionAsync(Expression<Func<FinancialTransaction, bool>> expression, params string[] propertiesToInclude)
        {
            throw new NotImplementedException();
        }

        public Task<FinancialTransaction?> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedList<FinancialTransaction>> GetAll(int companyId, TypeFinancialTransaction type, int pageIndex, int pageSize, string searchWord)
        {
            var url = $"/api/financialtransactions?companyId={companyId}&pageIndex={pageIndex}&searchWord={searchWord}&type={type}";
            var entities = await _httpClient.GetFromJsonAsync<PaginatedList<FinancialTransaction>>(url);

            return entities!;
        }

        public Task<List<FinancialTransaction>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<FinancialTransaction?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountTransactionsSameGroup(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<FinancialTransaction>> GetTransactionsSameGroup(int Id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(FinancialTransaction obj)
        {
            throw new NotImplementedException();
        }
    }
}
