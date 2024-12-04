using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.DTO.Dtos.Usuario
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Contrasena { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
    }

    public class PerfilRequestDto
    {
        public PersonaDto InformacionPersonal { get; set; } = new PersonaDto();

        public string UsuarioCreacion { get; set; }
    }

 

    public class PersonaDto
    {
        public int IdPersona { get; set; }

        public int IdTipoDocumento { get; set; }

        public string NroDocumento { get; set; }

        public string Nombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public DireccionDto DireccionDomicilio { get; set; } = new DireccionDto();

        public ContactoDto InformacionContacto { get; set; } = new ContactoDto();
    }

    public class ContactoDto
    {
        public int IdContacto { get; set; }

        public string NroCelular { get; set; }

        public string Correo { get; set; }
    }


    public class DireccionDto
    {
        public int IdDireccion { get; set; }

        public int IdTipoVia { get; set; }

        public string Nombre { get; set; }

        public string Nro { get; set; }

        public string Mza { get; set; }

        public string Lote { get; set; }

        public string IdDepartamento { get; set; }

        public string IdProvincia { get; set; }

        public string IdDistrito { get; set; }

        public int IdTipoDomicilio { get; set; }

        public string DireccionReferencia { get; set; }

        public string CodigoPostal { get; set; }

        public decimal? Latitud { get; set; }

        public decimal? Longitud { get; set; }

    }

}
