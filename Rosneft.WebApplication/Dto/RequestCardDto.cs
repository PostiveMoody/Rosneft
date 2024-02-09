using Newtonsoft.Json;

namespace Rosneft.WebApplication.Dto
{
    public class RequestCardDto
    {
        [JsonProperty("requestCardId")]
        public int RequestCardId { get; set; }
        [JsonProperty("initiator")]
        public string Initiator { get; set; }
        [JsonProperty("subjectOfAppeal")]
        public string SubjectOfAppeal { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("deadlineForHiring")]
        public DateTime DeadlineForHiring { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("creationDate")]
        public DateTime CreationDate { get; set; }
        [JsonProperty("requestCardVersion")]
        public int RequestCardVersion { get; set; }
        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }
    }
}
