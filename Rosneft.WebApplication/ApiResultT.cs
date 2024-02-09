using Newtonsoft.Json;

namespace Rosneft.WebApplication
{
    public sealed class ApiResult<T> : ApiResult
    {
        [JsonIgnore]
        public bool HasError => !ReferenceEquals(Error, null);
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public T Data { get; private set; }
        public bool ShouldSerializeData() { return !HasError; }
        private ApiResult() : base() { }
        public static ApiResult<T> Succeeded(T value)
        {
            if (!(value is bool) && EqualityComparer<T>.Default.Equals(value, default(T)))
                throw new ArgumentNullException(nameof(value));
            return new ApiResult<T> { Data = value };
        }
        public new static ApiResult<T> CreateFailed(string errorCode,
            string errorMessage, IEnumerable<ApiResult> errors)
        {
            return new ApiResult<T>
            {
                Error = ApiError.CreateFailed(errorCode, errorMessage, errors)
            };
        }
        public static new ApiResult<T> CreateFailed(string errorCode, string errorMessage)
        {
            return CreateFailed(errorCode, errorMessage,
                Enumerable.Empty<ApiResult>());
        }
        public static new ApiResult<T> CreateFormatedFailed(string errorCode, string errorMessage,
            params object[] args)
        {
            return CreateFailed(errorCode,
                string.Format(errorMessage, args), Enumerable.Empty<ApiResult>());
        }
    }
}
