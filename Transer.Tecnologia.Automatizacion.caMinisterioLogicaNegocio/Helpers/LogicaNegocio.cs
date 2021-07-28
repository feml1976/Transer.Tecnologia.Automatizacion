using System;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml;
using Transer.Tecnologia.Automatizacion.Correo;
using Transer.Tecnologia.Automatizacion.Entity;
using Transer.Tecnologia.Automatizacion.EntityMinisterio;
using Transer.Tecnologia.Automatizacion.Infrastructure;

namespace Transer.Tecnologia.Automatizacion.caMinisterioLogicaNegocio
{
    public partial class LogicaNegocio
    {
        private void LoadICLogReporteMinisterio()
        {
            string mensaje = "                            MINISTERIO DE TRANSPORTE\r\n";
            mensaje += "                            ========== == ==========\r\n\r\n";
            string[] _nParametros;
            object[] _vParametros;
            //_nParametros = new string[1] { ":LRMI_ESTADO" };
            //_vParametros = new object[1] { "P" };
            _nParametros = new string[2] { ":LRMI_ESTADO", ":LRMI_TRANSACCION" };
            _vParametros = new object[2] { "R",6 };
            Factory data = new Factory(Usuario, Password, Ambiente);
            try
            {
                mensaje += "Recuperando registros a Procesar . . .";
                console.Ih(mensaje);
                //var dt = data.getTable("getLogReporteMinisterio", _nParametros, _vParametros);//getLogReporteMinisterioEstadoTransaccion
                var dt = data.getTable("getLogReporteMinisterioEstadoTransaccion", _nParametros, _vParametros);//getLogReporteMinisterioEstadoTransaccion
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        console.Clear();
                        console.Ih(pp());
                        ICLogReporteMinisterio.Add(addLogReporteMinisterio(item));
                    }
                }
            }
            catch (Exception ex)
            {
                ManejoError(ex, "var dtLogReporteMinisterio = data.getTable(\"getLogReporteMinisterio\", _nParametros, _vParametros);");
            }

        }

        private void pp(string transaccion)
        {
            console.Clear();
            console.Cblue();
            console.Ih("                               MINISTERIO DE TRANSPORTE                         \r\n", false);
            console.CBlack();
            //console.Ih(" ", false);
            console.Ih(transaccion);
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

        private void procesarRegistro(LogReporteMinisterio p)
        {
            //console.Clear();
            console.CBlack();
            console.Ih("==> Informacion del Registro.", false);
            console.Ih("    ** Secuencia    : " + p.LRMI_SECUENCIA_NB, false);
            console.Ih("    ** Oficina      : " + p.LRMI_OFICINA_NB, false);
            console.Ih("    ** Transaccion  : " + p.LRMI_TRANSACCION_NB, false);
            console.Ih("    ** Llave        : " + p.LRMI_LLAVE_V2, false);
            console.Ih("    ** Fecha        : " + p.LRMI_FECREGISTRO_DT, false);
            console.Ih("    ** Campo1       : " + p.LRMI_CAMPO1_NB, false);
            DataTable dt_datos = new DataTable();
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[1] { ":LRMI_LLAVE" };
            _vParametros = new object[1] { p.LRMI_LLAVE_V2 };
            Factory data = new Factory(Usuario, Password, Ambiente);
            string funcion = string.Empty;
            switch (p.LRMI_TRANSACCION_NB)
            {
                case 3:
                    {
                        funcion = "PK_MINISTERIO_XML_REMESA";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 4:
                    {
                        funcion = "PK_MINISTERIO_XML_MANIFIESTO_CARGA";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 5:
                    {
                        funcion = "PK_MINISTERIO_XML_CUMPLIDO_REMESA";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 6:
                    {
                        funcion = "PK_MINISTERIO_XML_CUMPLIR_MANIFIESTO";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 9:
                    {
                        funcion = "PK_MINISTERIO_XML_ANULAR_REMESA";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }

                case 10:
                    {
                        funcion = "PK_MINISTERIO_XML_PROPIETARIOS_NIT";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 11:
                    {
                        funcion = "PK_MINISTERIO_XML_PROPIETARIOS_CEDULA";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 12:
                    {
                        funcion = "PK_MINISTERIO_XML_CONDUCTORES";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 13:
                    {
                        funcion = "PK_MINISTERIO_XML_CLIENTES_NIT";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 14:
                    {
                        funcion = "PK_MINISTERIO_XML_CLIENTES_CEDULA";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 15:
                    {
                        funcion = "PK_MINISTERIO_XML_VEHICULOS";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 16:
                    {
                        funcion = "PK_MINISTERIO_XML_TRAILERS";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 32:
                    {
                        funcion = "PK_MINISTERIO_XML_ANULAR_MANIFIESTO";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void procesarFuncion(string funcion, DataRow drw, LogReporteMinisterio p)
        {
            console.Ih("    ** Funcion   : " + funcion, false);
            string rutaArchivo = @"c:\transer\ws\web_ministerio\XML_" + p.LRMI_TRANSACCION_NB + "_" + p.LRMI_LLAVE_V2 + "_" + p.LRMI_OFICINA_NB + "_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
            string xml_envio = string.Empty;
            string xml_recibido = string.Empty;
            GenerarXml gxml = new GenerarXml();
            WsRndc srRndc = new WsRndc();
            switch (funcion)
            {
                case "PK_MINISTERIO_XML_REMESA"://3
                    {
                        try
                        {
                            xml_envio = gxml.procesar_remesa(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            xml_recibido = srRndc.enviar(xml_envio);
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_MANIFIESTO_CARGA"://4
                    {
                        try
                        {
                            xml_envio = gxml.procesar_manifiesto_carga(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            xml_recibido = srRndc.enviar(xml_envio);
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_CUMPLIDO_REMESA"://5
                    {
                        try
                        {
                            xml_envio = gxml.procesar_cumplido_remesa(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            xml_recibido = srRndc.enviar(xml_envio);
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_CUMPLIR_MANIFIESTO"://6
                    {
                        try
                        {
                            xml_envio = gxml.procesar_cumplir_manifiesto(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            xml_recibido = srRndc.enviar(xml_envio);
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_PROPIETARIOS_NIT"://10
                    {
                        try
                        {
                            xml_envio = gxml.procesar_propietarios_nit(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            xml_recibido = srRndc.enviar(xml_envio);
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_PROPIETARIOS_CEDULA"://11
                    {
                        try
                        {
                            xml_envio = gxml.procesar_propietarios_cedula(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            xml_recibido = srRndc.enviar(xml_envio);
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_CONDUCTORES"://12
                    {
                        try
                        {
                            xml_envio = gxml.procesar_conductores(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            xml_recibido = srRndc.enviar(xml_envio);
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_CLIENTES_NIT"://13
                    {
                        try
                        {
                            xml_envio = gxml.procesar_clientes_nit(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            xml_recibido = srRndc.enviar(xml_envio);
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_CLIENTES_CEDULA"://14
                    {
                        try
                        {
                            xml_envio = gxml.procesar_clientes_cedula(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            xml_recibido = srRndc.enviar(xml_envio);
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_VEHICULOS"://16
                    {
                        try
                        {
                            xml_envio = gxml.procesar_vehiculos(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            xml_recibido = srRndc.enviar(xml_envio);
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_TRAILERS"://17
                    {
                        try
                        {
                            xml_envio = gxml.procesar_trailers(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            xml_recibido = srRndc.enviar(xml_envio);
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }

                case "PK_MINISTERIO_XML_ANULAR_REMESA"://9
                    {
                        try
                        {
                            xml_envio = gxml.procesar_anular_remesa(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            xml_recibido = srRndc.enviar(xml_envio);
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_ANULAR_MANIFIESTO"://32
                    {
                        try
                        {
                            xml_envio = gxml.procesar_anular_manifiesto(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            xml_recibido = srRndc.enviar(xml_envio);
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                default:
                    break;
            }
        }

        private void procesarSelectSinValores(string funcion, LogReporteMinisterio p)
        {
            string xml_envio = string.Empty;
            string xml_recibido = string.Empty;
            GenerarXml gxml = new GenerarXml();
            xml_envio = gxml.SelectSinValores(funcion, p);
            xml_recibido = gxml.ReturnSinValores(funcion, -3, "R", p);
            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
            //SendCorreoSelectSinValores("Select sin Valores", funcion, p, xml_envio, xml_recibido);
        }

        private void procesarEnvioMinisterio(string v, string xml_envio, string xml_recibido, LogReporteMinisterio p)
        {
            //console.Clear();
            //console.CBlack();
            /*console.Ih(" ", false);
            console.Ih("==> XML Enviado ", true);
            console.Ih("    *** "+ xml_envio.Substring(1,50), false);*/
            string ruta = @"c:\transer\ws\web_ministerio\" + p.LRMI_TRANSACCION_NB + "_" + p.LRMI_LLAVE_V2 + "_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + ".xml";
            bool continuar = false;
            GenerarXml gxml = new GenerarXml();
            //string LRMI_ESTADO = string.Empty;
            double DELM_IDMINISTERIO = -1234567890;
            #region Definicion de carga del documento XmlDocument xmlReturn

            XmlDocument xmlReturn = new XmlDocument();

            try
            {
                xmlReturn.LoadXml(xml_recibido);
                continuar = true;
            }
            catch (XmlException ex)
            {
                try
                {
                    xml_recibido = gxml.maquetarXMLError(xml_recibido, -2, "P", p);
                    xmlReturn.LoadXml(xml_recibido);
                    continuar = true;
                }
                catch (Exception exx)
                {

                    continuar = false;
                }
            }
            catch (Exception ex)
            {
                continuar = false;
            }
            #endregion fin de la Definicion de carga del documento XmlDocument xmlReturn
            #region Definicion del bloque procesar respuesta
            while (continuar)
            {
                XmlElement root = xmlReturn.DocumentElement;
                try
                {
                    xmlReturn.Save(ruta);
                }
                catch (Exception ex)
                {

                }
                if (continuar)
                {
                    XmlNodeList elemListErrorTYS = root.GetElementsByTagName("ErrorTYS");
                    if (elemListErrorTYS.Count > 0)
                    {
                        /*console.Cblue();
                        console.Ih(" ", false);
                        console.Ih("==> XML Recibido ", true);
                        console.Ih("    *** " + xml_recibido, false);*/


                        XmlNodeList elemListEstadoRegistro = root.GetElementsByTagName("EstadoRegistro");
#pragma warning disable CS0162 // Se detectó código inaccesible
                        for (int i = 0; i < elemListEstadoRegistro.Count; i++)
#pragma warning restore CS0162 // Se detectó código inaccesible
                        {
                            //httpwebrequestFunction._status = elemListErrorTYS[i].InnerXml;
                            p.LRMI_ESTADO_V2 = elemListEstadoRegistro[i].InnerXml;
                            continuar = false;
                            break;
                        }
                        XmlNodeList elemListCodigoError = root.GetElementsByTagName("CodigoError");
#pragma warning disable CS0162 // Se detectó código inaccesible
                        for (int i = 0; i < elemListCodigoError.Count; i++)
#pragma warning restore CS0162 // Se detectó código inaccesible
                        {
                            DELM_IDMINISTERIO = double.Parse(elemListCodigoError[i].InnerXml.ToString());
                            continuar = false;
                            break;
                        }
                        //SendCorreoRegistroRechazado("Registro Rechazado", p, xml_envio, xml_recibido, v);
                        console.CYellow();
                        detalleRegistro(p, "errorTys", xml_envio, xml_recibido);
                    }
                }

                if (continuar)
                {
                    /*<?xml version="1.0" encoding="ISO-8859-1" ?>
                      <root>
                      <ErrorMSG>Error TER225: La fecha de Vencimiento de la Licencia de Conducción no puede ser mayor a 3 años. Usuario: 4961</ErrorMSG>
                      </root>
                    */

                    /*<?xml version="1.0" encoding="ISO-8859-1" ?>
                        <root>
                        <ErrorMSG>DUPLICADO:42542601 Error CMA030: El Manifiesto de Carga que intenta cumplir ya fue cumplido anteriormente.
                         Usuario: 4961</ErrorMSG>
                        </root>
                        */
                    XmlNodeList elemListErrorMSG = root.GetElementsByTagName("ErrorMSG");
#pragma warning disable CS0162 // Se detectó código inaccesible
                    for (int i = 0; i < elemListErrorMSG.Count; i++)
#pragma warning restore CS0162 // Se detectó código inaccesible
                    {
                        if (elemListErrorMSG[i].InnerXml.ToString().Contains("DUPLICADO"))
                        {
                            p.LRMI_ESTADO_V2 = "E";
                            DELM_IDMINISTERIO = getId(elemListErrorMSG[i].InnerXml.ToString());

                            console.Cblue();
                            //SendCorreoRegistroDuplicado("Registro Duplicado", p, xml_envio, xml_recibido, DELM_IDMINISTERIO);
                            //Thread.Sleep(30000);
                            //console.Ih(" ", false);
                            //console.Ih("==> Id Ministerio : " + DELM_IDMINISTERIO, false);
                            //console.Ih("==> XML Recibido Registro DUPLICADO", true);
                            detalleRegistro(p, "duplicado", xml_envio, xml_recibido);
                        }
                        else
                        {
                            p.LRMI_ESTADO_V2 = "R";
                            DELM_IDMINISTERIO = -1;
                            console.CRed();
                            //SendCorreoRegistroRechazado("Registro Rechazado", p, xml_envio, xml_recibido, v);
                            //console.Ih(" ", false);
                            //console.Ih("==> XML Recibido <ErrorMSG>", true);
                            detalleRegistro(p, "rechazo", xml_envio, xml_recibido);
                        }
                        continuar = false;
                        break;
                    }
                }

                if (continuar)
                {
                    /*<?xml version="1.0" encoding="ISO-8859-1" ?>
                      <root>
                      <ingresoid>55574021</ingresoid>
                      </root>
                    */
                    XmlNodeList elemListingresoid = root.GetElementsByTagName("ingresoid");
#pragma warning disable CS0162 // Se detectó código inaccesible
                    for (int i = 0; i < elemListingresoid.Count; i++)
#pragma warning restore CS0162 // Se detectó código inaccesible
                    {
                        p.LRMI_ESTADO_V2 = "E";
                        try
                        {
                            DELM_IDMINISTERIO = double.Parse(elemListingresoid[i].InnerXml);
                        }
                        catch (Exception ex)
                        {
                            DELM_IDMINISTERIO = -123456;
                        }
                        console.Cgreen();
                        //SendCorreoRegistroExitoso("Registro Aceptado por el Ministerio", p, xml_envio, xml_recibido, DELM_IDMINISTERIO);
                        //console.Ih(" ", false);
                        //console.Ih("==> Id Ministerio : " + DELM_IDMINISTERIO, false);
                        //console.Ih("==> XML Recibido ", true);
                        //console.Ih("    *** " + xml_recibido, false);
                        detalleRegistro(p, "envio", xml_envio, xml_recibido);
                        continuar = false;
                        break;
                    }
                }
            }

            if (DELM_IDMINISTERIO == -1234567890)
            {
                continuar = false;
            }
            else
            {
                continuar = true;
            }

            #endregion fin de la Definicion del bloque procesar respuesta

            if (continuar && p.LRMI_ESTADO_V2 != "P")
            {
                console.Ih("    !! Actualizando Tablas LogReporteMinisterio y DetLogMinisterio !!! ", false);
                console.Ih("==> SECUENCIA : " + p.LRMI_SECUENCIA_NB, false);
                console.Ih("==> OFICINA   : " + p.LRMI_OFICINA_NB, false);
                console.Ih("==> TRANSA.   : " + p.LRMI_TRANSACCION_NB, false);
                console.Ih("==> LLAVE     : " + p.LRMI_LLAVE_V2, false);
                console.Ih("==> ESTADO    : " + p.LRMI_ESTADO_V2, false);
                console.Ih("==> CAMPO1    : " + p.LRMI_CAMPO1_NB, false);
                using (Factory data = new Factory(Usuario, Password, Ambiente))
                {
                    string[] _nParametros;
                    object[] _vParametros;
                    if (p.LRMI_OFICINA_NB == 39)
                    {
                        _nParametros = new string[3] { ":LRMI_ESTADO", ":LRMI_SECUENCIA", ":LRMI_OFICINA" };
                        _vParametros = new object[3] { "F", p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB };
                        try
                        {
                            data.executeCommand("UpdateLogReporteMinisterio", _nParametros, _vParametros);
                        }
                        catch (Exception ex)
                        {
                            continuar = false;
                        }
                    }
                    else
                    {
                        if (p.LRMI_ESTADO_V2 != "R")
                        {
                            if (p.LRMI_CAMPO1_NB == 1)
                            {
                                p.LRMI_CAMPO1_NB = 2;
                                _nParametros = new string[4] { ":LRMI_ESTADO", ":LRMI_CAMPO1", ":LRMI_SECUENCIA", ":LRMI_OFICINA" };
                                _vParametros = new object[4] { p.LRMI_ESTADO_V2, p.LRMI_CAMPO1_NB, p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB };
                                try
                                {
                                    data.executeCommand("UpdateLogReporteMinisterioCampo1", _nParametros, _vParametros);
                                }
                                catch (Exception ex)
                                {
                                    continuar = false;
                                }
                            }
                            else
                            {
                                //p.LRMI_CAMPO1_NB = 0;
                                _nParametros = new string[3] { ":LRMI_ESTADO", ":LRMI_SECUENCIA", ":LRMI_OFICINA" };
                                _vParametros = new object[3] { p.LRMI_ESTADO_V2, p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB };
                                try
                                {
                                    data.executeCommand("UpdateLogReporteMinisterio", _nParametros, _vParametros);
                                }
                                catch (Exception ex)
                                {
                                    continuar = false;
                                }
                            }
                        }
                        else
                        {
                            _nParametros = new string[3] { ":LRMI_ESTADO", ":LRMI_SECUENCIA", ":LRMI_OFICINA" };
                            _vParametros = new object[3] { p.LRMI_ESTADO_V2, p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB };
                            try
                            {
                                //data.executeCommand("UpdateLogReporteMinisterio", _nParametros, _vParametros);
                            }
                            catch (Exception ex)
                            {
                                continuar = false;
                            }
                        }
                    }
                }
            }
            if (continuar)
            {
                using (Factory data = new Factory(Usuario, Password, Ambiente))
                {
                    //console.Ih("    !! Insertando Registro en la Tabla DetLogMinisterio         ");
                    string[] _nParametros;
                    object[] _vParametros;
                    _nParametros = new string[9] { ":secuencia", ":LRMI_SECUENCIA_NB", ":LRMI_OFICINA_NB", ":LRMI_TRANSACCION_NB", ":LRMI_LLAVE_V2", ":LRMI_ESTADO_V2", ":DELM_IDMINISTERIO_NB", ":DELM_XMLENVIADO_XML", ":DELM_XMLRECIBIDO_XML" };
                    if (p.LRMI_OFICINA_NB == 39)
                    {
                        _vParametros = new object[9] { getSecuenciaDetLogMinisterio(p), p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB, p.LRMI_TRANSACCION_NB, p.LRMI_LLAVE_V2, p.LRMI_ESTADO_V2, DELM_IDMINISTERIO, gxml.getXmlEnvioFletx(xml_envio, p), gxml.getXmlRecibidoFletx(xml_recibido, p) };
                    }
                    else
                    {
                        _vParametros = new object[9] { getSecuenciaDetLogMinisterio(p), p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB, p.LRMI_TRANSACCION_NB, p.LRMI_LLAVE_V2, p.LRMI_ESTADO_V2, DELM_IDMINISTERIO, xml_envio, xml_recibido };
                    }
                    try
                    {
                        //console.Cgreen();
                        //console.Ih("    !! Insertando Registro en la Tabla DetLogMinisterio !! ", true);
                        /*console.Ih("==> SECUENCIA : " + p.LRMI_SECUENCIA_NB, false);
                        console.Ih("==> OFICINA   : " + p.LRMI_OFICINA_NB, false);
                        console.Ih("==> LLAVE     : " + p.LRMI_LLAVE_V2, false);*/
                        console.Ih("==> ESTADO    : " + p.LRMI_ESTADO_V2, false);
                        console.Ih("==> ID MINIST : " + DELM_IDMINISTERIO, false);
                        //console.Ih("==> Xml        : " + xml_recibido);

                        if (p.LRMI_ESTADO_V2!="R")
                        {
                            data.executeCommand("InsertDetLogMinisterio", _nParametros, _vParametros);
                            //detalleRegistro(p, "envios", xml_envio, xml_recibido);
                        }
                    }
                    catch (Exception)
                    {
                        continuar = false;
                    }
                }
            }
            //Thread.Sleep(4000);
        }

        private void detalleRegistro(LogReporteMinisterio p, string carpeta,string xml_envio, string xml_recibido)
        {
            using (StreamWriter writer = new StreamWriter(@"d:\infoMinisterio\"+carpeta+"\\"+p.LRMI_TRANSACCION_NB+"_"+p.LRMI_LLAVE_V2+".txt", true))
            {
                writer.WriteLine("Fecha : " + DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString());
                writer.WriteLine("Secuencia : "+p.LRMI_SECUENCIA_NB);
                writer.WriteLine("Oficina : " + p.LRMI_OFICINA_NB);
                writer.WriteLine("Llave : " + p.LRMI_LLAVE_V2);
                writer.WriteLine("Fecha : " + p.LRMI_FECREGISTRO_DT);
                writer.WriteLine("Transaccion : " + p.LRMI_TRANSACCION_NB);
                writer.WriteLine("Estado : " + p.LRMI_ESTADO_V2);
                writer.WriteLine("");
                writer.WriteLine("***  XML RECIBIDO  ***");
                writer.WriteLine("");
                writer.WriteLine(xml_recibido);
                writer.WriteLine("");
                writer.WriteLine("***  XML ENVIADO  ***");
                writer.WriteLine("");
                writer.WriteLine(xml_envio);
            }

        }

        private double getId(string xmlElement)
        {
            //DUPLICADO:42542601 Error CMA030: El Manifiesto de Carga que intenta cumplir ya fue cumplido anteriormente.
            double DELM_IDMINISTERIO_NB = -1;
            bool bid = false;
            string tid = string.Empty;
            for (int i = 9; i < xmlElement.Length; i++)
            {
                if (xmlElement.Substring(i, 1) == " ")
                {
                    DELM_IDMINISTERIO_NB = int.Parse(tid);
                    break;
                }
                if (bid)
                {
                    tid += xmlElement.Substring(i, 1);
                }
                if (xmlElement.Substring(i, 1) == ":")
                {
                    bid = true;
                }
            }
            return DELM_IDMINISTERIO_NB;
        }

        private double getSecuenciaDetLogMinisterio(LogReporteMinisterio p)
        {
            double delm_secuencia = 0;
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[2] { ":LRMI_SECUENCIA_NB", ":LRMI_OFICINA_NB" };
            _vParametros = new object[2] { p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB };
            Factory data = new Factory(Usuario, Password, Ambiente);
            var dtDetLogMinisterio = data.getTable("getDetLogMinisterio", _nParametros, _vParametros);
            if (dtDetLogMinisterio.Rows.Count > 0)
            {
                foreach (DataRow dr in dtDetLogMinisterio.Rows)
                {
                    try
                    {
                        delm_secuencia = double.Parse(dr["DELM_SECUENCIA_NB"].ToString());
                    }
                    catch (Exception ex)
                    {
                        delm_secuencia = 0;
                    }
                }
                delm_secuencia++;
            }
            else
            {
                delm_secuencia = 1;
            }

            return delm_secuencia;
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


        private void SendCorreoSelectSinValores(string asunto, string funcion, LogReporteMinisterio p, string xml_envio, string xml_recibido)
        {
            string para = "lcubillos@transer.com.co";
            string copia = "soporte@transer.com.co";
            string copiaOculta = "francisco.montoya.l@gmail.com";
            ConfiguracionEmail cfEmail = new ConfiguracionEmail();
            cfEmail.Asunto = asunto;
            cfEmail.host = "192.168.30.8";
            cfEmail.enableSsl = false;
            cfEmail.port = 25;
            cfEmail.user = UsuEmail;
            cfEmail.password = PassEmail;
            cfEmail.Para = para;
            cfEmail.Copia = copia;
            cfEmail.CopiaOculta = copiaOculta;
            cfEmail.cuentaCorreo = "robotcorreo@transer.com.co";
            cfEmail.Titulo = "Robot Correo Automatizacion";
            CorreoElectronico Correo = new CorreoElectronico();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("                        TRANSPORTES Y SERVICIOS TRANSER S.A   Robot Ministerio v1.0.1");
            sb.AppendLine(" ");
            sb.AppendLine("                                            SELECT SIN VALORES ");
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine("!!! La funcion : " + funcion + "  no devolvio valores.\r\n");
            sb.AppendLine("");
            sb.AppendLine("Adjunto detalles de la transaccion.");
            sb.AppendLine("Secuencia    : " + p.LRMI_SECUENCIA_NB);
            sb.AppendLine("Oficina      : " + p.LRMI_OFICINA_NB);
            sb.AppendLine("Transaccion  : " + p.LRMI_TRANSACCION_NB);
            sb.AppendLine("Llave        : " + p.LRMI_LLAVE_V2);
            sb.AppendLine("Fecha        : " + p.LRMI_FECREGISTRO_DT);
            sb.AppendLine("Estado       : " + p.LRMI_ESTADO_V2);
            sb.AppendLine("Campo1       : " + p.LRMI_CAMPO1_NB);
            sb.AppendLine("");
            sb.AppendLine("Se generan los siguientes Objetos XML para completar el registro.\r\n");
            sb.AppendLine(" ");
            sb.AppendLine("        ! ! !         XML Enviado        ! ! !");
            sb.AppendLine("                      === =======");
            sb.AppendLine(" ");
            sb.AppendLine(xml_envio);
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine("        ! ! !         XML Recibido        ! ! !");
            sb.AppendLine("                      === =========");
            sb.AppendLine(xml_recibido);
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine("Saludos Cordiales, ");
            sb.AppendLine(" ");
            sb.AppendLine("Francisco Montoya L.");
            sb.AppendLine("Jefe de Soporte");
            sb.AppendLine("Oficina Transer Pereira");
            sb.AppendLine("Cel: 316-6917374");
            cfEmail.Mensaje = sb.ToString();
            Correo.SendMail(cfEmail);
        }
        private void SendCorreoRegistroDuplicado(string asunto, LogReporteMinisterio p, string xml_envio, string xml_recibido, double IdMinisterio)
        {
            string para = "soporte@transer.com.co";
            string copia = "lcubillos@transer.com.co";
            string copiaOculta = "francisco.montoya.l@gmail.com";
            ConfiguracionEmail cfEmail = new ConfiguracionEmail();
            cfEmail.Asunto = asunto;
            cfEmail.host = "192.168.30.8";
            cfEmail.enableSsl = false;
            cfEmail.port = 25;
            cfEmail.user = UsuEmail;
            cfEmail.password = PassEmail;
            cfEmail.Para = para;
            cfEmail.Copia = copia;
            cfEmail.CopiaOculta = copiaOculta;
            cfEmail.cuentaCorreo = "robotcorreo@transer.com.co";
            cfEmail.Titulo = "Robot Correo Automatizacion";
            CorreoElectronico Correo = new CorreoElectronico();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("                        TRANSPORTES Y SERVICIOS TRANSER S.A   Robot Ministerio v1.0.1");
            sb.AppendLine(" ");
            sb.AppendLine("                                            REGISTRO DUPLICADO ");
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine("");
            sb.AppendLine("!!! La transaccion : " + p.LRMI_TRANSACCION_NB + "  proceso un registro duplicado. Id de aprobacion por parte del Ministerio de Transporte  ==> " + IdMinisterio + "\r\n");
            sb.AppendLine("");
            sb.AppendLine("Adjunto detalles de la transaccion.");
            sb.AppendLine("Secuencia    : " + p.LRMI_SECUENCIA_NB);
            sb.AppendLine("Oficina      : " + p.LRMI_OFICINA_NB);
            sb.AppendLine("Transaccion  : " + p.LRMI_TRANSACCION_NB);
            sb.AppendLine("Llave        : " + p.LRMI_LLAVE_V2);
            sb.AppendLine("Fecha        : " + p.LRMI_FECREGISTRO_DT);
            sb.AppendLine("Estado       : " + p.LRMI_ESTADO_V2);
            sb.AppendLine("Campo1       : " + p.LRMI_CAMPO1_NB);
            sb.AppendLine("");
            sb.AppendLine("Se generan los siguientes Objetos XML para completar el registro.\r\n");
            sb.AppendLine("        ! ! !         XML Enviado        ! ! !");
            sb.AppendLine("                      === =========");
            sb.AppendLine(xml_envio);
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine("        ! ! !         XML Recibido        ! ! !");
            sb.AppendLine("                      === =========");
            sb.AppendLine(xml_recibido);
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine("Saludos Cordiales, ");
            sb.AppendLine(" ");
            sb.AppendLine("Francisco Montoya L.");
            sb.AppendLine("Jefe de Soporte");
            sb.AppendLine("Oficina Transer Pereira");
            sb.AppendLine("Cel: 316-6917374");
            cfEmail.Mensaje = sb.ToString();
            Correo.SendMail(cfEmail);
        }
        private void SendCorreoRegistroRechazado(string asunto, LogReporteMinisterio p, string xml_envio, string xml_recibido, string funcion)
        {
            string para = string.Empty;

            switch (p.LRMI_OFICINA_NB)
            {
                case 1: //OF.PRINCIPAL
                    {
                        para = "fmontoya@transer.com.co";
                        break;
                    }
                case 2: //OF.B / VENTURA
                    {
                        para = "buenaventura@transer.com.co";
                        break;
                    }
                case 3: //OF.BUGA
                    {
                        para = "buga@transer.com.co";
                        break;
                    }
                case 4: //OF.CARTAGENA
                    {
                        para = "cartagena@transer.com.co";
                        break;
                    }
                case 5: //OF.IPIALES
                    {
                        para = "ipiales@transer.com.co";
                        break;
                    }
                case 8: //OF.YUMBO
                    {
                        para = "yumbo@transer.com.co";
                        break;
                    }
                case 11: //OF.TOCANCIPA
                    {
                        para = "tocancipa@transer.com.co";
                        break;
                    }
                case 15: //OF.TECHO
                    {
                        para = "techo@transer.com.co";
                        break;
                    }
                case 16: //OF.BARRANQUILLA
                    {
                        para = "barranquilla@transer.com.co";
                        break;
                    }
                case 17: //OF.OPERATIVO
                    {
                        para = "tocancipa@transer.com.co";
                        break;
                    }
                case 18: //OF.BUCARAMANGA
                    {
                        para = "bucaramanga@transer.com.co";
                        break;
                    }
                case 19: //OF.DUITAMA
                    {
                        para = "duitama@transer.com.co";
                        break;
                    }
                case 20: //OF.ITAGUI
                    {
                        para = "itagui@transer.com.co";
                        break;
                    }
                case 29: //OF.SANTA MARTA
                    {
                        para = "santamarta@transer.com.co";
                        break;
                    }
                case 30: //OF.VILLAVICENCIO
                    {
                        para = "villavicencio@transer.com.co";
                        break;
                    }
                case 31: //OF.DOSQUEBRADAS
                    {
                        para = "pereira@transer.com.co";
                        break;
                    }
                case 32: //OF.UBATE
                    {
                        para = "ubate@transer.com.co";
                        break;
                    }
                case 33: //OF.IBAGUE
                    {
                        para = "ibague@transer.com.co";
                        break;
                    }
                case 34: //OF.OPERA COMERCIAL
                    {
                        para = "comercial@transer.com.co";
                        break;
                    }
                case 35: //OF.MANIZALES
                    {
                        para = "manizales@transer.com.co";
                        break;
                    }
                case 36: //OF.CUCUTA
                    {
                        para = "cucuta@transer.com.co";
                        break;
                    }
                case 37: //OF.PALERMO
                    {
                        para = "palermo@transer.com.co";
                        break;
                    }
                case 38: //OF.CERETE
                    {
                        para = "cerete@transer.com.co";
                        break;
                    }
                case 39: //OF.FLETX
                    {
                        para = "fmontoya@transer.com.co";
                        break;
                    }
                default:
                    {
                        para = "fmontoya@transer.com.co";
                        break;
                    }
            }
            string copia = "lcubillos@transer.com.co";
            string copiaOculta = "soporte@transer.com.co";
            ConfiguracionEmail cfEmail = new ConfiguracionEmail();
            cfEmail.Asunto = asunto;
            cfEmail.host = "192.168.30.8";
            cfEmail.enableSsl = false;
            cfEmail.port = 25;
            cfEmail.user = UsuEmail;
            cfEmail.password = PassEmail;
            cfEmail.Para = para;
            cfEmail.Copia = copia;
            cfEmail.CopiaOculta = copiaOculta;
            cfEmail.cuentaCorreo = "robotcorreo@transer.com.co";
            cfEmail.Titulo = "Robot Correo Automatizacion";
            CorreoElectronico Correo = new CorreoElectronico();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("                        TRANSPORTES Y SERVICIOS TRANSER S.A   Robot Ministerio v1.0.1");
            sb.AppendLine(" ");
            sb.AppendLine("                                            REGISTRO RECHAZADO ");
            sb.AppendLine("                                            ======== ========= ");
            sb.AppendLine(" ");
            sb.AppendLine("Se informa a la Oficina que el Ministerio de Transporte Rechazo la recepcion de la transaccion => " + funcion.Substring(18, funcion.Length - 18));
            sb.AppendLine("A continuacion se adjunta el detalle y se invita a tomar las medidas necesarias para dar solucion lo antes posible.");
            sb.AppendLine("En caso de requerir informacion adicional sobre este error en particular por favor comunicarse con el Departamento de Sistemas (SOPORTE) y reenviar este correo con el fin de tener a mano toda la informacion necesaria.");
            sb.AppendLine("");
            sb.AppendLine("!!! La transaccion : " + p.LRMI_TRANSACCION_NB + "  fue rechazada por el ministerio .\r\n");
            sb.AppendLine("");
            sb.AppendLine("                      DETALLE DEL ERROR        ");
            sb.AppendLine("                      ======= === =====");
            sb.AppendLine(detalleError(xml_recibido));
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine("Adjunto detalles de la transaccion.");
            sb.AppendLine(" ");
            sb.AppendLine("Secuencia    : " + p.LRMI_SECUENCIA_NB);
            sb.AppendLine("Oficina      : " + p.LRMI_OFICINA_NB);
            sb.AppendLine("Transaccion  : " + p.LRMI_TRANSACCION_NB + "  => " + funcion.Substring(0, 18));
            sb.AppendLine("Llave        : " + p.LRMI_LLAVE_V2);
            sb.AppendLine("Fecha        : " + p.LRMI_FECREGISTRO_DT);
            sb.AppendLine("Estado       : " + p.LRMI_ESTADO_V2);
            sb.AppendLine("Campo1       : " + p.LRMI_CAMPO1_NB);
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine("==> XML Recibido");
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine(xml_recibido);
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine("Se generan los siguientes Objetos XML para completar el registro.\r\n");
            sb.AppendLine(" ");
            sb.AppendLine("==> XML Enviado");
            sb.AppendLine(" ");
            sb.AppendLine(xml_envio);
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine("Saludos Cordiales, ");
            sb.AppendLine(" ");
            sb.AppendLine("Francisco Montoya L.");
            sb.AppendLine("Jefe de Soporte");
            sb.AppendLine("Oficina Transer Pereira");
            sb.AppendLine("Cel: 316-6917374");
            cfEmail.Mensaje = sb.ToString();
            Correo.SendMail(cfEmail);
        }

        private string detalleError(string xml_recibido)
        {
            string detalleError = string.Empty;
            XmlDocument xmlReturn = new XmlDocument();

            try
            {
                xmlReturn.LoadXml(xml_recibido);
            }
            catch (XmlException ex)
            {

            }
            catch (Exception ex)
            {
            }
            XmlElement root = xmlReturn.DocumentElement;
            XmlNodeList elemListErrorMSG = root.GetElementsByTagName("ErrorMSG");
            string tmp = string.Empty;
#pragma warning disable CS0162 // Se detectó código inaccesible
            for (int i = 0; i < elemListErrorMSG.Count; i++)
#pragma warning restore CS0162 // Se detectó código inaccesible
            {
                tmp = elemListErrorMSG[i].InnerXml;
                break;
            }
            StringBuilder sb = new StringBuilder();
            /*
                Error REM135: El tipo y/ó identificación del Propietario de la Carga no coinciden con los reportados en la tabla de Terceros. Está enviando una identificación del Propietario de la Carga de la Remesa Terrestre de Carga no válida o que no existe como Tercero en la base de datos.
                Error REM150: El tipo de identificación del Destinatario no corresponde a los códigos establecidos.
                Error REM150: El tipo y/ó identificación del Remitente no coinciden con los reportados en la tabla de Terceros. Está enviando una identificación del Remitente de la Remesa Terrestre de Carga no válida o que no existe como Tercero en la base de datos.
                Usuario: 4961             
            */
            bool blinea = false;
            if (tmp.Contains("Usuario:"))
            {
                for (int i = 0; i < tmp.Length; i++)
                {
                    try
                    {
                        if (tmp.Substring(i, 5).Contains("Error"))
                        {
                            detalleError += "\r\n* ";
                            blinea = true;
                            sb.Append(detalleError);
                            detalleError = string.Empty;
                        }
                        else
                        {
                            try
                            {
                                if (tmp.Substring(i, 8).Contains("Usuario:"))
                                {
                                    //detalleError += "\r\n* ";
                                    blinea = false;
                                    sb.Append(detalleError);
                                    detalleError = string.Empty;
                                    break;
                                }
                                else
                                {
                                    if (blinea)
                                    {
                                        detalleError += tmp.Substring(i - 1, 1);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                console.Ih(ex.Message);
                                console.ReadKey(ex.Message, true);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        console.Ih(ex.Message);
                        console.ReadKey(ex.Message, true);
                    }
                }
            }
            else
            {
                sb.Append("\r\n* " + tmp);
            }
            detalleError = sb.ToString();
            return detalleError;
        }

        private void SendCorreoRegistroExitoso(string asunto, LogReporteMinisterio p, string xml_envio, string xml_recibido, double IdMinisterio)
        {
            string para = "fmontoya@transer.com.co";
            string copia = "soporte@transer.com.co";
            string copiaOculta = "francisco.montoya.l@gmail.com";
            ConfiguracionEmail cfEmail = new ConfiguracionEmail();
            cfEmail.Asunto = asunto;
            cfEmail.host = "192.168.30.8";
            cfEmail.enableSsl = false;
            cfEmail.port = 25;
            cfEmail.user = UsuEmail;
            cfEmail.password = PassEmail;
            cfEmail.Para = para;
            cfEmail.Copia = copia;
            cfEmail.CopiaOculta = copiaOculta;
            cfEmail.cuentaCorreo = "robotcorreo@transer.com.co";
            cfEmail.Titulo = "Robot Correo Automatizacion";
            CorreoElectronico Correo = new CorreoElectronico();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("                        TRANSPORTES Y SERVICIOS TRANSER S.A   Robot Ministerio v1.0.1");
            sb.AppendLine(" ");
            sb.AppendLine("                                                   ENVIO EXITOSO ");
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine("");
            sb.AppendLine("!!! La transaccion : " + p.LRMI_TRANSACCION_NB + "  fue aceptada por el ministerio. ID de aprobacion ==> " + IdMinisterio + "\r\n");
            sb.AppendLine("");
            sb.AppendLine("Adjunto detalles de la transaccion.");
            sb.AppendLine(" ");
            sb.AppendLine("Secuencia    : " + p.LRMI_SECUENCIA_NB);
            sb.AppendLine("Oficina      : " + p.LRMI_OFICINA_NB);
            sb.AppendLine("Transaccion  : " + p.LRMI_TRANSACCION_NB);
            sb.AppendLine("Llave        : " + p.LRMI_LLAVE_V2);
            sb.AppendLine("Fecha        : " + p.LRMI_FECREGISTRO_DT);
            sb.AppendLine("Estado       : " + p.LRMI_ESTADO_V2);
            sb.AppendLine("Campo1       : " + p.LRMI_CAMPO1_NB);
            sb.AppendLine(" ");
            sb.AppendLine("");
            sb.AppendLine("Se generan los siguientes Objetos XML para completar el registro.\r\n");
            sb.AppendLine("        ! ! !         XML Enviado        ! ! !");
            sb.AppendLine("                      === =========");
            sb.AppendLine(xml_envio);
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine("        ! ! !         XML Recibido        ! ! !");
            sb.AppendLine("                      === =========");
            sb.AppendLine(xml_recibido);
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine("Saludos Cordiales, ");
            sb.AppendLine(" ");
            sb.AppendLine("Francisco Montoya L.");
            sb.AppendLine("Jefe de Soporte");
            sb.AppendLine("Oficina Transer Pereira");
            sb.AppendLine("Cel: 316-6917374");
            cfEmail.Mensaje = sb.ToString();
            Correo.SendMail(cfEmail);
        }
    }
}
