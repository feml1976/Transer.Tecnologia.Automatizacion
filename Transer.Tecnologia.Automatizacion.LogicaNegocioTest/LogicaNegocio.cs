using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transer.Tecnologia.Automatizacion.EntityBavaria;
using Transer.Tecnologia.Automatizacion.Infrastructure;

namespace Transer.Tecnologia.Automatizacion.LogicaNegocioTest
{
    public partial class LogicaNegocio : ILogicaNegocio
    {
        private string Usuario;
        private string Password;
        private string UsuEmail;
        private string PassEmail;
        private string Ambiente;
        public string Log { get; set; }
        public Consola console;
        public string ExcepcionEjecucion { get; set; }
        public ICollection<LogReporteBavaria> ICLogReporteBavaria { get; set; }
        public List<LogReporteBavaria> LLogReporteBavaria { get; set; }

        public List<DetLogBavaria> detLogBavarias { get; set; }

        public LogicaNegocio(string usuario, string password, string usuEmail, string passEmail, string ambiente)
        {
            //SendEmail("Pruebas", "Mensaje de prueba", "fmontoya@transer.com.co", "soporte@transer.com.co", "francisco.montoya.l@gmail.com");
            Log = string.Empty;
            Usuario = usuario;
            Password = password;
            UsuEmail = usuEmail;
            PassEmail = passEmail;
            Ambiente = ambiente;
            string titulo = "                            WEB SERVICES BAVARIA\r\n" + "                            ========== == ==========\r\n";
            console = new Consola(titulo);
            ICLogReporteBavaria = new List<LogReporteBavaria>();
            LoadICLogReporteBavaria();
            //LLogReporteMinisterio = new List<LogReporteMinisterio>();
            //List<LogReporteMinisterio> entityList = new List<LogReporteMinisterio>(ICLogReporteMinisterio);//.ToList<LogReporteMinisterio>;//.CopyTo(LLogReporteMinisterio[],0);
            LLogReporteBavaria = new List<LogReporteBavaria>(ICLogReporteBavaria);
            Inicio(DateTime.Now);
        }

        private void LoadICLogReporteBavaria()
        {
            string mensaje = "                            MINISTERIO DE TRANSPORTE\r\n";
            mensaje += "                            ========== == ==========\r\n\r\n";
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[1] { ":LRMI_ESTADO" };
            _vParametros = new object[1] { "P" };
            Factory data = new Factory(Usuario, Password, Ambiente);
            try
            {
                mensaje += "Recuperando registros a Procesar . . .";
                console.Ih(mensaje);
                //var dt = data.getTable("getInfoLogReporteBavaria", _nParametros, _vParametros);
                var dt = data.getTable("getInfoLogReporteBavaria");
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        console.Clear();
                        console.Ih(pp());
                        ICLogReporteBavaria.Add(addLogReporteBavaria(item));
                    }
                }
            }
            catch (Exception ex)
            {
                ManejoError(ex, "var dtLogReporteMinisterio = data.getTable(\"getLogReporteMinisterio\", _nParametros, _vParametros);");
            }
        }

        private LogReporteBavaria addLogReporteBavaria(DataRow item)
        {
            LogReporteBavaria logReporteBavaria = new LogReporteBavaria();
            logReporteBavaria.REBA_SECUENCIA_NB = double.Parse(item["REBA_SECUENCIA_NB"].ToString());
            logReporteBavaria.REBA_OFICINA_NB = int.Parse(item["REBA_OFICINA_NB"].ToString());
            logReporteBavaria.REBA_TRANSACCION_NB = int.Parse(item["REBA_TRANSACCION_NB"].ToString());
            logReporteBavaria.REBA_LLAVE_V2 = item["REBA_LLAVE_V2"].ToString();
            logReporteBavaria.REBA_FECHA_DT = DateTime.Parse(item["REBA_FECHA_DT"].ToString());
            logReporteBavaria.REBA_ESTADO_V2 = item["REBA_ESTADO_V2"].ToString();
            try
            {
                logReporteBavaria.REBA_CAMPO1_NB = double.Parse(item["REBA_CAMPO1_NB"].ToString());
            }
            catch (Exception ex)
            {
                logReporteBavaria.REBA_CAMPO1_NB = 0;
            }
            try
            {
                logReporteBavaria.REBA_CAMPO2_V2 = item["REBA_CAMPO2_V2"].ToString();
            }
            catch (Exception ex)
            {
                logReporteBavaria.REBA_CAMPO2_V2 = string.Empty;
            }
            try
            {
                logReporteBavaria.REBA_CAMPO3_DT = DateTime.Parse(item["REBA_CAMPO3_DT"].ToString());
            }
            catch (Exception ex)
            {
                logReporteBavaria.REBA_CAMPO3_DT = DateTime.UtcNow;
            }

            return logReporteBavaria;
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

        public void Inicio(DateTime fecinicio)
        {
            string titulo = "                       PLANILLAS PENDIENTES POR ENVIAR A BAVARIA\r\n" + "                            ========== == ==========\r\n";
            console = new Consola(titulo);
            //LLogReporteBavaria = new List<LogReporteBavaria>(ICLogReporteBavaria);
            if (LLogReporteBavaria.Count>0)
            {
                detLogBavarias = new List<DetLogBavaria>();
                foreach (var item in LLogReporteBavaria)
                {
                    adicionarRegistroLogReporteBavaria(item);
                    console.Clear();
                    console.Ih(pp());
                }
            }
            if (detLogBavarias.Count>0)
            {
                foreach (var item in detLogBavarias)
                {
                    escribirRegistro(item);
                    console.Clear();
                    console.Ih(pp());
                }
            }
        }

        private void escribirRegistro(DetLogBavaria item)
        {
            using (StreamWriter writer = new StreamWriter(@"D:\repBavaria\infoEnvio.txt", true))
            {
                writer.WriteLine(item.DEBA_SECUENCIA_NB+";"+ item.DEBA_LOGBAVARIA_NB + ";" + item.DEBA_OFICINA_NB + ";" + item.DEBA_LLAVE_V2 + ";" + item.DEBA_ESTADO_V2 + ";" + item.DEBA_NUMACEPTA_NB + ";" + item.DEBA_FECPROCESA_DT);
            }
        }

        private void adicionarRegistroLogReporteBavaria(LogReporteBavaria item)
        {
            ICollection<DetLogBavaria> ICDetLogBavaria = new List<DetLogBavaria>();
            ICDetLogBavaria = LeerInformacionDetLogBavaria(item);
            if (ICDetLogBavaria.Count > 0)
            {                
                foreach (var itemDetLogBavaria in ICDetLogBavaria)
                {
                    detLogBavarias.Add(ListDetLogBavaria(itemDetLogBavaria));
                        //itemDetLogBavaria.DEBA_SECUENCIA_NB, 
                        //itemDetLogBavaria.DEBA_LOGBAVARIA_NB, 
                        //itemDetLogBavaria.DEBA_OFICINA_NB, 
                        //itemDetLogBavaria.DEBA_TRANSACCION_NB,
                        //itemDetLogBavaria.DEBA_LLAVE_V2,
                        //itemDetLogBavaria.DEBA_NUMACEPTA_NB,
                        //itemDetLogBavaria.DEBA_ESTADO_V2,
                        //itemDetLogBavaria.DEBA_SOAPENVIADO_V2,
                        //itemDetLogBavaria.DEBA_SOAPRECIBIDO_V2,
                        //itemDetLogBavaria.DEBA_FECPROCESA_DT,
                        //itemDetLogBavaria.DEBA_CAMPO1_NB,
                        //itemDetLogBavaria.DEBA_CAMPO2_DT,
                        //itemDetLogBavaria.DEBA_CAMPO3_V2);
                }
            }
            else
            {
                //...Falta Implementar
            }
        }

        private DetLogBavaria ListDetLogBavaria(DetLogBavaria itemDetLogBavaria)
        {
            DetLogBavaria detLogBavaria = new DetLogBavaria();
            detLogBavaria.DEBA_SECUENCIA_NB = itemDetLogBavaria.DEBA_SECUENCIA_NB;
            detLogBavaria.DEBA_LOGBAVARIA_NB = itemDetLogBavaria.DEBA_LOGBAVARIA_NB;
            detLogBavaria.DEBA_OFICINA_NB = itemDetLogBavaria.DEBA_OFICINA_NB;
            detLogBavaria.DEBA_TRANSACCION_NB = itemDetLogBavaria.DEBA_TRANSACCION_NB;
            detLogBavaria.DEBA_LLAVE_V2 = itemDetLogBavaria.DEBA_LLAVE_V2;
            detLogBavaria.DEBA_NUMACEPTA_NB = itemDetLogBavaria.DEBA_NUMACEPTA_NB;
            detLogBavaria.DEBA_ESTADO_V2 = itemDetLogBavaria.DEBA_ESTADO_V2;
            detLogBavaria.DEBA_SOAPENVIADO_V2 = itemDetLogBavaria.DEBA_SOAPENVIADO_V2;
            detLogBavaria.DEBA_SOAPRECIBIDO_V2 = itemDetLogBavaria.DEBA_SOAPRECIBIDO_V2;
            detLogBavaria.DEBA_FECPROCESA_DT = itemDetLogBavaria.DEBA_FECPROCESA_DT;
            detLogBavaria.DEBA_CAMPO1_NB = itemDetLogBavaria.DEBA_CAMPO1_NB;
            detLogBavaria.DEBA_CAMPO2_DT = itemDetLogBavaria.DEBA_CAMPO2_DT;
            detLogBavaria.DEBA_CAMPO3_V2 = itemDetLogBavaria.DEBA_CAMPO3_V2;
            return detLogBavaria;
        }

        private ICollection<DetLogBavaria> LeerInformacionDetLogBavaria(LogReporteBavaria itemLogReporteBavaria)
        {
            ICollection<DetLogBavaria> ICDetLogBavaria = new List<DetLogBavaria>();
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[3] { ":DEBA_LOGBAVARIA", ":DEBA_OFICINA", ":DEBA_LLAVE" };
            _vParametros = new object[3] { itemLogReporteBavaria.REBA_SECUENCIA_NB, itemLogReporteBavaria.REBA_OFICINA_NB, itemLogReporteBavaria.REBA_LLAVE_V2};
            Factory data = new Factory(Usuario, Password, Ambiente);
            try
            {
                var dt = data.getTable("getDetalleDetLogBavaria", _nParametros, _vParametros);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        try
                        {
                            ICDetLogBavaria.Add(addInformacionDetLogBavaria(item));
                        }
                        catch (Exception exx)
                        {

                            ManejoError(exx, "ICInformacionDian.Add(addInformacionDian(item));");
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ManejoError(ex, "var dtLogReporteDian = data.getTable(\"getLogReporteDian\", _nParametros, _vParametros);");
            }
            return ICDetLogBavaria;
        }

        private DetLogBavaria addInformacionDetLogBavaria(DataRow item)
        {
            DetLogBavaria detLogBavaria = new DetLogBavaria();
            detLogBavaria.DEBA_SECUENCIA_NB = double.Parse(item["DEBA_SECUENCIA_NB"].ToString());
            detLogBavaria.DEBA_LOGBAVARIA_NB = double.Parse(item["DEBA_LOGBAVARIA_NB"].ToString());
            detLogBavaria.DEBA_OFICINA_NB = int.Parse(item["DEBA_OFICINA_NB"].ToString());
            detLogBavaria.DEBA_TRANSACCION_NB = int.Parse(item["DEBA_TRANSACCION_NB"].ToString());
            detLogBavaria.DEBA_LLAVE_V2 = item["DEBA_LLAVE_V2"].ToString();
            try
            {
                detLogBavaria.DEBA_NUMACEPTA_NB = double.Parse(item["DEBA_NUMACEPTA_NB"].ToString());
            }
            catch (Exception ex)
            {

                detLogBavaria.DEBA_NUMACEPTA_NB = 0;
            }
            
            detLogBavaria.DEBA_ESTADO_V2 = item["DEBA_ESTADO_V2"].ToString();
            detLogBavaria.DEBA_SOAPENVIADO_V2 = item["DEBA_SOAPENVIADO_V2"].ToString();
            detLogBavaria.DEBA_SOAPRECIBIDO_V2 = item["DEBA_SOAPRECIBIDO_V2"].ToString();
            detLogBavaria.DEBA_FECPROCESA_DT = DateTime.Parse(item["DEBA_FECPROCESA_DT"].ToString());
            try
            {
                detLogBavaria.DEBA_CAMPO1_NB = double.Parse(item["DEBA_CAMPO1_NB"].ToString());
            }
            catch (Exception ex)
            {
                detLogBavaria.DEBA_CAMPO1_NB = 0;
            }
            try
            {
                detLogBavaria.DEBA_CAMPO2_DT = DateTime.Parse(item["DEBA_CAMPO2_DT"].ToString());
            }
            catch (Exception ex)
            {
                detLogBavaria.DEBA_CAMPO2_DT = DateTime.Now;
            }
            try
            {
                detLogBavaria.DEBA_CAMPO3_V2 = item["DEBA_CAMPO3_V2"].ToString();
            }
            catch (Exception ex)
            {
                detLogBavaria.DEBA_CAMPO3_V2 = string.Empty;
            }
            
            return detLogBavaria;
        }
    }
}
