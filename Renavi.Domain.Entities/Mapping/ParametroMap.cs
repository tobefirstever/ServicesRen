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
            Map(p => p.IdParametro).ToColumn("ID_PARAM");
            Map(p => p.CodigoParametro).ToColumn("COD_PARAM");
            Map(p => p.IdDetalleParametro).ToColumn("ID_DET_PARAM");
            Map(p => p.CodigoDetalleParametro).ToColumn("COD_DET_PARAM");
            Map(p => p.Descripcion).ToColumn("DESC_DET_PARAM");
            Map(p => p.Valor1).ToColumn("VAL1");
            Map(p => p.Valor2).ToColumn("VAL2");
            Map(p => p.Valor3).ToColumn("VAL3");

        }
    }
}
