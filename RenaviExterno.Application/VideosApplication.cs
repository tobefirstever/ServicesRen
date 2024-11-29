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
    public class VideosApplication: IVideosApplication
    {

        private readonly IVideosService _videoservice;

        public VideosApplication(IVideosService videoservice)
        {
            _videoservice = videoservice;
        }
        public async  Task<Response<List<VideosResponseDto>>> GetList()
        {
            return await _videoservice.GetList();
        }

      public async  Task<Response<List<VideosArchivoResponseDto>>> GetArchivo(string ruta)
        {
            return await _videoservice.GetArchivo(ruta);
        }
    }
}
