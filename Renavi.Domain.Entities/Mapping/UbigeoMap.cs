using Dapper.FluentMap.Mapping;
using Renavi.Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Domain.Entities.Mapping
{
    public class UbigeoMap : EntityMap<UbigeoEntity>
    {
        public UbigeoMap()
        {
            Map(p => p.IdUbigeo).ToColumn("CUBI_ID");
            Map(p => p.IdDepartamento).ToColumn("CUBI_ID_DEP");
            Map(p => p.IdProvincia).ToColumn("CUBI_ID_PROV");
            Map(p => p.IdDistrito).ToColumn("CUBI_ID_DIST");
            Map(p => p.Nombre).ToColumn("SUBI_NOMBRE");
            Map(p => p.Latitud).ToColumn("LATITUD");
            Map(p => p.Longitud).ToColumn("LONGITUD");
        }
    }
}
