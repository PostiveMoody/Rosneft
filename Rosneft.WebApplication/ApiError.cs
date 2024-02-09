using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Rosneft.WebApplication
{
    public class ApiError
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; protected set; }

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; protected set; }

        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public ApiResult[] Errors { get; protected set; }
        public bool ShouldSerializeErrors()
        {
            return Errors != null && Errors.Length != 0;
        }
        private ApiError() { }
        public static ApiError CreateFailed(string errorCode,
            string errorMessage, IEnumerable<ApiResult> errors)
        {
            if (string.IsNullOrWhiteSpace(errorCode))
                throw new ArgumentNullException(nameof(errorCode));
            if (string.IsNullOrWhiteSpace(errorMessage))
                throw new ArgumentNullException(nameof(errorMessage));
            if (ReferenceEquals(errors, null))
                throw new ArgumentNullException(nameof(errors));
            return new ApiError
            {
                Code = errorCode,
                Message = errorMessage,
                Errors = errors.ToArray()
            };
        }
    }
}
