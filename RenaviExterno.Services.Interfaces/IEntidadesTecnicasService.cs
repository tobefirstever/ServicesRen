using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renavi.Transversal.Common;
using RenaviExterno.DTO;

namespace RenaviExterno.Services.Interfaces
{
   public interface IEntidadesTecnicasService
    {
        Task<Response<EntidadesTecnicasResponseDto>> GetList(EntidadesTecnicasDto request);
    }
}
