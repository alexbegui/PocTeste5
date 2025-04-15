using Gestao.Client.Libraries.Utilities;
using Gestao.Data;
using Gestao.Database.Interface;
using Gestao.Domain;
using System.Linq.Expressions;
using System.Net.Http.Json;

namespace Gestao.Client.Services
{
    public class CategoryService(HttpClient httpClient) : ICategoryRepository
    {
        private readonly HttpClient _httpClient = httpClient;

        public Task Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> FindByCondition(Expression<Func<Category, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> FindByConditionAsync(Expression<Func<Category, bool>> expression, params string[] propertiesToInclude)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedList<Category>> GetAll(int companyId, int pageIndex, int pageSize)
        {
            var url = $"/api/categories?companyId={companyId}&pageIndex={pageIndex}";
            var entities = await _httpClient.GetFromJsonAsync<PaginatedList<Category>>(url);

            return entities!;
        }

        public Task<List<Category>> GetAll(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Category?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Category obj)
        {
            throw new NotImplementedException();
        }
    }
}
