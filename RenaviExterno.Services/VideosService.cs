using Renavi.Transversal.Common;
using RenaviExterno.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenaviExterno.Services.Interfaces
{
    public class VideosService : IVideosService
    {
        public async Task<Response<List<VideosArchivoResponseDto>>> GetArchivo(string ruta)
        {
            var response = new Response<List<VideosArchivoResponseDto>> { Data = new List<VideosArchivoResponseDto>() };
            var productos = new List<VideosArchivoResponseDto>();
            string directorio = ConfigurationManager.AppSettings?["UrlVideos"]?.ToString();
            string[] directorios = Directory.GetDirectories(directorio);
            var Videos = new List<VideosResponseDto>();

            foreach (string rutaarchivo in directorios)
            {
                string[] ficheros = Directory.GetFiles(rutaarchivo);

                foreach (string archivos in ficheros)
                {

                    var Nombre = Path.GetFileName(archivos);


                    if (Nombre.Contains(ruta))
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

            string directorio = ConfigurationManager.AppSettings?["UrlVideos"]?.ToString(); ;
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
            return response;
        }
    }
}
