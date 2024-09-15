using System;

namespace Renavi.Application.DTO
{
    public class NLogDto
    {
        public int Id { get; set; }
        public string Hostname { get; set; }
        public string Mensaje { get; set; }
        public DateTime FechaHora { get; set; }
        public int Cantidad { get; set; }
    }
}
