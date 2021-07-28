using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transer.Tecnologia.Automatizacion.EntityMinisterio;
using Transer.Tecnologia.Automatizacion.Infrastructure;

namespace Transer.Tecnologia.Automatizacion.caUrbanosLogicaNegocio
{
    public partial class LogicaNegocio
    {
        private void LoadICLogReporteMinisterio()
        {
            string mensaje = "                            MINISTERIO DE TRANSPORTE\r\n";
            mensaje += "                            ========== == ==========\r\n\r\n";
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[0] { };
            _vParametros = new object[0] { };
            Factory data = new Factory(Usuario, Password, Ambiente);
            try
            {
                mensaje += "Recuperando registros a Procesar . . .";
                console.Ih(mensaje);
                var dt = data.getTable("getUpdateUrbanos", _nParametros, _vParametros);
                /*if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        console.Clear();
                        console.Ih(pp());
                        ICLogReporteMinisterio.Add(addLogReporteMinisterio(item));
                    }
                }*/
            }
            catch (Exception ex)
            {
                ManejoError(ex, "var dtLogReporteMinisterio = data.getTable(\"getLogReporteMinisterio\", _nParametros, _vParametros);");
            }

        }
        private LogReporteMinisterio addLogReporteMinisterio(DataRow item)
        {
            LogReporteMinisterio logReporteMinisterio = new LogReporteMinisterio();
            logReporteMinisterio.LRMI_SECUENCIA_NB = double.Parse(item["LRMI_SECUENCIA_NB"].ToString());
            logReporteMinisterio.LRMI_OFICINA_NB = int.Parse(item["LRMI_OFICINA_NB"].ToString());
            logReporteMinisterio.LRMI_TRANSACCION_NB = int.Parse(item["LRMI_TRANSACCION_NB"].ToString());
            logReporteMinisterio.LRMI_LLAVE_V2 = item["LRMI_LLAVE_V2"].ToString();
            logReporteMinisterio.LRMI_FECREGISTRO_DT = DateTime.Parse(item["LRMI_FECREGISTRO_DT"].ToString());
            logReporteMinisterio.LRMI_ESTADO_V2 = item["LRMI_ESTADO_V2"].ToString();
            try
            {
                logReporteMinisterio.LRMI_CAMPO1_NB = double.Parse(item["LRMI_CAMPO1_NB"].ToString());
            }
            catch (Exception ex)
            {
                logReporteMinisterio.LRMI_CAMPO1_NB = 0;
            }
            try
            {
                logReporteMinisterio.LRMI_CAMPO2_V2 = item["LRMI_CAMPO2_V2"].ToString();
            }
            catch (Exception ex)
            {
                logReporteMinisterio.LRMI_CAMPO2_V2 = string.Empty;
            }
            try
            {
                logReporteMinisterio.LRMI_CAMPO3_DT = DateTime.Parse(item["LRMI_CAMPO3_DT"].ToString());
            }
            catch (Exception ex)
            {
                logReporteMinisterio.LRMI_CAMPO3_DT = DateTime.UtcNow;
            }


            return logReporteMinisterio;
        }

        private string pp()
        {
            string mensaje = "                            MINISTERIO DE TRANSPORTE\r\n";
            mensaje += "                            ========== == ==========\r\n\r\n";
            mensaje += "Procesando ";
            Random r = new Random();
            string signo = string.Empty;
            switch (r.Next(0, 9))
            {
                case 0:
                    {
                        signo = "-";
                        break;
                    }
                case 1:
                    {
                        signo = "+";
                        break;
                    }
                case 2:
                    {
                        signo = "*";
                        break;
                    }
                case 3:
                    {
                        signo = "/";
                        break;
                    }
                case 4:
                    {
                        signo = "\\";
                        break;
                    }
                case 5:
                    {
                        signo = "-";
                        break;
                    }
                case 6:
                    {
                        signo = "+";
                        break;
                    }
                case 7:
                    {
                        signo = "/";
                        break;
                    }
                case 8:
                    {
                        signo = "*";
                        break;
                    }
                case 9:
                    {
                        signo = "\\";
                        break;
                    }
                default:
                    break;
            }
            mensaje += signo;
            return mensaje;
        }

        private void ManejoError(Exception ex, string texto)
        {
            using (StreamWriter writer = new StreamWriter("logLogicaNegocio.txt", true))
            {
                writer.WriteLine("Fecha : " + DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString());
                writer.WriteLine("Se Produjo un error de tipo Exception:");
                writer.WriteLine(ex.Message);
            }
            console.ReadKey("Se presento un error ...!!!!\r\n\r\n\r\n" + texto + ex.Message, true);
        }

    }
}
