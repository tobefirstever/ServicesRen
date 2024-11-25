using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerbero.Services.Client.Contratos
{
    public class RestDataResponse_pru
    {
        public static readonly int STATUS_OK = 1;
        public static readonly int STATUS_ERROR = 0;

        public Object data { get; set; }
        public int status { get; set; }
        public String message { get; set; }

        public RestDataResponse_pru(Object data, int status, String mensaje)
        {
            this.data = data;
            this.status = status;
            this.message = mensaje;
        }
    }
}
