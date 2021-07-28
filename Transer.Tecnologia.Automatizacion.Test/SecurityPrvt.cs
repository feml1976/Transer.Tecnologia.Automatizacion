using System;

namespace Transer.Tecnologia.Automatizacion.Test
{
    internal class SecurityPrvt
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