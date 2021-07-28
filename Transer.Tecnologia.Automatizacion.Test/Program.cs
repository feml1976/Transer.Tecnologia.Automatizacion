using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Transer.Tecnologia.Automatizacion.LogicaNegocioTest;

namespace Transer.Tecnologia.Automatizacion.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime fecIni = DateTime.Now;
            #region Definicion del bloque de seguridad
            string usuario = string.Empty;
            string password = string.Empty;
            string usuEmail = string.Empty;
            string passEmail = string.Empty;
            string ambiente = string.Empty;
            SecurityPrvt security = new SecurityPrvt();
            try
            {
                usuario = security.Decode(args[0].ToString());
            }
            catch (System.Exception)
            {
                usuario = security.Decode("usuario");
            }
            try
            {
                password = security.Decode(args[1].ToString());
            }
            catch (System.Exception)
            {
                password = security.Decode("password");
            }
            try
            {
                usuEmail = security.Decode(args[2].ToString());
            }
            catch (System.Exception)
            {
                usuEmail = security.Decode("usuEmail");
            }
            try
            {
                passEmail = security.Decode(args[3].ToString());
            }
            catch (System.Exception)
            {
                passEmail = security.Decode("passEmail");
            }
            try
            {
                ambiente = security.Decode(args[4].ToString());
            }
            catch (System.Exception)
            {
                ambiente = security.Decode("desarrollo");
            }
            #endregion fin de la Definicion del bloque de seguridad
            //LogicaNegocio lg = new LogicaNegocio(usuario, password, usuEmail, passEmail);


            ILogicaNegocio lg = new LogicaNegocio(usuario, password, usuEmail, passEmail, ambiente);
            //lg.Inicio(fecIni);
        }

    }
}
