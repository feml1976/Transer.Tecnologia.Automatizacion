using System;
using System.IO;
using System.Net;
using System.Xml;
using Transer.Tecnologia.Automatizacion.Entity;

namespace Transer.Tecnologia.Automatizacion.HttpsSendXmlDocument
{
    public class HttpSendXmlDocument
    {
        /*VERSION PRODUCCION*/
        public HttpSendXmlDocument()
        {

        }

        public HttpsWebRequestsFunction httpsSendXmlDocument(HttpsWebRequestsFunction httpwebrequestFunction)
        {
            //int intentos = 0;
            //bool continuar = true;
            //string httpRequest = string.Empty;
            //string xml = httpwebrequestFunction._soapEnviado;
            string url = "https://wscenflab.cen.biz/isows/InvoiceService?wsdl";//PILOTO
            //string url = "https://wscenf.cen.biz/isows/InvoiceService?wsdl";//PRODUCCION
            //string url = "https://cenfinancierolab.cen.biz/isows/InvoiceService?wsdl";//PRUEBAS
            //string url = "https://cenfinanciero.cen.biz/isows/InvoiceService?wsdl";//PRODUCCION
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            byte[] requestBytes = System.Text.Encoding.ASCII.GetBytes(httpwebrequestFunction._soapEnviado);
            req.Method = "POST";
            req.ContentType = "text/xml;charset=utf-8";
            req.ContentLength = requestBytes.Length;
            Stream requestStream = req.GetRequestStream();
            requestStream.Write(requestBytes, 0, requestBytes.Length);
            requestStream.Close();
            //while (continuar)
            //{
            try
            {
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.Default);
                httpwebrequestFunction._backstr = sr.ReadToEnd();
                sr.Close();
                res.Close();
                httpwebrequestFunction._httpWebResponseXml = getXMLReturn(httpwebrequestFunction._backstr);
                //continuar = false;
                //break;
            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    httpwebrequestFunction._httpWebResponseXml = reader.ReadToEnd();
                }


                //httpwebrequestFunction._httpWebResponseXml = ex.Message;
                string _mensajeError = @"HttpListenerException : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio()" + "\r\n SOAP : \r\n" + httpwebrequestFunction._soapEnviado;
            }
            catch (HttpListenerException ex)
            {
                httpwebrequestFunction._httpWebResponseXml = ex.Message;
                string _mensajeError = @"HttpListenerException : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio()" + "\r\n SOAP : \r\n" + httpwebrequestFunction._soapEnviado;
                //intentos++;
            }
            catch (Exception ex)
            {
                httpwebrequestFunction._httpWebResponseXml = ex.Message;
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio()" + "\r\nSOAP : \r\n" + httpwebrequestFunction._soapEnviado;
                //intentos++;
            }
            //    if (intentos>3)
            //    {
            //        continuar = false;
            //        break;
            //    }
            //}
            return httpwebrequestFunction;
        }
        private string getXMLReturn(string txbRequestXmlf)
        {
            string requesTmp = string.Empty;
            XmlDocument doc = new XmlDocument();

            try
            {
                requesTmp = txbRequestXmlf.Substring(txbRequestXmlf.IndexOf("<soap:"));
                int index = requesTmp.LastIndexOf(":Envelope>");
                if (index > 0)
                    requesTmp = requesTmp.Substring(0, index + 10);
                try
                {
                    doc.LoadXml(requesTmp);
                    XmlElement root = doc.DocumentElement;
                    XmlNodeList elemListStatus = root.GetElementsByTagName("status");
                    for (int i = 0; i < elemListStatus.Count; i++)
                    {
                        string status = elemListStatus[i].InnerXml;
                    }
                }
                catch (Exception ex)
                {
                    requesTmp = ex.Message;
                    string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                          "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio()" + "\r\nSOAP : \r\n" + txbRequestXmlf;
                }
            }
            catch (Exception ex)
            {
                requesTmp = ex.Message;
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio()" + "\r\nSOAP : \r\n" + txbRequestXmlf;
            }

            return requesTmp;
        }
        private string getOldXMLReturn(string txbRequestXmlf)
        {
            string output = txbRequestXmlf;
            if (txbRequestXmlf == "Error en el servidor remoto: (500) Error interno del servidor.")
            {
                output = txbRequestXmlf;
            }
            if (txbRequestXmlf == "No es posible conectar con el servidor remoto")
            {
                output = txbRequestXmlf;
            }
            else
            {
                if (txbRequestXmlf.Contains("<soap:") && txbRequestXmlf.Contains(":Envelope>"))
                {
                    output = txbRequestXmlf;
                    try
                    {
                        txbRequestXmlf = output.Substring(output.IndexOf("<soap:"));
                        int index = txbRequestXmlf.LastIndexOf(":Envelope>");
                        if (index > 0)
                            txbRequestXmlf = txbRequestXmlf.Substring(0, index + 10);
                    }
                    catch (Exception ex)
                    {
                        string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                              "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio()" + "\r\nSOAP : \r\n" + txbRequestXmlf;
                    }
                }
                else
                {
                    if (txbRequestXmlf.Contains("<soapenv:") && txbRequestXmlf.Contains(":Envelope>"))
                    {
                        output = txbRequestXmlf;
                        try
                        {
                            txbRequestXmlf = output.Substring(output.IndexOf("<soapenv:"));
                            int index = txbRequestXmlf.LastIndexOf(":Envelope>");
                            if (index > 0)
                                txbRequestXmlf = txbRequestXmlf.Substring(0, index + 10);
                        }
                        catch (Exception ex)
                        {
                            string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                                  "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio()" + "\r\nSOAP : \r\n" + txbRequestXmlf;
                        }
                    }
                }
            }
            return txbRequestXmlf;
        }
    }
}
