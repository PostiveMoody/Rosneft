using Newtonsoft.Json;

namespace Rosneft.WebApplication.Dto
{
    public class RequestCardCreationOptionsDto
    {
        [JsonProperty("initiator")]
        public string Initiator { get; set; }
        [JsonProperty("subjectOfAppeal")]
        public string SubjectOfAppeal { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("deadlineForHiring")]
        public DateTime DeadlineForHiring { get; set; }
        [JsonProperty("category")]
        public int? Category { get; set; }
    }
}
