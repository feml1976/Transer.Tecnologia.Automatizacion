using System;
using System.Security.Cryptography;
using System.Text;

namespace Transer.Tecnologia.Automatizacion.EncodingFE
{
    public class EncodingFacturacionElectronica
    {

        public EncodingFacturacionElectronica()
        {
        }
        public string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public string getCreate()
        {
            string fecha = string.Empty;//DateTime.Now.Year.ToString() + "-" + "0" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "T";
            string hora = string.Empty;//DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + ".000-05:00";
            int tmp = 0;
            string sec = string.Empty;
            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0://año
                        {
                            tmp = DateTime.Now.Year;
                            if (tmp < 10)
                            {
                                sec = "0" + tmp.ToString();
                                fecha += sec + "-";
                            }
                            else
                            {
                                fecha += tmp + "-";
                            }
                            break;
                        }
                    case 1://mes
                        {
                            tmp = DateTime.Now.Month;
                            if (tmp < 10)
                            {
                                sec = "0" + tmp.ToString();
                                fecha += sec + "-";
                            }
                            else
                            {
                                fecha += tmp + "-";
                            }
                            break;
                        }
                    case 2://dia
                        {
                            tmp = DateTime.Now.Day;
                            if (tmp < 10)
                            {
                                sec = "0" + tmp.ToString();
                                fecha += sec + "T";
                            }
                            else
                            {
                                fecha += tmp + "T";
                            }
                            break;
                        }
                    case 3://hora
                        {
                            tmp = DateTime.Now.Hour;
                            if (tmp < 10)
                            {
                                sec = "0" + tmp.ToString();
                                fecha += sec + ":";
                            }
                            else
                            {
                                fecha += tmp + ":";
                            }
                            break;
                        }
                    case 4://minutos
                        {
                            tmp = DateTime.Now.Minute;
                            if (tmp < 10)
                            {
                                sec = "0" + tmp.ToString();
                                fecha += sec + ":";
                            }
                            else
                            {
                                fecha += tmp + ":";
                            }
                            break;
                        }
                    case 5://segundos
                        {
                            tmp = DateTime.Now.Second;
                            if (tmp < 10)
                            {
                                sec = "0" + tmp.ToString();
                                fecha += sec + ".000-05:00";
                            }
                            else
                            {
                                fecha += tmp + ".000-05:00";
                            }
                            break;
                        }
                    default:
                        break;
                }
            }
            return fecha;
        }
        public string getNonce(string factura)
        {
            string fecha = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + ".000-05:00" + factura;
            string tmp = base64Binary(fecha);
            return tmp;
        }
        private string base64Binary(string password)
        {

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(password);
            string r = string.Empty;
            foreach (byte br in plainTextBytes)
            {
                r += br;
            }

            string s = System.Text.Encoding.UTF8.GetString(plainTextBytes, 0, plainTextBytes.Length);

            /*if (s == r)
            {
                string loc = "Son iguales";
            }*/
            byte[] data = new byte[r.Length];
            byte[] result;

            SHA1 sha = new SHA1CryptoServiceProvider();
            // This is one implementation of the abstract class SHA1.
            result = sha.ComputeHash(data);

            r = GetSHA1(password);
            return r;
        }
        private string GetSHA1(string str)
        {
            SHA1 sha1 = SHA1Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha1.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
        public string SHA256Encrypt(string input)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());

            return output.ToString();
        }

    }
}
