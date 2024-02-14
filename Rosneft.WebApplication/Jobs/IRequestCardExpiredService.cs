namespace Rosneft.WebApplication.Jobs
{
    public interface IRequestCardExpiredService
    {
        Task AutoSetStatusExpired();
    }
}
