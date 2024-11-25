using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerbero.Services.Client.Contratos
{

    public class RespuestaCerbero
    {
        public RestDataResponse response { get; set; }
    }

 
    public class RestDataResponse
    {

        private static readonly int STATUS_OK = 1;

        private static readonly int STATUS_ERROR = 0;


    }
}
