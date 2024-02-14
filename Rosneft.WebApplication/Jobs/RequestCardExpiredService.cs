using Rosneft.DAL;
using Rosneft.Domain;

namespace Rosneft.WebApplication.Jobs
{
    public class RequestCardExpiredService : IRequestCardExpiredService
    {
        private readonly IUnitOfWork _uow;
        public RequestCardExpiredService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task AutoSetStatusExpired()
        {
            var now = DateTime.Now;
            var requiredDate = now.AddDays(-1);
            var requestCardsExpired = _uow.RequestCardRepository.RequestCards()
                .Where(requestCard => requestCard.Status == RequestProgressStatus.New.ToString() &&
                requestCard.CreationDate <= requiredDate).ToList();

            if(requestCardsExpired.Count > 0)
            {
                foreach(var requestCardExpired in requestCardsExpired)
                {
                    requestCardExpired.SetStatusExpired(RequestProgressStatus.Expired.ToString());
                }
            }

            await _uow.SaveChangesAsync();
        }
    }
}
