using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Transversal.Common
{
    public abstract class RegistroWindows
    {
        public static string ObtenerCadenaRegistro(string strRuta, string strClave)
        {
            string cadenaConexion = string.Empty;



            RegistryKey RegistroLocal = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
            RegistryKey registro = string.IsNullOrEmpty(strRuta) ? RegistroLocal : RegistroLocal.OpenSubKey(strRuta);
            cadenaConexion = registro.GetValue(strClave).ToString();



            return cadenaConexion;
        }
    }
}
