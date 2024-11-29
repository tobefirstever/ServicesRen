using Renavi.Application.DTO.Dtos.Ubigeo;
using Renavi.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.Interfaces
{
    public interface IUbigeoApplication
    {
        Task<IEnumerable<UbigeoResponseDto>> GetList(UbigeoDto request);
    }
}
