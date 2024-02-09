using Newtonsoft.Json;

namespace Rosneft.WebApplication
{
    public class ApiResult
    {
        [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
        public ApiError Error { get; protected set; }
        protected ApiResult() { }
        public static ApiResult CreateFailed(string errorCode,
            string errorMessage, IEnumerable<ApiResult> errors)
        {
            return new ApiResult
            {
                Error = ApiError.CreateFailed(errorCode, errorMessage, errors)
            };
        }

        public static ApiResult CreateFailed(string errorCode, string errorMessage)
        {
            return CreateFailed(errorCode, errorMessage,
                Enumerable.Empty<ApiResult>());
        }
        public static ApiResult CreateFormatedFailed(string errorCode, string errorMessage,
            params object[] args)
        {
            return CreateFailed(errorCode,
                string.Format(errorMessage, args), Enumerable.Empty<ApiResult>());
        }

        public static ApiResult Succeeded()
        {
            return new ApiResult();
        }
    }
}
