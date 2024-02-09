namespace Rosneft.Domain
{
    public class RequestCardUpdateOptions
    {
        public RequestCardUpdateOptions(
            string initator,
            string subjectOfAppeal,
            string description,
            DateTime deadlineForHiring,
            int? category,
            int requestCardVersion)
        {
            Initiator = initator;
            SubjectOfAppeal = subjectOfAppeal;
            Description = description;
            DeadlineForHiring = deadlineForHiring;
            Category = category == null ? null : (RequestCategory)category;
            RequestCardVersion = requestCardVersion;
        }

        public string Initiator { get; private set; }
        public string SubjectOfAppeal { get; private set; }
        public string Description { get; private set; }
        public DateTime DeadlineForHiring { get; private set; }
        public RequestCategory? Category { get; private set; }
        public int RequestCardVersion { get; set; }
    }
}
