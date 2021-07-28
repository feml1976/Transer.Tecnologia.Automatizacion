using System;
using System.IO;

using Transer.Tecnologia.Automatizacion.caDStysGetInfoFactura;
using Transer.Tecnologia.Automatizacion.caFEVTysLogicaNegocio;
namespace Transer.Tecnologia.Automatizacion.caFEVTysVs1
{
    class CAFEVTys
    {
        public static DateTime FecInicio { get; set; }
        public static DateTime FecFin { get; set; }

        private static string NombreLog { get; set; }
        static void Main(string[] args)
        {
            NombreLog = "PadCFctrcnInicio.txt";

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
            StarLog();
            lg.Inicio(fecIni);
            StopLogs();
        }

        private static void StarLog()
        {
            using (StreamWriter writer = new StreamWriter(@"C:\Transer\ws\logs\" + NombreLog, true))
            {
                writer.WriteLine("Inicio;" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
            }
        }

        private static void StopLogs()
        {
            using (StreamWriter writer = new StreamWriter(@"C:\Transer\ws\logs\" + NombreLog, true))
            {
                writer.WriteLine("Fin;" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
            }

            string line = string.Empty;
            using (StreamReader reader = new StreamReader(@"C:\Transer\ws\logs\" + NombreLog))
            {
                while (true)
                {
                    string l = reader.ReadLine();
                    if (l == null)
                        break;
                    else
                        line = l;
                }
            }
            if (line.Length > 0)
            {
                if (line.Contains("Fin;"))
                {
                    try
                    {
                        FecFin = DateTime.Parse(line.Substring(4, (line.Length - 4)));

                        using (StreamWriter writer = new StreamWriter(@"C:\Transer\ws\logs\" + NombreLog, true))
                        {
                            writer.WriteLine("Ok;" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        public class SecurityPrvt
        {
            public SecurityPrvt()
            {

            }
            public string Decode(string texto)
            {
                string codigo = string.Empty;
                switch (texto)
                {
                    case "usuario":
                        {
                            codigo = Base64Decode("SOPORTE");
                            break;
                        }
                    case "password":
                        {
                            codigo = Base64Decode("SOPORTE");
                            break;
                        }
                    case "usuEmail":
                        {
                            codigo = Base64Decode("robotcorreo");
                            break;
                        }
                    case "passEmail":
                        {
                            codigo = Base64Decode("Tys860504882");
                            break;
                        }
                    default:
                        {
                            codigo = Base64Decode(texto);
                            break;
                        }
                }
                return codigo;
            }
            private string Base64Decode(string base64EncodedData)
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(base64EncodedData);
                //string encodedText = Convert.ToBase64String(plainTextBytes);
                return Convert.ToBase64String(plainTextBytes);
                //return System.Text.Encoding.UTF8.GetString(plainTextBytes);
            }
        }
    }
}
