using Gestao.Client.Libraries.Utilities;
using Gestao.Database.Interface;
using Gestao.Domain;
using Gestao.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Database.Repositories
{
    public class FinancialTransactionRepository : Repository<FinancialTransaction>, IFinancialTransactionRepository
    {
        private readonly AppDbContext _db;
        
        public FinancialTransactionRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<PaginatedList<FinancialTransaction>> GetAll(int companyId, TypeFinancialTransaction type, int pageIndex, int pageSize, string searchWord = "")
        {
            var query = _db.FinancialTransactions.AsQueryable();

            var items = await query
                .Where(a => a.CompanyId == companyId && a.TypeFinancialTransaction == type)
                .Where(a => a.Description.Contains(searchWord))
                .OrderByDescending(a => a.ReferenceDate)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .Include(a => a.Category)
                .Include(a => a.Account)
                .Include(a => a.Documents)
                .ToListAsync();

            var count = await query
                .Where(a => a.CompanyId == companyId && a.TypeFinancialTransaction == type)
                .Where(a => a.Description.Contains(searchWord))
                .CountAsync();

            int totalPages = (int)Math.Ceiling((decimal)count / pageSize);

            return new PaginatedList<FinancialTransaction>(items, pageIndex, totalPages);
        }

        public async Task<List<FinancialTransaction>> GetTransactionsSameGroup(int Id)
        {
            return await _db.FinancialTransactions
                .Where(a => a.RepeatGroup == Id)
                .OrderBy(a => a.Id)
                .ToListAsync();
        }

        public async Task<int> GetCountTransactionsSameGroup(int Id)
        {
            return await _db.FinancialTransactions
                .Where(a => a.RepeatGroup == Id)
                .CountAsync();
        }
    }
}
