using Renavi.Transversal.Common;
using RenaviExterno.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenaviExterno.Services.Interfaces
{
    public interface IUbigeoService
    {

        Task<Response<List<UbigeoResponseDto>>> GetList(UbigeoDto request);

        Task<Response<List<UbigeoResponseDto>>> GetListAll();
    }
}
