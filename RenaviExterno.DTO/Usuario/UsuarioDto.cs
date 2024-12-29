using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenaviExterno.DTO
{
    public class UsuarioDto
    {
        // public int Id { get; set; }

        public int IdDocumento { get; set; }
        //public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Contrasena { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public int CodigoVerificacion { get; set; }
        public string UsuarioCreacion { get; set; }
    }

    public class UsuarioEnvioTokenDto
    {
        public string NumeroDocumento { get; set; }
        public string Correo { get; set; }
        ///public string UsuarioCreacion { get; set; }
    }

    public class UsuarioAutenticacionDto
    {
        public string NumeroDocumento { get; set; }
        public string contrasena { get; set; }
    }


    public class UsuarioCorreonDto
    {
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Correo { get; set; }
    }


    public class UsuarioACtualizarDto
    {
        public int IdUsuario { get; set; }
        public string ContrasenaActual { get; set; }
        public string NuevaContrasena { get; set; }
        public string ConfirmarContrasena { get; set; }

        public string UsuarioCreacion { get; set; }
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

        public int IdUsuario { get; set; }

        public string NroDocumento { get; set; }

        public string Nombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string NroCelular { get; set; }
        public string Correo { get; set; }

        public DireccionDto DireccionDomicilio { get; set; } = new DireccionDto();

        //public ContactoDto InformacionContacto { get; set; } = new ContactoDto();
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

    public class EditarPerfilModel

    {

        public int IdPersona { get; set; }



        public int IdDocumento { get; set; }



        public string Nombre { get; set; }



        public string ApellidoPaterno { get; set; }



        public string ApellidoMaterno { get; set; }



        public string NroCelular { get; set; }



        public string Correo { get; set; }



        public int IdTipoVia { get; set; }



        public string NombreDireccion { get; set; }



        public int IdDepartamento { get; set; }



        public int IdProvincia { get; set; }



        public int IdDistrito { get; set; }



        public string Referencia { get; set; }



        public string NombreUsuario { get; set; }

    }
}
