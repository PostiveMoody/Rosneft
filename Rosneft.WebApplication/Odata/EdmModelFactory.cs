using Community.OData.Linq;
using Microsoft.OData.Edm;
using Rosneft.WebApplication.Dto;

namespace Rosneft.WebApplication.Odata
{
    public class EdmModelFactory : IConventionModelFactory
    {
        private readonly object _lockObject = new object();
        private IEdmModel _model;

        public IEdmModel CreateOrGet()
        {
            if (_model != null)
                return _model;

            lock (_lockObject)
            {
                if (_model != null)
                    return _model;

                var builder = new ODataConventionModelBuilder();

                {
                    var entityType = builder.EntityType<RequestCardDto>();
                    entityType.HasKey(x => x.RequestCardId);
                    entityType.Property(x => x.Initiator);
                    entityType.Property(x => x.SubjectOfAppeal);
                    entityType.Property(x => x.DeadlineForHiring);
                    entityType.Property(x => x.Status);
                    entityType.Property(x => x.Category);
                    entityType.Property(x => x.CreationDate);

                    builder.EntitySet<RequestCardDto>(nameof(RequestCardDto));
                }


                _model = builder.GetEdmModel();
                return _model;
            }
        }
    }
}
