using Renavi.Infrastructure.Services.ServiceCabiel;
using System.Data;
using System.Threading.Tasks;

namespace Renavi.Infrastructure.Services.Cabiel.Base
{
    public partial interface IClientCabiel
    {
        ServicioWEBSoapClient GetServicioWEBSoapClient();

        Task<DataTable> GetEntidadesTecnicas(string razonSocial,string ruc,string departamento,string clasificacion);
    }
}
