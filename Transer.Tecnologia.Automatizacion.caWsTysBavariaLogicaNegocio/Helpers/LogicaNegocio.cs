using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using Transer.Tecnologia.Automatizacion.Correo;
using Transer.Tecnologia.Automatizacion.Entity;
using Transer.Tecnologia.Automatizacion.EntityBavaria;
using Transer.Tecnologia.Automatizacion.Infrastructure;

namespace Transer.Tecnologia.Automatizacion.caWsTysBavariaLogicaNegocio
{
    public partial class LogicaNegocio
    {
        private void LoadICLogReporteBavaria()
        {
            string[] _nParametros;
            object[] _vParametros;
            //_nParametros = new string[1] { ":REBA_ESTADO" };
            //_vParametros = new object[1] { "P" };
            _nParametros = new string[0] { };
            _vParametros = new object[0] { };
            Factory data = new Factory(Usuario, Password, Ambiente);
            try
            {
                var dt = data.getTable("getLogReporteBavaria", _nParametros, _vParametros);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        ICLogReporteBavaria.Add(addLogReporteBavaria(item));
                    }
                }
            }
            catch (Exception ex)
            {
                ManejoError(ex, "var dtLogReporteDian = data.getTable(\"getLogReporteDian\", _nParametros, _vParametros);");
            }
        }
        private LogReporteBavaria addLogReporteBavaria(DataRow item)
        {
            console.Cgreen();

            LogReporteBavaria logReporteDian = new LogReporteBavaria();
            logReporteDian.REBA_SECUENCIA_NB = double.Parse(item["REBA_SECUENCIA_NB"].ToString());
            logReporteDian.REBA_OFICINA_NB = int.Parse(item["REBA_OFICINA_NB"].ToString());
            logReporteDian.REBA_TRANSACCION_NB = int.Parse(item["REBA_TRANSACCION_NB"].ToString());
            logReporteDian.REBA_LLAVE_V2 = item["REBA_LLAVE_V2"].ToString();
            logReporteDian.REBA_FECHA_DT = DateTime.Parse(item["REBA_FECHA_DT"].ToString());
            logReporteDian.REBA_ESTADO_V2 = item["REBA_ESTADO_V2"].ToString();
            try
            {
                logReporteDian.REBA_CAMPO1_NB = double.Parse(item["REBA_CAMPO1_NB"].ToString());
            }
            catch (Exception ex)
            {
                logReporteDian.REBA_CAMPO1_NB = 0;
            }
            try
            {
                logReporteDian.REBA_CAMPO2_V2 = item["REBA_CAMPO2_DT"].ToString();
            }
            catch (Exception ex)
            {
                logReporteDian.REBA_CAMPO2_V2 = string.Empty;
            }
            try
            {
                logReporteDian.REBA_CAMPO3_DT = DateTime.Parse(item["REBA_CAMPO3_V2"].ToString());
            }
            catch (Exception ex)
            {
                logReporteDian.REBA_CAMPO3_DT = DateTime.UtcNow;
            }
            console.Cc("Adjuntando planilla : " + logReporteDian.REBA_LLAVE_V2 + " Emitida : " + logReporteDian.REBA_FECHA_DT);
            return logReporteDian;
        }
        private void procesarDespacho(LogReporteBavaria logReporteBavaria)
        {
            validarDirectorio(logReporteBavaria.REBA_LLAVE_V2);
            console.CBlack();
            console.Cc("Procesando Planilla : " + logReporteBavaria.REBA_LLAVE_V2 + "  Fecha : " + logReporteBavaria.REBA_FECHA_DT);
            //System.Threading.Thread.Sleep(4000);
            ICConsultaInfoBavaria = new List<ConsultaInfoBavaria>();
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[1] { ":VIAJ_NOPLANILLA" };
            _vParametros = new object[1] { logReporteBavaria.REBA_LLAVE_V2 };
            Factory data = new Factory(Usuario, Password, Ambiente);
            try
            {
                var dt = data.getTable("getInfoBavaria", _nParametros, _vParametros);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        ICConsultaInfoBavaria.Add(addInfoBavaria(item));
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ManejoError(ex, "var dtLogReporteDian = data.getTable(\"getLogReporteDian\", _nParametros, _vParametros);");
            }
            if (ICConsultaInfoBavaria.Count > 0)
            {
                procesarDespachoBavaria(ICConsultaInfoBavaria, logReporteBavaria);
            }
            else
            {
                console.Ih(" No hay registro para procesar...!!!");
            }
        }
        private void procesarDespachoBavaria(ICollection<ConsultaInfoBavaria> iCConsultaInfoBavaria, LogReporteBavaria logReporteBavaria)
        {
            string ruta = @"c:\transer\ws\Bavaria\" + logReporteBavaria.REBA_LLAVE_V2 + @"\" + logReporteBavaria.REBA_LLAVE_V2;
            foreach (var item in iCConsultaInfoBavaria)
            {
                console.Ih("=> Procesando planilla : " + item.VIAJ_NOPLANILLA_V2);
                string InsumoXmlBavaria = crearXMLBavaria(item);
                try
                {
                    console.Ih(" Creando Insumo XML Bavaria");
                    //System.Threading.Thread.Sleep(4000);
                    XmlDocument insumoXML = CreateSoapEnvelopeBavaria(InsumoXmlBavaria);
                    insumoXML.Save(ruta + "_Insumo.xml");
                    console.Ih(" Enviando Insumo XML ");
                    //System.Threading.Thread.Sleep(4000);
                    string HttpWebReturn = httpsSendXmlDocument(insumoXML.InnerXml);
                    XmlDocument soapReturn = CreateSoapEnvelopeBavaria(HttpWebReturn);
                    soapReturn.Save(ruta + "_Respuesta.xml");
                    console.Ih(" Procesando Respuesta ");
                    //System.Threading.Thread.Sleep(4000);
                    HttpWebProcesarReturn(item, insumoXML, soapReturn, logReporteBavaria);
                }
                catch (Exception ex)
                {
                    using (StreamWriter writer = new StreamWriter(ruta, true))
                    {
                        writer.WriteLine("Se presento un Error al Momento de generar el Insumo XML");
                        writer.WriteLine("A continuacion se describe el detalle del error. ");
                        writer.WriteLine(ex.Message);
                    }
                }
            }
        }
        private string get()
        {
            string xml = string.Empty;
            using (StreamReader reader = new StreamReader("C:\\perro\\bav.xml"))
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    xml += line;
                }
            }
            return xml;
        }
        private string crearXMLBavaria(ConsultaInfoBavaria item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<soapenv:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:urn=\"urn:gtrwsdl\">\r\n");
            sb.Append("<soapenv:Header/>\r\n");
            sb.Append("<soapenv:Body>\r\n");
            sb.Append("<urn:nuevo_manifiesto soapenv:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">\r\n");
            sb.Append("<user xsi:type=\"xsd:string\">transer</user>\r\n");
            sb.Append("<pass xsi:type=\"xsd:string\">#Tr.nsp23GP18*</pass>\r\n");
            sb.Append("<manifiesto xsi:type=\"xsd:string\">" + item.VIAJ_NOPLANILLA_V2 + "</manifiesto>\r\n");
            sb.Append("<oficina xsi:type=\"xsd:string\">" + item.OFIC_NOMBRE_V2 + "</oficina>\r\n");
            sb.Append("<placa xsi:type=\"xsd:string\">" + item.VIAJ_PLACA_CH + "</placa>\r\n");
            sb.Append("<marca xsi:type=\"xsd:string\"></marca>\r\n");
            sb.Append("<modelo xsi:type=\"xsd:string\"></modelo>\r\n");
            sb.Append("<ejes xsi:type=\"xsd:string\"></ejes>\r\n");
            sb.Append("<ancho xsi:type=\"xsd:string\"></ancho>\r\n");
            sb.Append("<alto xsi:type=\"xsd:string\"></alto>\r\n");
            sb.Append("<peso xsi:type=\"xsd:string\"></peso>\r\n");
            sb.Append("<tipovehiculo xsi:type=\"xsd:string\">" + item.CLVE_DESCRIP_V2 + "</tipovehiculo>\r\n");
            sb.Append("<remolque xsi:type=\"xsd:string\">" + item.VIAJ_TRAILER_CH + "</remolque>\r\n");
            sb.Append("<expedicion xsi:type=\"xsd:string\">" + item.VIAJ_FECVIAJE_DT + "</expedicion>\r\n");
            sb.Append("<distancia xsi:type=\"xsd:string\">" + item.CAMI_KMSTOTAL_NB + "</distancia>\r\n");
            sb.Append("<nombreconductor xsi:type=\"xsd:string\">" + item.COND_NOMBRE_V2 + "</nombreconductor>\r\n");
            sb.Append("<cedulacondutor xsi:type=\"xsd:string\">" + item.COND_CEDULA_NB + "</cedulacondutor>\r\n");
            sb.Append("<direccioncondutor xsi:type=\"xsd:string\"></direccioncondutor>\r\n");
            sb.Append("<telefonocondutor xsi:type=\"xsd:string\"></telefonocondutor>\r\n");
            sb.Append("<licencia xsi:type=\"xsd:string\"></licencia>\r\n");
            sb.Append("<categoria xsi:type=\"xsd:string\"></categoria>\r\n");
            sb.Append("<vencelicencia xsi:type=\"xsd:string\"></vencelicencia>\r\n");
            sb.Append("<observacion xsi:type=\"xsd:string\">" + "Codigo de ruta:" + item.ORCA_RUTA_NB + "</observacion>\r\n");
            sb.Append("<nivelriesgo xsi:type=\"xsd:string\"></nivelriesgo>\r\n");
            sb.Append("<arl xsi:type=\"xsd:string\"></arl>\r\n");
            sb.Append("<origen xsi:type=\"xsd:string\">" + item.CIUD_DESCRIPCION_ORIGEN_V2 + "</origen>\r\n");
            sb.Append("<destino xsi:type=\"xsd:string\">" + item.CIUD_DESCRIPCION_DESTINO_V2 + "</destino>\r\n");
            sb.Append("<codigoorigen xsi:type=\"xsd:string\">" + item.CIUD_CODIGO_ORIGEN_NB + "</codigoorigen>\r\n");
            sb.Append("<codigodestino xsi:type=\"xsd:string\">" + item.CIUD_CODIGO_DESTINO_NB + "</codigodestino>\r\n");
            sb.Append("<ruta xsi:type=\"xsd:string\">" + item.DESC_RUTA_V2 + "</ruta>\r\n");
            sb.Append("<ruta_id xsi:type=\"xsd:string\">" + item.ORCA_RUTA_NB + "</ruta_id>\r\n");
            sb.Append("<tipoproducto xsi:type=\"xsd:string\">" + item.PROD_NOMBRE_V2 + "</tipoproducto>\r\n");
            sb.Append("<remesa xsi:type=\"xsd:string\"></remesa>\r\n");
            sb.Append("<contenido xsi:type=\"xsd:string\"></contenido>\r\n");
            sb.Append("<empaque xsi:type=\"xsd:string\">" + item.GENE_DESCRIPCION_V2 + "</empaque>\r\n");
            sb.Append("<nitdestino xsi:type=\"xsd:string\"></nitdestino>\r\n");
            sb.Append("<direcciondestino xsi:type=\"xsd:string\"></direcciondestino>\r\n");
            sb.Append("<fechainicioestimado xsi:type=\"xsd:string\"></fechainicioestimado>\r\n");
            sb.Append("<fechafinalestimado xsi:type=\"xsd:string\"></fechafinalestimado>\r\n");
            sb.Append("<fechamaximaentrega xsi:type=\"xsd:string\"></fechamaximaentrega>\r\n");
            sb.Append("<vflete xsi:type=\"xsd:string\"></vflete>\r\n");
            sb.Append("<vretefuente xsi:type=\"xsd:string\"></vretefuente>\r\n");
            sb.Append("<vreteica xsi:type=\"xsd:string\"></vreteica>\r\n");
            sb.Append("<vdescuentos xsi:type=\"xsd:string\"></vdescuentos>\r\n");
            sb.Append("<vneto xsi:type=\"xsd:string\"></vneto>\r\n");
            sb.Append("<vanticipo xsi:type=\"xsd:string\"></vanticipo>\r\n");
            sb.Append("<load xsi:type=\"xsd:string\"></load>\r\n");
            sb.Append("<unidad xsi:type=\"xsd:string\"></unidad>\r\n");
            sb.Append("</urn:nuevo_manifiesto>\r\n");
            sb.Append("</soapenv:Body>\r\n");
            sb.Append("</soapenv:Envelope>\r\n");
            return sb.ToString();
        }
        private XmlDocument CreateSoapEnvelopeBavaria(string myXmlSoap)
        {
            XmlDocument soapEnvelop = new XmlDocument();
            try
            {
                soapEnvelop.LoadXml(myXmlSoap);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return soapEnvelop;
        }
        private string httpsSendXmlDocument(string HttpXmlSender)
        {
            //bool continuar = true;
            string txbRequestXmlf = string.Empty;
            string xml = HttpXmlSender;
            string url = "http://opt1mus.co/ws/gptranser.php?wsdl";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            byte[] requestBytes = System.Text.Encoding.ASCII.GetBytes(xml);
            req.Method = "POST";
            req.ContentType = "text/xml;charset=utf-8";
            req.ContentLength = requestBytes.Length;
            //while (continuar)
            //{
            try
            {
                Stream requestStream = req.GetRequestStream();
                requestStream.Write(requestBytes, 0, requestBytes.Length);
                requestStream.Close();
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.Default);
                string backstr = sr.ReadToEnd();
                sr.Close();
                res.Close();
                txbRequestXmlf = backstr;
                //continuar = false;
            }
            catch (WebException ex)
            {
                txbRequestXmlf = ex.Message;
                console.Ih(" txbRequestXmlf ");
                System.Threading.Thread.Sleep(300000);
                console.Ih("Presione cualquier tecla para continuar");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                txbRequestXmlf = ex.Message;
                console.Ih(" txbRequestXmlf ");
                System.Threading.Thread.Sleep(300000);
                console.Ih("Presione cualquier tecla para continuar");
                Console.ReadKey();
            }
            //}                
            return txbRequestXmlf;
        }
        private ConsultaInfoBavaria addInfoBavaria(DataRow item)
        {
            ConsultaInfoBavaria consultaInfoBavaria = new ConsultaInfoBavaria();
            consultaInfoBavaria.VIAJ_NOPLANILLA_V2 = item["VIAJ_NOPLANILLA_V2"].ToString();
            consultaInfoBavaria.OFIC_NOMBRE_V2 = item["OFIC_NOMBRE_V2"].ToString();
            consultaInfoBavaria.VIAJ_PLACA_CH = item["VIAJ_PLACA_CH"].ToString();
            consultaInfoBavaria.CLVE_DESCRIP_V2 = item["CLVE_DESCRIP_V2"].ToString();
            consultaInfoBavaria.VIAJ_TRAILER_CH = item["VIAJ_TRAILER_CH"].ToString();
            consultaInfoBavaria.VIAJ_FECVIAJE_DT = DateTime.Parse(item["VIAJ_FECVIAJE_DT"].ToString());
            consultaInfoBavaria.CAMI_KMSTOTAL_NB = int.Parse(item["CAMI_KMSTOTAL_NB"].ToString());
            consultaInfoBavaria.COND_NOMBRE_V2 = item["CONDUCTOR"].ToString();
            consultaInfoBavaria.COND_CEDULA_NB = double.Parse(item["COND_CEDULA_NB"].ToString());
            consultaInfoBavaria.CIUD_DESCRIPCION_ORIGEN_V2 = item["CIUD_ORIGEN"].ToString();
            consultaInfoBavaria.CIUD_CODIGO_ORIGEN_NB = int.Parse(item["COD_ORIGEN"].ToString());
            consultaInfoBavaria.CIUD_DESCRIPCION_DESTINO_V2 = item["CIUD_DESTINO"].ToString();
            consultaInfoBavaria.CIUD_CODIGO_DESTINO_NB = int.Parse(item["COD_DESTINO"].ToString());
            consultaInfoBavaria.DESC_RUTA_V2 = item["ORIGEN_DESTINO"].ToString();
            consultaInfoBavaria.ORCA_RUTA_NB = int.Parse(item["ORCA_RUTA_NB"].ToString());
            consultaInfoBavaria.PROD_NOMBRE_V2 = item["PROD_NOMBRE_V2"].ToString();
            consultaInfoBavaria.GENE_DESCRIPCION_V2 = item["GENE_DESCRIPCION_V2"].ToString();
            return consultaInfoBavaria;
        }
        private void HttpWebProcesarReturn(ConsultaInfoBavaria iCConsultaInfoBavaria, XmlDocument insumoXML, XmlDocument soapReturn, LogReporteBavaria logReporteBavaria)
        {
            XmlNodeList elemList = soapReturn.GetElementsByTagName("ns1:nuevo_manifiestoResponse");//ns1:
            double success = -1;
            for (int i = 0; i < elemList.Count; i++)
            {
                XmlNode xmlnode = elemList.Item(0);
                string retorno = xmlnode.InnerText;
                if (retorno.Contains("error\":\"\""))
                {
                    console.Cgreen();
                    console.Ih(" Planilla Reportada con Exito ");
                    System.Threading.Thread.Sleep(2000);
                    actualizarRegistro(iCConsultaInfoBavaria, insumoXML, soapReturn, logReporteBavaria, success, "E");
                    break;
                }
                else
                {
                    console.CRed();
                    console.Ih(" Error al reportar la planilla ");
                    actualizarRegistro(iCConsultaInfoBavaria, insumoXML, soapReturn, logReporteBavaria, success, "R");
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
        private void actualizarRegistro(ConsultaInfoBavaria iCConsultaInfoBavaria, XmlDocument insumoXML, XmlDocument soapReturn, LogReporteBavaria logReporteBavaria, double success, string estado)
        {
            console.Cgreen();
            switch (estado)
            {
                case "R":
                    {
                        using (Factory data = new Factory(Usuario, Password, Ambiente))
                        {
                            console.Ih("    !! Insertando Registro en la Tabla Det_log_Bavaria         ");
                            string[] _nParametros;
                            object[] _vParametros;
                            //:filename,:filedata,:companyid,:accountid,:status,:transactionid,:xmlfactura,:soapenviado,:soaprespuesta
                            _nParametros = new string[7] { ":logbavaria",
                                               ":oficina",
                                               ":llave",
                                               ":numacepta",
                                               ":estado",
                                               ":Bavariasoapenviado",
                                               ":Bavariasoaprecibido" };
                            _vParametros = new object[7] { logReporteBavaria.REBA_SECUENCIA_NB,
                                                logReporteBavaria.REBA_OFICINA_NB,
                                                logReporteBavaria.REBA_LLAVE_V2,
                                                -1,
                                                "R",
                                                insumoXML.InnerXml,
                                                soapReturn.InnerXml};
                            console.CRed();
                            console.Ih("Registro Rechazado ");
                            //console.Cgreen();
                            console.Ih(" Insertando registro en la tabla DET_LOG_BAVARIA. ");
                            //System.Threading.Thread.Sleep(1000);
                            data.executeCommand("InsertDetLogBavaria", _nParametros, _vParametros);
                        }
                        using (Factory data = new Factory(Usuario, Password, Ambiente))
                        {
                            console.Ih("    !! Insertando Registro en la Tabla Det_log_Bavaria         ");
                            string[] _nParametros;
                            object[] _vParametros;
                            //:filename,:filedata,:companyid,:accountid,:status,:transactionid,:xmlfactura,:soapenviado,:soaprespuesta
                            _nParametros = new string[3] { ":REBA_ESTADO_V2", ":REBA_SECUENCIA_NB", ":REBA_OFICINA_NB" };
                            _vParametros = new object[3] { GetEstado(soapReturn, logReporteBavaria.REBA_LLAVE_V2), logReporteBavaria.REBA_SECUENCIA_NB, logReporteBavaria.REBA_OFICINA_NB };
                            console.Ih(" Actualizando el registro en la tabla LOG_REPORTE_BAVARIA. ");
                            System.Threading.Thread.Sleep(1000);
                            data.executeCommand("UpdateLogReporteBavaria", _nParametros, _vParametros);
                        }


                        break;
                    }
                case "E":
                    {
                        using (Factory data = new Factory(Usuario, Password, Ambiente))
                        {
                            console.Ih("    !! Insertando Registro en la Tabla Det_log_Bavaria         ");
                            string[] _nParametros;
                            object[] _vParametros;
                            //:filename,:filedata,:companyid,:accountid,:status,:transactionid,:xmlfactura,:soapenviado,:soaprespuesta
                            _nParametros = new string[7] { ":logbavaria",
                                               ":oficina",
                                               ":llave",
                                               ":numacepta",
                                               ":estado",
                                               ":Bavariasoapenviado",
                                               ":Bavariasoaprecibido" };
                            _vParametros = new object[7] { logReporteBavaria.REBA_SECUENCIA_NB,
                                                logReporteBavaria.REBA_OFICINA_NB,
                                                logReporteBavaria.REBA_LLAVE_V2,
                                                GetNumAceptacion(soapReturn, logReporteBavaria.REBA_LLAVE_V2),
                                                GetEstado(soapReturn, logReporteBavaria.REBA_LLAVE_V2),
                                                insumoXML.InnerXml,
                                                soapReturn.InnerXml};
                            console.Cblue();
                            console.Ih("Numero de aprobacion ==> " + GetNumAceptacion(soapReturn, logReporteBavaria.REBA_LLAVE_V2));
                            console.Cgreen();
                            console.Ih(" Insertando registro en la tabla DET_LOG_BAVARIA. ");
                            //System.Threading.Thread.Sleep(1000);
                            data.executeCommand("InsertDetLogBavaria", _nParametros, _vParametros);
                        }
                        using (Factory data = new Factory(Usuario, Password, Ambiente))
                        {
                            console.Ih("    !! Insertando Registro en la Tabla Det_log_Bavaria         ");
                            string[] _nParametros;
                            object[] _vParametros;
                            //:filename,:filedata,:companyid,:accountid,:status,:transactionid,:xmlfactura,:soapenviado,:soaprespuesta
                            _nParametros = new string[3] { ":REBA_ESTADO_V2", ":REBA_SECUENCIA_NB", ":REBA_OFICINA_NB" };
                            _vParametros = new object[3] { GetEstado(soapReturn, logReporteBavaria.REBA_LLAVE_V2), logReporteBavaria.REBA_SECUENCIA_NB, logReporteBavaria.REBA_OFICINA_NB };
                            console.Ih(" Actualizando el registro en la tabla LOG_REPORTE_BAVARIA. ");
                            System.Threading.Thread.Sleep(1000);
                            data.executeCommand("UpdateLogReporteBavaria", _nParametros, _vParametros);
                        }

                        break;
                    }
                default:
                    break;
            }
        }
        private string GetEstado(XmlDocument soapReturn, string planilla)
        {
            /*string estado = string.Empty;
            string nombreArchivo = @"c:\transer\ws\Bavaria\" + planilla + "\\" + planilla + "_xmlRecibido.xml";
            string status = string.Empty;
            try
            {
                soapReturn.Save(nombreArchivo);
                XmlElement root = soapReturn.DocumentElement;
                XmlNodeList elemListStatus = root.GetElementsByTagName("status");
                #pragma warning disable CS0162 // Se detectó código inaccesible
                for (int i = 0; i < elemListStatus.Count; i++)
                #pragma warning restore CS0162 // Se detectó código inaccesible
                {
                    estado = elemListStatus[i].InnerXml;
                    break;
                }
            }
            catch (Exception ex)
            {
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException;
            }
            return estado;*/
            return "E";
        }
        private double GetNumAceptacion(XmlDocument soapReturn, string planilla)
        {
            /*
             *             XmlNodeList elemList = soapReturn.GetElementsByTagName("ns1:nuevo_manifiestoResponse");//ns1:

            double success = -1;
            for (int i = 0; i < elemList.Count; i++)
            {
                XmlNode xmlnode = elemList.Item(0);
                string retorno = xmlnode.InnerText;
                if (retorno.Contains("error\":\"\""))
                {
                    int inicio = retorno.IndexOf("success\":")+9;
                    int fin = retorno.IndexOf("}")- inicio;
                    string dsuccess = retorno.Substring(inicio, fin);
                    success = double.Parse(retorno.Substring((retorno.IndexOf("success\":") + 9), ((retorno.IndexOf("}") -(retorno.IndexOf("success\":") + 9)))));
                    if (success==double.Parse(dsuccess))
                    {
                        actualizarRegistro(iCConsultaInfoBavaria, insumoXML, soapReturn, logReporteBavaria, success);
                    }
                }

                
            }
             */
            double numacepta = -1;
            string nombreArchivo = @"c:\transer\ws\Bavaria\" + planilla + "\\" + planilla + "_xmlRecibido.xml";
            string status = string.Empty;
            try
            {
                soapReturn.Save(nombreArchivo);
                XmlElement root = soapReturn.DocumentElement;
                XmlNodeList elemListStatus = root.GetElementsByTagName("ns1:nuevo_manifiestoResponse");
#pragma warning disable CS0162 // Se detectó código inaccesible
                for (int i = 0; i < elemListStatus.Count; i++)
#pragma warning restore CS0162 // Se detectó código inaccesible
                {
                    XmlNode xmlnode = elemListStatus.Item(i);
                    string retorno = xmlnode.InnerText;
                    if (retorno.Contains("error\":\"\""))
                    {
                        int inicio = retorno.IndexOf("success\":") + 9;
                        int fin = retorno.IndexOf("}") - inicio;
                        string dsuccess = retorno.Substring(inicio, fin);
                        numacepta = double.Parse(retorno.Substring((retorno.IndexOf("success\":") + 9), ((retorno.IndexOf("}") - (retorno.IndexOf("success\":") + 9)))));
                        if (numacepta == double.Parse(dsuccess))
                        {
                            break;
                        }
                    }
                    numacepta = double.Parse(elemListStatus[i].InnerXml);
                    break;
                }
            }
            catch (Exception ex)
            {
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException;
            }

            return numacepta;
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
        private void enviocorreo(string factura, string correoCliente, string asunto, string mensaje, string para, string copia, string copiaOculta)
        {
            ConfiguracionEmail cfEmail = new ConfiguracionEmail();
            cfEmail.Asunto = asunto;
            cfEmail.host = "192.168.30.8";
            cfEmail.enableSsl = false;
            cfEmail.port = 25;
            /*cfEmail.user = "robotcorreo";
            cfEmail.password = "Tys860504882";*/
            cfEmail.user = UsuEmail;
            cfEmail.password = PassEmail;
            //cfEmail.Para = "FMONTOYA@TRANSER.COM.CO";
            cfEmail.Para = para;
            cfEmail.Copia = copia;
            cfEmail.CopiaOculta = copiaOculta;
            cfEmail.cuentaCorreo = "robotcorreo@transer.com.co";
            cfEmail.Titulo = "Robot Correo Automatizacion";
            CorreoElectronico Correo = new CorreoElectronico();
            addLog(Correo.MensajeError);
            //byte[] byteTextAnexos = File.ReadAllBytes("c:\\transer\\ws\\facturacion\\" + factura + "\\" + factura + ".zip");
            byte[] byteTextAnexos = File.ReadAllBytes("c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\anexos.zip");
            MailAttachment attach = new MailAttachment(byteTextAnexos, "anexos_" + factura + ".zip");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" Señor(es),  ");
            sb.AppendLine(correoCliente);
            sb.AppendLine("  ");
            sb.AppendLine(" Les informamos que TRANSPORTES Y SERVICIOS TRANSER S.A les ha emitido el siguiente documento. ");
            sb.AppendLine("  ");
            sb.AppendLine(" Número de documento: " + factura);
            sb.AppendLine(" Tipo de documento: FACTURA");
            sb.AppendLine(" Fecha de emisión: " + DateTime.Now.ToLongDateString());
            sb.AppendLine("  ");
            sb.AppendLine(" Los anexos que soportan el documento sobrepasan el tamaño máximo permitido por nuestro PST, por tal razón los enviamos anexos al presente mensaje. ");
            sb.AppendLine("  ");
            sb.AppendLine(" Si tiene alguna inquietud al respecto no dude en contactar a nuestros representantes comerciales. ");
            sb.AppendLine("  ");
            sb.AppendLine("  ");
            sb.AppendLine(" Atentamente,  ");
            sb.AppendLine("  ");
            sb.AppendLine(" TRANSPORTES Y SERVICIOS TRANSER S.A ");

            cfEmail.Mensaje = sb.ToString();

            Correo.SendMail(cfEmail, attach);

        }
        private void addLog(string texto)
        {
            Log += DateTime.UtcNow.ToLongDateString() + " " + DateTime.UtcNow.ToLongTimeString() + "\r\n";
            Log += "Procesando " + P() + "\r\n";
            Log += texto + "\r\n";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Log);
            Log = string.Empty;
        }
        private string P()
        {
            Random r = new Random();
            string p = string.Empty;
            for (int i = 0; i < r.Next(1, 4); i++)
            {
                p += ".";
            }
            return p;
        }
        private bool SendEmail(string asunto, string mensaje, string para, string copia, string copiaOculta)
        {
            ConfiguracionEmail cfEmail = new ConfiguracionEmail();
            cfEmail.Asunto = asunto;
            cfEmail.Mensaje = mensaje;
            cfEmail.host = "192.168.30.8";
            cfEmail.enableSsl = false;
            cfEmail.port = 25;
            cfEmail.user = UsuEmail;
            cfEmail.password = PassEmail;
            //cfEmail.Para = "FMONTOYA@TRANSER.COM.CO";
            cfEmail.Para = para;
            cfEmail.Copia = copia;
            cfEmail.CopiaOculta = copiaOculta;
            cfEmail.cuentaCorreo = "robotcorreo@transer.com.co";
            cfEmail.Titulo = "Robot Correo Automatizacion";
            CorreoElectronico Correo = new CorreoElectronico();
            addLog(Correo.MensajeError);
            return Correo.SendMail(cfEmail);
        }
        private void validarDirectorio(string planilla)
        {
            string ruta = @"c:\transer\ws\Bavaria\" + planilla;
            if (!Directory.Exists(ruta))
                Directory.CreateDirectory(ruta);
        }

    }
}
