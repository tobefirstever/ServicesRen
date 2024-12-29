using Renavi.Transversal.Common;
using RenaviExterno.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenaviExterno.Application.Interfaces
{
 public interface IInteraccionApplication
    {

        Task<Response<InteraccionResponseDto>> InsertInteraccion(InteraccionDto request);
    }
}
