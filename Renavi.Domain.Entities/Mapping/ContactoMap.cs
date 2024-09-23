using Dapper.FluentMap.Mapping;
using Renavi.Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Domain.Entities.Mapping
{
    public class ContactoMap : EntityMap<ContactoEntity>
    {
        public ContactoMap()
        {
            Map(p => p.IdContacto).ToColumn("CCNT_ID");
            Map(p => p.NroCelular).ToColumn("SCNT_NROCELULAR");
            Map(p => p.Correo).ToColumn("SCNT_CORREO");
            Map(p => p.UsuarioRegistro).ToColumn("SCNT_USU_REG");
            Map(p => p.FechaCreacion).ToColumn("DCNT_FEC_REG");
            Map(p => p.UsuarioModificacion).ToColumn("SCNT_USU_ACT");
            Map(p => p.FechaModificacion).ToColumn("DCNT_FEC_ACT");
        }
    }
}
