using Dapper.FluentMap.Mapping;
using Renavi.Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Domain.Entities.Mapping
{
    public class PersonaMap : EntityMap<PersonaEntity>
    {
        public PersonaMap()
        {
            Map(p => p.IdPersona).ToColumn("CPER_ID");
            Map(p => p.IdTipoDocumento).ToColumn("CPER_ID_DOCUMENTO");
            Map(p => p.Nombre).ToColumn("SPER_NOMBRE");
            Map(p => p.ApellidoPaterno).ToColumn("SPER_APELLIDO_PATERNO");
            Map(p => p.ApellidoMaterno).ToColumn("SPER_APELLIDO_MATERNO");
            Map(p => p.UsuarioRegistro).ToColumn("SPER_USU_REG");
            Map(p => p.FechaCreacion).ToColumn("DPER_FEC_REG");
            Map(p => p.UsuarioModificacion).ToColumn("SPER_USU_ACT");
            Map(p => p.FechaModificacion).ToColumn("DPER_FEC_ACT");
            Map(p => p.DireccionDomicilio.IdDireccion).ToColumn("CPER_ID_DIRECCION");
            Map(p => p.InformacionContacto.IdContacto).ToColumn("CPER_ID_CONTACTO");
            Map(p => p.NroDocumento).ToColumn("SPER_NRO_DOCUMENTO");

        }
    }
}
