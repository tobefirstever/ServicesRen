using Renavi.Application.DTO.Dtos.Videos;
using Renavi.Application.Interfaces;
using Renavi.Domain.Entities.Entities;
using Renavi.Domain.Interfaces;
using Renavi.Transversal.Common;
using Renavi.Transversal.Mapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Renavi.Application.Main
{
    public class VideoApplication : IVideoApplication
    {


        public VideoApplication()
        {

        }

        public async Task<Response<IEnumerable<VideosArchivoResponseDto>>> GetArchivo(string ruta)
        {
         
            var response = new Response<IEnumerable<VideosArchivoResponseDto>> { Data = new List<VideosArchivoResponseDto>() };
            var productos = new List<VideosArchivoResponseDto>();
            string directorio = "E:\\ArchivosSistemas\\App";
            string[] directorios = Directory.GetDirectories(directorio);
            var Videos = new List<VideosResponseDto>();

            foreach (string rutaarchivo in directorios)
            {
                string[] ficheros = Directory.GetFiles(rutaarchivo);

                foreach (string archivos in ficheros)
                {

                    var Nombre = Path.GetFileName(archivos);


                    if(Nombre.Contains(ruta))
                    {
                        byte[] result;
                        using (var stream = new StreamReader(archivos))
                        {
                            using (MemoryStream msstream = new MemoryStream())
                            {
                                stream.BaseStream.CopyTo(msstream);
                                result = msstream.ToArray();
                            }

                        }


                        productos.Add(new VideosArchivoResponseDto
                        {
                            archivo = result
                        });

                    }
                }
            }





                response.Data = productos;

                return response;
            
        }

        public async Task<Response<List<VideosResponseDto>>> GetList()
        {
            var response = new Response<List<VideosResponseDto>> { Data = new List<VideosResponseDto>() };

            string directorio = "E:\\ArchivosSistemas\\App";
            string[] directorios = Directory.GetDirectories(directorio);
            var Videos = new List<VideosResponseDto>();

            foreach (string ruta in directorios)
            {
                string[] ficheros = Directory.GetFiles(ruta);

                foreach (string archivos in ficheros)
                {
                   
                    var Nombre = Path.GetFileName(archivos);


                    Videos.Add(new VideosResponseDto
                    {
                        nombre = Nombre.Split('.')[1]
                    });
                }
            }

            response.Data = Videos;
            // IEnumerable<UsuarioEntity> gerenciaEntities = await _usuarioDomain.GetList();

            ///response.Data = Mapping.Map<IEnumerable<UsuarioEntity>, IEnumerable<UsuarioDto>>(gerenciaEntities);
            return response;
        }
    }
}
