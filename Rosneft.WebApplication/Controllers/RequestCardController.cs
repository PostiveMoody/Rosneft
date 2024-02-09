using Community.OData.Linq;
using Microsoft.AspNetCore.Mvc;
using Rosneft.DAL;
using Rosneft.Domain;
using Rosneft.WebApplication.Dto;
using Rosneft.WebApplication.Odata;

namespace Rosneft.WebApplication.Controllers
{
    [Route("requestcards")]
    public class RequestCardController : Controller
    {
        private readonly RosneftDbContext _dbContext;
        private readonly IConventionModelFactory _modelFactory;

        public RequestCardController(RosneftDbContext dbContext, IConventionModelFactory modelFactory)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _modelFactory = modelFactory ?? throw new ArgumentNullException(nameof(modelFactory));
        }

        /// <summary>
        /// Создать карточку обращения
        /// </summary>
        /// <param name="creationOptions"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPost]
        public ApiResult<RequestCardDto> Post([FromBody] RequestCardCreationOptionsDto creationOptions)
        {
            if (creationOptions == null)
                throw new ArgumentNullException(nameof(creationOptions));

            var now = DateTime.UtcNow;
            
            var requestCardCreationOptions = new RequestCardCreationOptions(
                creationOptions.Initiator,
                creationOptions.SubjectOfAppeal,
                creationOptions.Description,
                creationOptions.DeadlineForHiring,
                creationOptions.Category);


            var requestCard = RequestCard.Save(now, requestCardCreationOptions);

            _dbContext.Add(requestCard);
            _dbContext.SaveChanges();

            return requestCard
                .ToDto()
                .ToApiResult();
        }

        [HttpGet]
        [Route("")]
        public ApiResult<PageDto<RequestCardDto>> Get(string filter
            , string top
            , string skip
            , string orderby)
        {
            var qData = _dbContext.RequestCards
                .Where(requestCard => requestCard.IsDeleted == false)
                .Select(requestCard => new RequestCardDto()
            {
                RequestCardId = requestCard.RequestCardId,
                Initiator = requestCard.Initiator,
                SubjectOfAppeal = requestCard.SubjectOfAppeal,
                Description = requestCard.Description,
                DeadlineForHiring = requestCard.DeadlineForHiring,
                Status = requestCard.Status,
                Category = requestCard.Category,
                CreationDate = requestCard.CreationDate,
                RequestCardVersion = requestCard.RequestCardVersion,
                IsDeleted = requestCard.IsDeleted
            }).OData(edmModel: _modelFactory.CreateOrGet());

            if (!string.IsNullOrEmpty(filter))
            {
                qData = qData.Filter(filter);
            }

            var totalCount = qData.Count();

            if (!string.IsNullOrEmpty(orderby))
            {
                qData = qData.OrderBy(orderby);
            }

            if (!string.IsNullOrEmpty(top) && !string.IsNullOrEmpty(skip))
            {
                qData = qData.TopSkip(top, skip);
            }

            var result = qData.ToArray();

            return new PageDto<RequestCardDto>()
            {
                Items = result,
                TotalCount = totalCount,
            }.ToApiResult();
        }

        [HttpGet]
        [Route("{requestCardId}")]
        public ApiResult<RequestCardDto> Get(int requestCardId)
        {
            var requestCard = _dbContext.RequestCards
                .FirstOrDefault(requestCard => requestCard.RequestCardId == requestCardId);

            if (requestCard == null || requestCard.IsDeleted)
            {
                return ApiResult<RequestCardDto>.CreateFailed(
                    Errors.NotFound.Code,
                    $"RequestCard # {requestCardId} nof found.");
            }

            return requestCard
                .ToDto()
                .ToApiResult();
        }

        [HttpDelete]
        [Route("{requestCardId}")]
        public ApiResult<RequestCardDto> Delete(int requestCardId,int requestCardVersion)
        {
            var requestCard = _dbContext.RequestCards
                .FirstOrDefault(requestCard => requestCard.RequestCardId == requestCardId);
            
            if (requestCard == null || requestCard.IsDeleted)
            {
                return ApiResult<RequestCardDto>.CreateFailed(
                    Errors.NotFound.Code,
                    $"RequestCard # {requestCardId} nof found.");
            }

            var now = DateTime.UtcNow;
            requestCard.Delete(now, requestCardVersion);
            _dbContext.SaveChanges();

            return requestCard
               .ToDto()
               .ToApiResult();
        }

        [HttpPut]
        [Route("{requestCardId}")]
        public ApiResult<RequestCardDto> Put(int requestCardId, 
            RequestCardUpdateOptionsDto options)
        {
            var requestCard = _dbContext.RequestCards
                .FirstOrDefault(requestCard => requestCard.RequestCardId == requestCardId);

            if (requestCard == null || requestCard.IsDeleted)
            {
                return ApiResult<RequestCardDto>.CreateFailed(
                    Errors.NotFound.Code,
                    $"RequestCard # {requestCardId} nof found.");
            }

            var requestCardUpdateOptions = new RequestCardUpdateOptions(
                options.Initiator, 
                options.SubjectOfAppeal,
                options.Description,
                options.DeadlineForHiring,
                options.Category,
                options.RequestCardVersion);

            var now = DateTime.UtcNow;
            requestCard.Update(now, requestCardUpdateOptions);
            _dbContext.SaveChanges();

            return requestCard
               .ToDto()
               .ToApiResult();
        }
    }
}
