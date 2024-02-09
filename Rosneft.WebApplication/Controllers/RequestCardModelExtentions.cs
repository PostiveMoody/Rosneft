using Rosneft.Domain;
using Rosneft.WebApplication.Dto;

namespace Rosneft.WebApplication.Controllers
{
    public static class RequestCardModelExtentions
    {
        public static RequestCardDto ToDto(this RequestCard requestCardModel)
        {
            return new RequestCardDto()
            {
                RequestCardId = requestCardModel.RequestCardId,
                Initiator = requestCardModel.Initiator,
                SubjectOfAppeal = requestCardModel.SubjectOfAppeal,
                Description = requestCardModel.Description,
                DeadlineForHiring = requestCardModel.DeadlineForHiring,
                Status = requestCardModel.Status.ToString(),
                Category = requestCardModel.Category.ToString(),
                CreationDate = requestCardModel.CreationDate,
                RequestCardVersion = requestCardModel.RequestCardVersion,
                IsDeleted = requestCardModel.IsDeleted,
            };
        }
    }
}
