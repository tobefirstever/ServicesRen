using Dapper.FluentMap.Mapping;
using Renavi.Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Domain.Entities.Mapping
{
    public class GerenciaMap : EntityMap<GerenciaEntity>
    {
        public GerenciaMap()
        {
            Map(p => p.Id).ToColumn("CGER_ID");
            Map(p => p.Nombre).ToColumn("SGER_NOMBRE");
            Map(p => p.Estado).ToColumn("FGER_ESTADO");
        }
    }
}
