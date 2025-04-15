using Gestao.Client.Libraries.Utilities;
using Gestao.Database.Interface;
using Gestao.Domain;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Database.Repositories
{
    public class CategoryRepository : Repository<Category> , ICategoryRepository
    {
        private readonly AppDbContext _db;
        
        public CategoryRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<PaginatedList<Category>> GetAll(int companyId, int pageIndex, int pageSize)
        {
            var query = _db.Categories.AsQueryable();

            var items = await query.Where(a => a.CompanyId == companyId)
                .OrderBy(a => a.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();


            var count = await _db.Categories.Where(a => a.CompanyId == companyId).CountAsync();
            int totalPages = (int)Math.Ceiling((decimal)count / pageSize);

            return new PaginatedList<Category>(items, pageIndex, totalPages);
        }

        public Task<List<Category>> GetAll(int companyId)
        {
            throw new NotImplementedException();
        }
    }
}
