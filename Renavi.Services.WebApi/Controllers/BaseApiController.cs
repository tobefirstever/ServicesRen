using System.Web.Http;

namespace Renavi.Services.WebApi.Controllers
{
    /// <summary>
    /// BaseApiController
    /// </summary>
    [Authorize]
    public class BaseApiController : ApiController
    {
    }
}