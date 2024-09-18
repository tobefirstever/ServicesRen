using Dapper.FluentMap.Mapping;
using Renavi.Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Domain.Entities.Mapping
{
    public class ParametroMap : EntityMap<ParametroEntity>
    {
        public ParametroMap()
        {
            Map(p => p.Id).ToColumn("CPAR_ID");
            Map(p => p.Nombre).ToColumn("SPAR_NOMBRE");
            Map(p => p.CodigoAbreviatura).ToColumn("SPAR_ABREVIATURA");
        }
    }
}
