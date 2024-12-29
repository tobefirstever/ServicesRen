using Renavi.Application.DTO.Dtos.Usuario;
using Renavi.Application.Interfaces;
using Renavi.Domain.Entities.Entities;
using Renavi.Domain.Interfaces;
using Renavi.Transversal.Common;
using Renavi.Transversal.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.Main
{
    public class UsuarioApplication : IUsuarioApplication
    {

        private readonly IUsuarioDomain _usuarioDomain;
        private const string key = "ABCDEFG54669525PQRSTUVWXYZabcdef852846opqrstuvwxyz";

        public UsuarioApplication(IUsuarioDomain usuarioDomain)
        {
            _usuarioDomain = usuarioDomain;
        }

        public async Task<Response<IEnumerable<UsuarioDto>>> GetList()
        {
            var response = new Response<IEnumerable<UsuarioDto>> { Data = new List<UsuarioDto>() };
            IEnumerable<UsuarioEntity> gerenciaEntities = await _usuarioDomain.GetList();

            response.Data = Mapping.Map<IEnumerable<UsuarioEntity>, IEnumerable<UsuarioDto>>(gerenciaEntities);
            return response;
        }

        public async Task<UsuarioResponseDto> RegistroUsuario(UsuarioDto request)
        {
            var contrasena = EncryptKey(request.NumeroDocumento);
            request.Contrasena = contrasena;

            return await _usuarioDomain.RegistroUsuario(request);
        }


        public static string EncryptKey(string cadena)
        {
            if (cadena.Trim().Length != 0)
            {
                byte[] keyArray;
                var Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(cadena.Trim());

                var hashmd5 = new MD5CryptoServiceProvider();

                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
                var tdes = new TripleDESCryptoServiceProvider
                {
                    Key = keyArray,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };
                var cTransform = tdes.CreateEncryptor();
                var ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);
                tdes.Clear();
                return Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
            }
            else
            {
                return cadena;
            }
        }

        public static string DecryptKey(string cadena)
        {
            if (cadena.Trim().Length != 0)
            {
                byte[] keyArray;
                var Array_a_Descifrar = Convert.FromBase64String(cadena.Trim());
                var hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
                var tdes = new TripleDESCryptoServiceProvider
                {
                    Key = keyArray,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };
                var cTransform = tdes.CreateDecryptor();
                var resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            else
            {
                return cadena;
            }
        }

        public async Task<UsuarioGeneralResponseDto> EnvioCorreoPassword(UsuarioCorreonDto request)
        {
            return await _usuarioDomain.EnvioCorreoPassword(request);
        }

        public async Task<UsuarioGeneralResponseDto> ActualizarPassword(UsuarioACtualizarDto request)
        {

            request.NuevaContrasena = EncryptKey(request.NuevaContrasena);

            return await _usuarioDomain.ActualizarPassword(request);
        }

        public async Task<UsuarioResponseDto> Login(UsuarioAutenticacionDto request)
        {

            var resultado = await _usuarioDomain.Login(request);

            var response  = new UsuarioResponseDto();

            if(request.contrasena== DecryptKey(resultado.contrasena))
            {
                response.IdUsuario = resultado.idusuario;
                response.IdPersona = resultado.idpersona;
                response.Mensaje = "Ok";

            }

            if (request.contrasena != DecryptKey(resultado.contrasena))
            {
                response.IdUsuario = -1;
                response.IdPersona = -1;
                response.Mensaje = "Ingrese las credenciales correctas";

            }

            return response;
        }
    }
}
