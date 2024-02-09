namespace Rosneft.Domain
{
    public class RequestCardCreationOptions
    {
        public RequestCardCreationOptions(
            string initator,
            string subjectOfAppeal,
            string description,
            DateTime deadlineForHiring,
            int? category)
        {
            Initiator = initator;
            SubjectOfAppeal = subjectOfAppeal;
            Description = description;
            DeadlineForHiring = deadlineForHiring;
            Category = category == null ? null : (RequestCategory)category;
        }

        public string Initiator { get; private set; }
        public string SubjectOfAppeal { get; private set; }
        public string Description { get; private set; }
        public DateTime DeadlineForHiring { get; private set; }
        public RequestCategory? Category { get; private set; }
    }
}
