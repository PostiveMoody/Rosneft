using Rosneft.WebApplication.Dto;

namespace Rosneft.WebApplication
{
    public static class ApiResultExtensions
    {
        public static ApiResult<T> ToApiResult<T>(this T dto)
        {
            return ApiResult<T>.Succeeded(dto);
        }
        public static PageDto<T> ToPageDto<T>(
            this IEnumerable<T> items,
            int totalCount)
        {
            return new PageDto<T>()
            {
                Items = items.ToArray(),
                TotalCount = totalCount
            };
        }
    }
}
