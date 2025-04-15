
using Gestao.Domain;
using Gestao.Database;


namespace Gestao.Database.Repositories
{
    public class DocumentRepository : Repository<Document>
    {
        private readonly AppDbContext _db;
        
        public DocumentRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
