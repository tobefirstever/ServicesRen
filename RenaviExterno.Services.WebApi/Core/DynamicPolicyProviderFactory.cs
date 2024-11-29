using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web.Cors;
using System.Web.Http.Cors;
//using Renavi.Transversal.Common;

namespace RenaviExterno.Services.WebApi.Core
{
    public class DynamicPolicyProviderFactory : ICorsPolicyProviderFactory
    {
        public ICorsPolicyProvider GetCorsPolicyProvider(HttpRequestMessage request)
        {
            var corsRequestContext = request.GetCorsRequestContext();
            var originRequested = corsRequestContext.Origin;
            var policy = GetPolicyForControllerAndOrigin(originRequested);
            return new CustomPolicyProvider(policy);
        }
        private CorsPolicy GetPolicyForControllerAndOrigin(string originRequested)
        {
            var origins = ConfigurationManager.AppSettings["Access-Control-Allow-Origin"];
            if(origins.Split(',').Any(p=> p == originRequested))
            {
                var policy = new CorsPolicy();
                policy.Origins.Add(originRequested);
                policy.AllowAnyHeader = true;
                policy.AllowAnyMethod = true;
                return policy;
            }
            return null;
        }
    }
}