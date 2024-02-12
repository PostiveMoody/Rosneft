using Rosneft.DAL.Repositories;

namespace Rosneft.DAL
{
    public interface IUnitOfWork
    {
        IRequestCardRepository RequestCardRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
