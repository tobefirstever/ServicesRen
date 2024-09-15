using Renavi.Application.DTO.Dtos.OfertaInmobiliaria;
using Renavi.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.Interfaces
{
    public interface IOfertaInmobiliariaApplication
    {
        Task<Response<IEnumerable<OfertaInmobiliariaDto>>> GetList();
    }
}
