using Newtonsoft.Json;
 
using System;
using System.Linq;
using System.Security.Claims;
using System.Web;


namespace Renavi.Transversal.Common
{
    public class BaseClass
    {
        

        public BaseClass()
        {
            var loginClaim = HttpContext.Current.User.Identity;
            var claimsIdentity = loginClaim as ClaimsIdentity;
            if (claimsIdentity != null && claimsIdentity.Claims.FirstOrDefault(x => x.Type == "LoginModel") != null)
            {
                string loginClaimString = claimsIdentity.Claims.FirstOrDefault(x => x.Type == "LoginModel")?.Value;
                var loginModel = JsonConvert.DeserializeObject<LoginModel>(loginClaimString);
              
            }
        }

        
    }
}
