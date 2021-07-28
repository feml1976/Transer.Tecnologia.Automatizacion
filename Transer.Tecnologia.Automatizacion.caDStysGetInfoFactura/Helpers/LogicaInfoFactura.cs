using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;
using Transer.Tecnologia.Automatizacion.Correo;
using Transer.Tecnologia.Automatizacion.EncodingFE;
using Transer.Tecnologia.Automatizacion.Entity;
using Transer.Tecnologia.Automatizacion.HttpsSendXmlDocument;
using Transer.Tecnologia.Automatizacion.Infrastructure;

//namespace Transer.Tecnologia.Automatizacion.caDStysGetInfoFactura.Helpers
namespace Transer.Tecnologia.Automatizacion.caDStysGetInfoFactura
{
    public partial class LogicaInfoFactura
    {
        /*VERSION PRODUCCION*/
        public LogicaInfoFactura()
        {
            
        }
        private HttpsWebRequestsFunction Cufe(string factura)
        {
            console.CBlack();
            console.Ih("=> CUFE Factura");
            HttpsWebRequestsFunction httpwebrequestFunction=new HttpsWebRequestsFunction();
            string estado = string.Empty;
            ICollection<InformacionDian> ICInformacionDian = new List<InformacionDian>();
            ICInformacionDian = LeerInformacionDian(factura);
            if (ICInformacionDian.Count > 0)
            {
                foreach (var item in ICInformacionDian)
                {
                    httpwebrequestFunction._Numdoc = item.INDI_NUMDOC_V2;
                    httpwebrequestFunction._FileName = item.INDI_NUMDOC_V2;
                    httpwebrequestFunction._FacturaXml = item.INDI_XMLENV_CB;
                    httpwebrequestFunction = maquetarSoapCufe(httpwebrequestFunction);
                    //System.Threading.Thread.Sleep(3000);
                    httpwebrequestFunction = EnviarFactura(httpwebrequestFunction);
                    //System.Threading.Thread.Sleep(3000);
                    httpwebrequestFunction = procesarCufeXMLRecibido(httpwebrequestFunction);
                }
            }
            return httpwebrequestFunction;
        }

        private HttpsWebRequestsFunction maquetarSoapCufe(HttpsWebRequestsFunction httpwebrequestFunction)
        {
            string estado = string.Empty;
            httpwebrequestFunction._companyId = "860504882";
            httpwebrequestFunction._accountid = "860504882_01";
            httpwebrequestFunction._Username = "fmontoya@transer.com.co";
            httpwebrequestFunction._userId = "UsernameToken-1";
            EncodingFacturacionElectronica coding = new EncodingFacturacionElectronica();
            //httpwebrequestFunction._Password = coding.SHA256Encrypt("F935Cjm9262@");//PRODUCCION
            httpwebrequestFunction._Password = coding.SHA256Encrypt("@Tys860504882");//PILOTO
            //httpwebrequestFunction._Password = coding.SHA256Encrypt("TranserFac@1");
            httpwebrequestFunction._HttpWebRequestFunction = "DownloadRequest";
            httpwebrequestFunction._create = coding.getCreate();
            httpwebrequestFunction._nonce = coding.getNonce(httpwebrequestFunction._FileName);
            string documentType = "FE";
            if (httpwebrequestFunction._FileName.Contains("NC"))
            {
                documentType = "NC";
            }
            else
            {
                if (httpwebrequestFunction._FileName.Contains("ND"))
                {
                    documentType = "ND";
                }
            }
            switch (documentType)
            {
                case "NC":
                    {
                        httpwebrequestFunction._documentType = "NC";
                        break;
                    }
                case "ND":
                    {
                        httpwebrequestFunction._documentType = "ND";
                        break;
                    }
                case "FV":
                    {
                        httpwebrequestFunction._documentType = "FV";
                        break;
                    }
                default:
                    {
                        httpwebrequestFunction._documentType = "FE";
                        break;
                    }
            }
            httpwebrequestFunction._documentPrefix = httpwebrequestFunction._FileName.Substring(0, 4);
            httpwebrequestFunction._documentNumber = httpwebrequestFunction._FileName;
            httpwebrequestFunction._resourceType = "SIGNED_XML";
            httpWebSend xmlsend = new httpWebSend();
            httpwebrequestFunction._soapEnviado = xmlsend.getSoapEnvio(httpwebrequestFunction);
            return httpwebrequestFunction;
        }

        private HttpsWebRequestsFunction EnviarFactura(HttpsWebRequestsFunction httpwebrequestFunction)
        {
            HttpSendXmlDocument httpsSendXmlDocument = new HttpSendXmlDocument();
            httpwebrequestFunction = httpsSendXmlDocument.httpsSendXmlDocument(httpwebrequestFunction);
            httpwebrequestFunction._soapRecibido = httpwebrequestFunction._httpWebResponseXml;
            return httpwebrequestFunction;
        }
        private HttpsWebRequestsFunction procesarCufeXMLRecibido(HttpsWebRequestsFunction httpwebrequestFunction)
        {            
            string nombreArchivo = @"c:\transer\ws\facturacion\" + httpwebrequestFunction._Numdoc + "\\cufe\\" + httpwebrequestFunction._Numdoc + "_xml.xml";            
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(httpwebrequestFunction._soapRecibido);
                doc.Save(nombreArchivo);
                XmlElement root = doc.DocumentElement;
                XmlNodeList elemListStatus = root.GetElementsByTagName("status");
                #pragma warning disable CS0162 // Se detectó código inaccesible
                for (int i = 0; i < elemListStatus.Count; i++)
                #pragma warning restore CS0162 // Se detectó código inaccesible
                {
                    httpwebrequestFunction._status = elemListStatus[i].InnerXml;
                    break;
                }
                XmlNodeList elemListTransactionId = root.GetElementsByTagName("downloadData");
                #pragma warning disable CS0162 // Se detectó código inaccesible
                for (int i = 0; i < elemListTransactionId.Count; i++)
                #pragma warning restore CS0162 // Se detectó código inaccesible
                {
                    httpwebrequestFunction._downloadData = elemListTransactionId[i].InnerXml;
                    break;
                }
                if (httpwebrequestFunction._status == "Recurso recibido satisfactoriamente.")
                {
                    httpwebrequestFunction = procesarDownloadDataCufe(httpwebrequestFunction);
                    if (httpwebrequestFunction._cufe.Length>30)
                    {
                        console.Cblue();
                        console.Ih("    & Cufe : " + httpwebrequestFunction._cufe);
                        //UpdateInfoDianCufe(factura, cufe, httpwebrequestFunction._soapRecibido, httpwebrequestFunction);
                        UpdateInfoDianCufe(httpwebrequestFunction);
                        //UpdateDetLogDianCufe(factura, cufe);
                        UpdateDetLogDianCufe(httpwebrequestFunction);
                        //UpdateLogReporteDianCufe(factura, cufe);
                        UpdateLogReporteDianCufe(httpwebrequestFunction);
                        UpdateLogReporteDian(httpwebrequestFunction);
                    }
                }
            }
            catch (Exception ex)
            {
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException;
            }
            return httpwebrequestFunction;
        }

        private void UpdateLogReporteDian(HttpsWebRequestsFunction httpwebrequestFunction)
        {
            try
            {
                console.Cgreen();
                if (httpwebrequestFunction._cufe.Length > 30)
                {
                    //console.Ih("=> Factura " + httpwebrequestFunction._Numdoc);
                    //console.Ih("    * Cufe : " + httpwebrequestFunction._cufe);
                    using (Factory data = new Factory(Usuario, Password, Ambiente))
                    {
                        string[] _nParametros;
                        object[] _vParametros;
                        _nParametros = new string[2] { ":estado", ":factura" };
                        _vParametros = new object[2] { "E", httpwebrequestFunction._Numdoc };
                        data.executeCommand("updateLogReporteDian", _nParametros, _vParametros);
                    }
                }
                else
                {
                    console.CRed();
                    console.ReadKey("    * La Factura : " + httpwebrequestFunction._Numdoc + "  No fue aceptada por el CENF.", false);
                }
            }
            catch (Exception ex)
            {
                console.CRed();
                console.ReadKey("    * La Factura : " + httpwebrequestFunction._Numdoc + "  No fue aceptada por el CENF.", false);
            }
        }

        private void UpdateInfoDianCufe(HttpsWebRequestsFunction httpwebrequestFunction)
        {
            using (Factory data = new Factory(Usuario, Password, Ambiente))
            {
                string[] _nParametros;
                object[] _vParametros;
                //:filename,:filedata,:companyid,:accountid,:status,:transactionid,:xmlfactura,:soapenviado,:soaprespuesta
                //_nParametros = new string[4] { ":INDI_CUFEDIAN", ":INDI_NUMDOC", ":indi_xmllegal", ":indi_xmlrec" };
                //_vParametros = new object[4] { cufe,factura, INDI_XMLLEGAL, httpwebrequestFunction._downloadData };
                //_nParametros = new string[3] { ":INDI_CUFEDIAN", ":INDI_NUMDOC", ":indi_xmllegal" };
                //_vParametros = new object[3] { cufe, factura, INDI_XMLLEGAL };
                _nParametros = new string[3] { ":INDI_CUFEDIAN", ":indi_xmlrec", ":INDI_NUMDOC" };
                _vParametros = new object[3] { httpwebrequestFunction._cufe, httpwebrequestFunction._FacturaXml, httpwebrequestFunction._Numdoc };
                //_nParametros = new string[2] { ":INDI_CUFEDIAN", ":INDI_NUMDOC" };
                //_vParametros = new object[2] { httpwebrequestFunction._cufe, httpwebrequestFunction._Numdoc };
                data.executeCommand("updateInfoDianCufe", _nParametros, _vParametros);
            }

        }
        private void UpdateDetLogDianCufe(HttpsWebRequestsFunction httpwebrequestFunction)
        {
            using (Factory data = new Factory(Usuario, Password, Ambiente))
            {
                string[] _nParametros;
                object[] _vParametros;
                //:filename,:filedata,:companyid,:accountid,:status,:transactionid,:xmlfactura,:soapenviado,:soaprespuesta
                _nParametros = new string[2] { ":INDI_CUFEDIAN", ":INDI_NUMDOC" };
                //_vParametros = new object[2] { cufe, factura };
                _vParametros = new object[2] { httpwebrequestFunction._cufe, httpwebrequestFunction._FileName };
                data.executeCommand("updateDetLogDianCufe", _nParametros, _vParametros);
            }
        }
        private void UpdateLogReporteDianCufe(HttpsWebRequestsFunction httpwebrequestFunction)
        {
            using (Factory data = new Factory(Usuario, Password, Ambiente))
            {
                string[] _nParametros;
                object[] _vParametros;
                //:filename,:filedata,:companyid,:accountid,:status,:transactionid,:xmlfactura,:soapenviado,:soaprespuesta
                _nParametros = new string[1] { ":LODI_LLAVE" };
                _vParametros = new object[1] { httpwebrequestFunction._Numdoc };
                data.executeCommand("updateLogReporteDianCufe", _nParametros, _vParametros);
            }
        }

        private HttpsWebRequestsFunction procesarDownloadDataCufe(HttpsWebRequestsFunction httpwebrequestFunction)
        {
            string nombreArchivo = @"c:\transer\ws\facturacion\" + httpwebrequestFunction._Numdoc + "\\cufe\\" + httpwebrequestFunction._Numdoc + ".xml";
            //string cufe = string.Empty;
            byte[] b = Convert.FromBase64String(httpwebrequestFunction._downloadData);
            httpwebrequestFunction._FacturaXml = getEncoding(b);//Encoding.GetEncoding(1252).GetString(b);
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(httpwebrequestFunction._FacturaXml);
                doc.Save(nombreArchivo);
                XmlElement root = doc.DocumentElement;
                XmlNodeList elemListStatus = root.GetElementsByTagName("cbc:UUID");
                #pragma warning disable CS0162 // Se detectó código inaccesible
                for (int i = 0; i < elemListStatus.Count; i++)
                #pragma warning restore CS0162 // Se detectó código inaccesible
                {
                    httpwebrequestFunction._cufe = elemListStatus[i].InnerXml;
                    
                    break;
                }
            }
            catch (Exception ex)
            {
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException;
            }
            return httpwebrequestFunction;
        }
        public string getEncoding(byte[] elementList)
        {
            return Encoding.GetEncoding(1252).GetString(elementList);
        }
        public byte[] getEncoding(string elementList)
        {
            return Encoding.GetEncoding(1252).GetBytes(elementList);
        }

        private void actualizarlogReporteDian(string v, HttpsWebRequestsFunction httpwebrequestFunction, string factura)
        {
            throw new NotImplementedException();
        }
        private ICollection<InformacionDian> LeerInformacionDianEnProceso()
        {
            ICollection<InformacionDian> ICInformacionDian = new List<InformacionDian>();
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[0] { };
            _vParametros = new object[0] { };
            Factory data = new Factory(Usuario, Password, Ambiente);
            try
            {
                var dt = data.getTable("getInformacionDianEnProceso", _nParametros, _vParametros);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        try
                        {
                            ICInformacionDian.Add(addInformacionDian(item));
                        }
                        catch (Exception exx)
                        {

                            ManejoError(exx, "ICInformacionDian.Add(addInformacionDian(item));");
                        }
                        //break;
                    }
                }
            }
            catch (Exception ex)
            {
                ManejoError(ex, "var dtLogReporteDian = data.getTable(\"getLogReporteDian\", _nParametros, _vParametros);");
            }
            return ICInformacionDian;
        }
        private ICollection<InformacionDian> LeerInformacionDian(string factura)
        {
            ICollection<InformacionDian> ICInformacionDian = new List<InformacionDian>();
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[1] { ":INDI_NUMDOC" };
            _vParametros = new object[1] { factura };
            Factory data = new Factory(Usuario, Password, Ambiente);
            try
            {
                var dt = data.getTable("getInformacionDian", _nParametros, _vParametros);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        try
                        {
                            ICInformacionDian.Add(addInformacionDian(item));
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
            return ICInformacionDian;
        }
        private InformacionDian addInformacionDian(DataRow item)
        {
            InformacionDian informacionDian = new InformacionDian();
            informacionDian.INDI_NUMDOC_V2 = item["INDI_NUMDOC_V2"].ToString();
            informacionDian.INDI_OFICDOC_NB = int.Parse(item["INDI_OFICDOC_NB"].ToString());
            informacionDian.INDI_TIPODOC_V2 = item["INDI_TIPODOC_V2"].ToString();
            informacionDian.INDI_EMAIL_V2 = item["INDI_EMAIL_V2"].ToString();
            informacionDian.INDI_XMLENV_CB = item["INDI_XMLENV_CB"].ToString();
            informacionDian.INDI_CUFEDIAN_V2 = item["INDI_CUFEDIAN_V2"].ToString();
            informacionDian.INDI_IDCARVAJAL_V2 = item["INDI_IDCARVAJAL_V2"].ToString();
            informacionDian.INDI_XMLREC_BL = InitializateBl();
            informacionDian.INDI_REPGRAFICA_BL = InitializateBl();
            informacionDian.INDI_XMLLEGAL_CB = item["INDI_XMLLEGAL_CB"].ToString();
            informacionDian.INDI_FECCREA_TS = DateTime.Parse(item["INDI_FECCREA_TS"].ToString());
            informacionDian.INDI_FECESTADO_TS = DateTime.Parse(item["INDI_FECCREA_TS"].ToString());
            informacionDian.INDI_VALIDACION_CL = item["INDI_VALIDACION_CL"].ToString();
            informacionDian.INDI_CLIENTE_NB= int.Parse(item["INDI_CLIENTE_NB"].ToString());
            informacionDian.INDI_NOMCLIENTE_V2 = item["INDI_NOMCLIENTE_V2"].ToString();
            return informacionDian;
        }
        private byte[] InitializateBl()
        {
            return new byte[1];
        }

        private void ManejoError(Exception ex, string texto)
        {
            using (StreamWriter writer = new StreamWriter("logLogicaNegocio.txt", true))
            {
                writer.WriteLine("Fecha : " + DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString());
                writer.WriteLine("Se Produjo un error de tipo Exception:");
                writer.WriteLine(ex.Message);
            }
        }
        private HttpsWebRequestsFunction PdfFactura(string factura)
        {
            HttpsWebRequestsFunction httpwebrequestFunction = new HttpsWebRequestsFunction();
            string estado = string.Empty;
            ICollection<InformacionDian> ICInformacionDian = new List<InformacionDian>();
            ICInformacionDian = LeerInformacionDian(factura);
            if (ICInformacionDian.Count > 0)
            {
                foreach (var item in ICInformacionDian)
                {
                    httpwebrequestFunction._Numdoc = item.INDI_NUMDOC_V2;
                    httpwebrequestFunction._FileName = item.INDI_NUMDOC_V2;
                    httpwebrequestFunction._FacturaXml = item.INDI_XMLENV_CB;
                    httpwebrequestFunction = maquetarSoapFactura(httpwebrequestFunction);
                    bool continuar = true;
                    int intentos = 0;
                    //console.Ih("Enviar Factura ");
                    while (continuar)
                    {
                        httpwebrequestFunction = EnviarFactura(httpwebrequestFunction);
                        if (httpwebrequestFunction._httpWebResponseXml.Contains("Error interno"))
                        {
                            intentos++;
                            console.CRed();
                            console.Ih("Intentos de Envío : " + intentos);
                            //console.Ih(httpwebrequestFunction._httpWebResponseXml);
                            System.Threading.Thread.Sleep(2000);
                        }
                        else
                        {
                            httpwebrequestFunction = procesarFacturaXMLRecibido(httpwebrequestFunction);
                            validarDirectorio(item.INDI_NUMDOC_V2);
                            httpwebrequestFunction = Cufe(item.INDI_NUMDOC_V2);
                            continuar = false;//<status>
                        }
                        if (intentos>4)
                        {
                            string mensaje = string.Empty;
                            mensaje += "No fue posible reportar la factura : ";
                            mensaje += httpwebrequestFunction._FileName;
                            mensaje += "\r\n ";
                            mensaje += "\r\n ";
                            mensaje += "\r\nDescripcion del Error ";
                            mensaje += httpwebrequestFunction._httpWebResponseXml;
                            mensaje += "\r\n ";
                            mensaje += "\r\n ";
                            mensaje += "\r\n ===  >  Informacion de la Factura  < ===";
                            mensaje += "\r\nFecha Crea   : " + item.INDI_FECCREA_TS;
                            mensaje += "\r\nId Carvajal  : " + item.INDI_IDCARVAJAL_V2;
                            mensaje += "\r\nValidacion   : "+ item.INDI_VALIDACION_CL;
                            mensaje += "\r\nEmail        : " + item.INDI_EMAIL_V2;
                            mensaje += "\r\nXML Enviado  : " + item.INDI_XMLENV_CB;
                            console.Ih("No fue posible enviar la factura");
                            //SendEmail("No fue posible enviar la factura", mensaje, "fmontoya@transer.com.co", "jsoporte@transer.com.co", "francisco.montoya.l@gmail.com");
                            continuar = false;//<status>
                        }
                    }
                }
            }
            return httpwebrequestFunction;
        }
        private HttpsWebRequestsFunction procesarFacturaXMLRecibido(HttpsWebRequestsFunction httpwebrequestFunction)
        {
            string nombreArchivo = @"c:\transer\ws\facturacion\" + httpwebrequestFunction._Numdoc + "\\" + httpwebrequestFunction._Numdoc + "_xmlFactura.xml";
            string cufe = string.Empty;
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(httpwebrequestFunction._soapRecibido);
                doc.Save(nombreArchivo);
                XmlElement root = doc.DocumentElement;
                XmlNodeList elemListStatus = root.GetElementsByTagName("status");
#pragma warning disable CS0162 // Se detectó código inaccesible
                for (int i = 0; i < elemListStatus.Count; i++)
#pragma warning restore CS0162 // Se detectó código inaccesible
                {
                    httpwebrequestFunction._status = elemListStatus[i].InnerXml;
                    break;
                }
                XmlNodeList elemListTransactionId = root.GetElementsByTagName("downloadData");
#pragma warning disable CS0162 // Se detectó código inaccesible
                for (int i = 0; i < elemListTransactionId.Count; i++)
#pragma warning restore CS0162 // Se detectó código inaccesible
                {
                    httpwebrequestFunction._downloadData = elemListTransactionId[i].InnerXml;
                    break;
                }
                if (httpwebrequestFunction._status == "Recurso recibido satisfactoriamente.")
                {
                    byte[] bytesX = procesarDownloadDataFactura(httpwebrequestFunction);
                    if (bytesX.Length>100)
                    {
                        httpwebrequestFunction = UpdateInfoDianFactura(httpwebrequestFunction, bytesX);
                    }
                }
            }
            catch (Exception ex)
            {
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException;
            }
            return httpwebrequestFunction;
        }
        private HttpsWebRequestsFunction UpdateInfoDianFactura(HttpsWebRequestsFunction httpwebrequestFunction, byte[] bytesX)
        {
            using (Factory data = new Factory(Usuario, Password, Ambiente))
            {
                string[] _nParametros;
                object[] _vParametros;
                //:filename,:filedata,:companyid,:accountid,:status,:transactionid,:xmlfactura,:soapenviado,:soaprespuesta
                _nParametros = new string[2] { ":indi_repgrafica", ":INDI_NUMDOC" };
                _vParametros = new object[2] { bytesX, httpwebrequestFunction._Numdoc };
                data.executeCommand("updateInfoDianFactura", _nParametros, _vParametros);
            }
            return httpwebrequestFunction;
        }
        private byte[] procesarDownloadDataFactura(HttpsWebRequestsFunction httpwebrequestFunction)
        {
            //string cufe = string.Empty;
            byte[] b = Convert.FromBase64String(httpwebrequestFunction._downloadData);
            string tmp = getEncoding(b);
            byte[] bytesX = getEncoding(tmp);
            //string tmpr = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            //string rutatmp = @"C:\Transer\ws\facturacion\" + factura + "\\" + factura + "_" + tmpr + ".pdf";
            string rutatmp = @"c:\transer\ws\facturacion\" + httpwebrequestFunction._Numdoc + "\\pdf\\" + httpwebrequestFunction._Numdoc + ".pdf";
            try
            {
                System.IO.File.WriteAllBytes(rutatmp, bytesX);
                console.Cblue();
                console.Ih("    !!! Captura Exitosa Representacion Grafica Factura  !!!" );
            }
            catch (Exception EX)
            {
                Console.WriteLine(EX.Message);
            }
            return bytesX;
        }

        private HttpsWebRequestsFunction maquetarSoapFactura(HttpsWebRequestsFunction httpwebrequestFunction)
        {
            string estado = string.Empty;
            httpwebrequestFunction._companyId = "860504882";
            httpwebrequestFunction._accountid = "860504882_01";
            httpwebrequestFunction._Username = "fmontoya@transer.com.co";
            httpwebrequestFunction._userId = "UsernameToken-1";
            EncodingFacturacionElectronica coding = new EncodingFacturacionElectronica();
            //Produccion httpwebrequestFunction._Password = coding.SHA256Encrypt("F935Cjm9262@");//Produccion
            httpwebrequestFunction._Password = coding.SHA256Encrypt("Tys860504882@");//pruebas
            //httpwebrequestFunction._Password = coding.SHA256Encrypt("TranserFac@1");
            httpwebrequestFunction._HttpWebRequestFunction = "DownloadRequest";
            httpwebrequestFunction._create = coding.getCreate();
            httpwebrequestFunction._nonce = coding.getNonce(httpwebrequestFunction._FileName);
            string documentType = "FE";
            if (httpwebrequestFunction._FileName.Contains("NC"))
            {
                documentType = "NC";
            }
            else
            {
                if (httpwebrequestFunction._FileName.Contains("ND"))
                {
                    documentType = "ND";
                }
            }
            switch (documentType)
            {
                case "NC":
                    {
                        httpwebrequestFunction._documentType = "NC";
                        break;
                    }
                case "ND":
                    {
                        httpwebrequestFunction._documentType = "ND";
                        break;
                    }
                case "FV":
                    {
                        httpwebrequestFunction._documentType = "FV";
                        break;
                    }
                default:
                    {
                        httpwebrequestFunction._documentType = "FE";
                        break;
                    }
            }
            httpwebrequestFunction._documentPrefix = httpwebrequestFunction._FileName.Substring(0, 4);
            httpwebrequestFunction._documentNumber = httpwebrequestFunction._FileName;
            httpwebrequestFunction._resourceType = "PDF";
            httpWebSend xmlsend = new httpWebSend();
            httpwebrequestFunction._soapEnviado = xmlsend.getSoapEnvio(httpwebrequestFunction);

            //httpSendXmlDocument httpsSendXmlDocument = new httpSendXmlDocument(vgl);


            ////HttpWebResponseFunction httpWebResponseFunction = new HttpWebResponseFunction("Upload");

            //httpwebrequestFunction._httpWebResponseXml = httpsSendXmlDocument.httpsSendXmlDocument(httpwebrequestFunction._soapEnviado);
            //httpwebrequestFunction._RequestXmlf = httpsSendXmlDocument._vgp.httpwebrequestFunction._RequestXmlf;
            //httpwebrequestFunction._soapRecibido = httpwebrequestFunction._httpWebResponseXml;
            ////_vgp.informaciondian.INDI_XMLREC_BL = vgl.httpwebrequestFunction._soapRecibido;
            //httpWebRequestFunctionDownloadXML httpWebRequestFunctionDownloadXml = new httpWebRequestFunctionDownloadXML(_vgp);
            //httpWebRequestFunctionDownloadXml.httpwebRequestFunctionDownloadxml(vgl.httpwebrequestFunction._soapRecibido);
            return httpwebrequestFunction;
        }
        private void validarDirectorio(string factura)
        {
            string ruta = @"c:\transer\ws\facturacion\" + factura;
            if (!Directory.Exists(ruta))
                Directory.CreateDirectory(ruta);
            string cufe = ruta + "\\cufe";
            if (!Directory.Exists(cufe))
                Directory.CreateDirectory(cufe);
            string pdf = ruta + "\\pdf";
            if (!Directory.Exists(pdf))
                Directory.CreateDirectory(pdf);
        }


        private bool SendEmail(string asunto, string mensaje, string para, string copia, string copiaOculta)
        {
            //SendEmail("Transer.Tecnologia.Automatizacion", ex.Message, "fmontoya@transer.com.co", "soporte@transer.com.co", "francisco.montoya.l@gmail.com");
            ConfiguracionEmail cfEmail = new ConfiguracionEmail();
            cfEmail.Asunto = asunto;
            cfEmail.Mensaje = mensaje;
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
            //addLog(Correo.MensajeError);
            return Correo.SendMail(cfEmail);
        }

    }

    internal class httpWebSend
    {
        public string getSoapEnvio(HttpsWebRequestsFunction httpwebrequestFunction)
        {
            string myXmlSoap = getResponseFunctionDownload(httpwebrequestFunction);
            XmlDocument soapEnvelopeXml = CreateSoapEnvelopeCarvajal(myXmlSoap);
            return soapEnvelopeXml.InnerXml;
        }
        private XmlDocument CreateSoapEnvelopeCarvajal(string myXmlSoap)
        {
            XmlDocument soapEnvelop = new XmlDocument();
            try
            {
                soapEnvelop.LoadXml(myXmlSoap);
            }
            catch (XmlException ex)
            {
                string _mensajeError = @"XmlException : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caDStysVS01_logicaProceso_public async void inicio()" + "\r\n XML : \r\n" + myXmlSoap;
            }
            catch (Exception ex)
            {
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caDStysVS01_logicaProceso_public async void inicio()";
            }
            return soapEnvelop;
        }
        public string getResponseFunctionDownload(HttpsWebRequestsFunction httpwebrequestFunction)
        {
            StringBuilder select = new StringBuilder();
            select.Append("<soapenv:Envelope\r\n");
            select.Append("xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\"\r\n");
            select.Append("xmlns:inv=\"http://invoice.carvajal.com/invoiceService/\"\r\n");
            select.Append("xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-");
            select.Append("secext-1.0.xsd\"\r\n");
            select.Append("xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-");
            select.Append("utility-1.0.xsd\">\r\n");
            select.Append("   <soapenv:Header>\r\n");
            select.Append("   <wsse:Security>\r\n");
            select.Append("   <wsse:UsernameToken wsu:Id=\"" + httpwebrequestFunction._userId + "\">\r\n");
            select.Append("   	<wsse:Username>" + httpwebrequestFunction._Username + "</wsse:Username>\r\n");
            select.Append("<wsse:Password Type=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-");
            select.Append("wss-username-token-profile-");
            select.Append("1.0#PasswordText\">" + httpwebrequestFunction._Password + "</w");
            select.Append("sse:Password>\r\n");
            select.Append("	<wsse:Nonce EncodingType=\"http://docs.oasis-open.org/wss/2004/01/oasis-");
            select.Append("200401-wss-soap-message-security-");
            select.Append("1.0#Base64Binary\">" + httpwebrequestFunction._nonce + "</wsse:Nonce>\r\n");
            select.Append("		<wsu:Created>" + httpwebrequestFunction._create + "</wsu:Created>\r\n");
            select.Append("		</wsse:UsernameToken>\r\n");
            select.Append("		</wsse:Security>\r\n");
            select.Append("   </soapenv:Header>\r\n");
            select.Append("   <soapenv:Body>\r\n");
            select.Append("      <inv:" + httpwebrequestFunction._HttpWebRequestFunction + ">\r\n");
            select.Append("         <companyId>" + httpwebrequestFunction._companyId + "</companyId>\r\n");
            select.Append("         <accountId>" + httpwebrequestFunction._accountid + "</accountId>\r\n");
            select.Append("         <documentType>" + httpwebrequestFunction._documentType + "</documentType>\r\n");
            select.Append("         <documentPrefix>" + httpwebrequestFunction._documentPrefix + "</documentPrefix>\r\n");
            select.Append("         <documentNumber>" + httpwebrequestFunction._documentNumber + "</documentNumber>\r\n");
            select.Append("         <resourceType>" + httpwebrequestFunction._resourceType + "</resourceType>\r\n");
            select.Append("      </inv:" + httpwebrequestFunction._HttpWebRequestFunction + ">\r\n");
            select.Append("   </soapenv:Body>\r\n");
            select.Append("</soapenv:Envelope>");
            return select.ToString();
        }
    }
}
