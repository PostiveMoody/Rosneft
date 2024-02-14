using Quartz;
using Rosneft.WebApplication.Jobs;

namespace Rosneft.WebApplication.Services
{
    public class RequestCardExpiredJob : IJob
    {
        private readonly IRequestCardExpiredService _cardExpiredService;

        public RequestCardExpiredJob(IRequestCardExpiredService cardExpiredService)
        {
            _cardExpiredService = cardExpiredService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _cardExpiredService.AutoSetStatusExpired();
        }
    }
}
