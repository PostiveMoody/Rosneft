using Rosneft.DAL.Repositories;
using Rosneft.Domain;

namespace Rosneft.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<RequestCard> _requestCardRepo;
        private RosneftDbContext _context;

        public UnitOfWork(RosneftDbContext context)
        {
            _context = context;
        }

        public IRequestCardRepository RequestCardRepository
        {
            get
            {
                return new RequestCardRepository(_context);
            }
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }
        public Task SaveChangesAsync()
        {
            this._context.SaveChangesAsync();
            return Task.CompletedTask;
        }

    }
}
