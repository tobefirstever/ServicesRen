using System;

namespace Renavi.Domain.Entities.Custom
{
    public class NLog: BaseCustomClass
    {
        public int Id { get; set; }
        public string Hostname { get; set; }
        public string Mensaje { get; set; }
        public DateTime FechaHora { get; set; }
    }
}