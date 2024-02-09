using Microsoft.OData.Edm;

namespace Rosneft.WebApplication.Odata
{
    public interface IConventionModelFactory
    {
        IEdmModel CreateOrGet();
    }
}
