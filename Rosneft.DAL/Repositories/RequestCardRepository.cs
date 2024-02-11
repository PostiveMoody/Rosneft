using Microsoft.EntityFrameworkCore;
using Rosneft.Domain;

namespace Rosneft.DAL.Repositories
{
    public class RequestCardRepository : Repository<RequestCard>, IRequestCardRepository
    {
        public RosneftDbContext dbContext;

        public RequestCardRepository(RosneftDbContext dbContext)
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public DbSet<RequestCard> RequestCards()
        {
            return this.dbContext.RequestCards;
        }

        public void AddToContext(RequestCard requestCard)
        {
            this.dbContext.Add(requestCard);
        }
    }
}
