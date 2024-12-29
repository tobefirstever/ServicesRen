using Dapper.FluentMap.Mapping;
using Renavi.Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Domain.Entities.Mapping
{
    public class DireccionMap : EntityMap<DireccionEntity>
    {
        public DireccionMap()
        {
            Map(p => p.IdDireccion).ToColumn("CDIR_ID");
            Map(p => p.IdTipoVia).ToColumn("CDIR_ID_TIPOVIA");
            Map(p => p.Nombre).ToColumn("SDIR_NOMBRE");
            Map(p => p.Nro).ToColumn("SDIR_NRO");
            Map(p => p.Mza).ToColumn("SDIR_MANZAN");
            Map(p => p.Lote).ToColumn("SDIR_LOTE");
            Map(p => p.IdDepartamento).ToColumn("CDIR_ID_DEP");
            Map(p => p.IdProvincia).ToColumn("CDIR_ID_PROV");
            Map(p => p.IdDistrito).ToColumn("CDIR_ID_DIST");
            Map(p => p.IdTipoDomicilio).ToColumn("CDIR_ID_TIPODOM");
            Map(p => p.DireccionReferencia).ToColumn("SDIR_REFERENCIA");
            Map(p => p.CodigoPostal).ToColumn("SDIR_COD_POSTAL");
            Map(p => p.Latitud).ToColumn("NDIR_LATITUD");
            Map(p => p.Longitud).ToColumn("NDIR_LONGITUD");
            Map(p => p.UsuarioRegistro).ToColumn("SDIR_USU_REG");
            Map(p => p.FechaCreacion).ToColumn("DDIR_FEC_REG");
            Map(p => p.UsuarioModificacion).ToColumn("SDIR_USU_ACT");
            Map(p => p.FechaModificacion).ToColumn("DDIR_FEC_ACT");
        }
    }
}
