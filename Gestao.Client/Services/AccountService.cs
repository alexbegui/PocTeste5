using Gestao.Client.Libraries.Utilities;
using Gestao.Database.Interface;
using Gestao.Domain;
using System.Linq.Expressions;
using System.Net.Http.Json;

namespace Gestao.Client.Services
{
    public class AccountService : IAccountRepository
    {
        private readonly HttpClient _httpClient;

        public AccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task Add(Account entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Account>> FindByCondition(Expression<Func<Account, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<List<Account>> FindByConditionAsync(Expression<Func<Account, bool>> expression, params string[] propertiesToInclude)
        {
            throw new NotImplementedException();
        }


        public Task<List<Account>> GetAll(int companyId)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedList<Account>> GetAll(int companyId, int pageIndex, int pageSize, string searchWord)
        {
            var url = $"/api/accounts?companyId={companyId}&pageIndex={pageIndex}&searchWord={searchWord}";
            var entities = await _httpClient.GetFromJsonAsync<PaginatedList<Account>>(url);

            return entities!;
        }

        public Task<List<Account>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Account?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Account entity)
        {
            throw new NotImplementedException();
        }
    }
}
