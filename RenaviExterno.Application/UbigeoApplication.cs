using Renavi.Transversal.Common;
using RenaviExterno.DTO;
using RenaviExterno.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenaviExterno.Application.Interfaces
{
    public class UbigeoApplication : IUbigeoApplication
    {

        private readonly IUbigeoService _ubigeoService;

        public UbigeoApplication(IUbigeoService ubigeoService)
        {
            _ubigeoService = ubigeoService;
        }

        public async Task<Response<List<UbigeoResponseDto>>> GetList(UbigeoDto request)
        {
            return await _ubigeoService.GetList(request);
        }
    }
}
