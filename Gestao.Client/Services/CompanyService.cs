using Gestao.Client.Libraries.Utilities;
using Gestao.Database.Interface;
using Gestao.Domain;
using System.Linq.Expressions;
using System.Net.Http.Json;

namespace Gestao.Client.Services
{
    public class CompanyService : ICompanyRepository
    {
        private readonly HttpClient _httpClient;

        public CompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task Add(Company company)
        {
            throw new NotImplementedException();
        }

        public Task<List<Company>> FindByCondition(Expression<Func<Company, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<List<Company>> FindByConditionAsync(Expression<Func<Company, bool>> expression, params string[] propertiesToInclude)
        {
            throw new NotImplementedException();
        }

        public Task<Company?> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedList<Company>> GetAll(Guid applicationUserId, int pageIndex, int pageSize, string searchWord)
        {
            var url = $"/api/companies?applicationUserId={applicationUserId}&pageIndex={pageIndex}&searchWord={searchWord}";
            var entities = await _httpClient.GetFromJsonAsync<PaginatedList<Company>>(url);

            return entities!;
        }

        public Task<List<Company>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Company?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Company obj)
        {
            throw new NotImplementedException();
        }
    }
}
