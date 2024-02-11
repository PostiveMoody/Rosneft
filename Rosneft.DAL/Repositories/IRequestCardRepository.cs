using Microsoft.EntityFrameworkCore;
using Rosneft.Domain;

namespace Rosneft.DAL.Repositories
{
    public interface IRequestCardRepository
    {
        public DbSet<RequestCard> RequestCards();
        public void AddToContext(RequestCard requestCard);
    }
}
