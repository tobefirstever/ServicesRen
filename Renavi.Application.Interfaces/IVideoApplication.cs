using Renavi.Application.DTO.Dtos.Videos;
using Renavi.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.Interfaces
{
    public interface IVideoApplication
    {
        Task<Response<List<VideosResponseDto>>> GetList();
        Task<Response<IEnumerable<VideosArchivoResponseDto>>> GetArchivo(string ruta );
    }
}
