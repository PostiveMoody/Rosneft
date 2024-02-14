using Rosneft.Domain.Exceptions;

namespace Rosneft.Domain
{
    /// <summary>
    /// Карточка обращения
    /// </summary>
    public class RequestCard
    {
        public int RequestCardId { get; private set; }
        public string Initiator { get; private set; }
        public string SubjectOfAppeal { get; private set; }
        public string Description { get; private set; }
        public DateTime DeadlineForHiring { get; private set; }
        public string Status { get; private set; }
        public string? Category { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime UpdatedDate { get; private set; }
        public int RequestCardVersion { get; private set; }
        public bool IsDeleted { get; private set; }

        public static RequestCard Save(
            DateTime now,
            string initator,
            string subjectOfAppeal,
            string description,
            DateTime deadlineForHiring,
            RequestCategory category)
        {
            if (now == default)
                throw new DomainException("Invalid DateTime: " + nameof(now));

            if (string.IsNullOrEmpty(initator) &&
                initator.Length > 150 &&
                initator.Any(char.IsDigit))
            {
                throw new DomainException("Invalid string: " +
                   nameof(initator) +
                   "The maximum number of characters to enter in the Initiator field is 150 characters.");
            }
            if (string.IsNullOrEmpty(subjectOfAppeal) &&
               subjectOfAppeal.Any(char.IsDigit))
            {
                throw new DomainException("Invalid string: " +
                    nameof(subjectOfAppeal));
            }
            if (string.IsNullOrEmpty(description) &&
                description.Length > 1000)
            {
                throw new DomainException("Invalid string: " +
                    nameof(description) +
                    "The maximum number of characters to enter in the Description field is 1000 characters.");
            }
            if (deadlineForHiring == default ||
                deadlineForHiring < now)
            {
                throw new DomainException("Invalid DateTime: " +
                    nameof(deadlineForHiring));
            }

            return new RequestCard
            {
                Initiator = initator,
                SubjectOfAppeal = subjectOfAppeal,
                Description = description,
                DeadlineForHiring = deadlineForHiring,
                Status = RequestProgressStatus.New.ToString(),
                Category = category.ToString(),
                CreationDate = now,
                UpdatedDate = now,
                RequestCardVersion = 1,
                IsDeleted = false,
            };
        }

        public void Delete(DateTime now, int requestCardVersion)
        {
            CheckVersion(requestCardVersion);

            this.IsDeleted = true;
            this.UpdatedDate = now;
            this.RequestCardVersion += 1;
        }

        public void Update(
            DateTime now, 
            string initator,
            string subjectOfAppeal,
            string description,
            DateTime deadlineForHiring,
            RequestCategory category,
            int requestCardVersion)
        {
            if (string.IsNullOrEmpty(initator) &&
               initator.Length > 150 &&
               initator.Any(char.IsDigit))
            {
                throw new DomainException("Invalid string: " +
                   nameof(initator) +
                   "The maximum number of characters to enter in the Initiator field is 150 characters.");
            }
            if (string.IsNullOrEmpty(subjectOfAppeal) &&
               subjectOfAppeal.Any(char.IsDigit))
            {
                throw new DomainException("Invalid string: " +
                    nameof(subjectOfAppeal));
            }
            if (string.IsNullOrEmpty(description) &&
                description.Length > 1000)
            {
                throw new DomainException("Invalid string: " +
                    nameof(description) +
                    "The maximum number of characters to enter in the Description field is 1000 characters.");
            }
            if (deadlineForHiring == default ||
                deadlineForHiring < now)
            {
                throw new DomainException("Invalid DateTime: " +
                    nameof(deadlineForHiring));
            }

            CheckVersion(requestCardVersion);

            this.Initiator = initator;
            this.SubjectOfAppeal = subjectOfAppeal;
            this.Description = description;
            this.DeadlineForHiring = deadlineForHiring;
            this.Category = category.ToString();
            this.UpdatedDate = now;
            this.RequestCardVersion += 1;
        }

        public void SetStatusExpired(string status)
        {
            if (string.IsNullOrEmpty(status))
                throw new DomainException(nameof(status) + "is null or empty method: SetStatusExpired");

            this.Status = status;
        }

        private void CheckVersion(int requestCardVersion)
        {
            if (requestCardVersion != this.RequestCardVersion)
            {
                throw new AlreadyChangedException(
                    $"The state of request card # {this.RequestCardId} has been changed by another user");
            }
        }
    }
}
